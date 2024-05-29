using Azure.Messaging.ServiceBus;
using Frontend.Models;
using Frontend.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace Frontend.Controllers;

public class AuthController : Controller
{
    private readonly HttpClient _http;
    private readonly IConfiguration _configuration;
    private readonly ServiceBusClient _client;
    private ServiceBusProcessor _processor;

    public AuthController(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _configuration = configuration;
        _client = new ServiceBusClient(_configuration.GetConnectionString("ServiceBus"));
        _processor = _client.CreateProcessor("facebook_response");
        _processor.ProcessMessageAsync += MessageHandler;
        _processor.ProcessErrorAsync += ErrorHandler;
    }

    #region sign up
    [HttpGet]
    [Route("/signup")]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    [Route("/signup")]
    public async Task<IActionResult> SignUp(SignUpViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _http.PostAsJsonAsync(_configuration["Urls:SignUpUrl"], model);
            if (result.IsSuccessStatusCode)
            {
                TempData["VerifyAccountEmail"] = model.Email;
                return RedirectToAction("VerifyAccount", "Verification");
            }
            else if (result.StatusCode == HttpStatusCode.Conflict)
            {
                ViewData["StatusMessage"] = "User with same email already exist";
            }
            else
            {
                ViewData["StatusMessage"] = "Something went wrong. please try again";
            }
        }
        else
        {
            ViewData["StatusMessage"] = "Please enter all information correctly";
        }
        return View(model);
    }

    #endregion


    #region Sign in
    [HttpGet]
    [Route("/signin")]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    [Route("/signin")]
    public async Task<IActionResult> SignIn(SignInViewModel model)
    {
        if (ModelState.IsValid)
        {
            var response = await _http.PostAsJsonAsync(_configuration["Urls:SignInUrl"], model);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<SignInResponseResult>(await response.Content.ReadAsStringAsync());

                if (result != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, result.Id),
                        new Claim(ClaimTypes.Name, result.Username),
                        new Claim(ClaimTypes.Email, result.Email)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTime.Now.AddHours(1),
                        IsPersistent = true,
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return RedirectToAction("Home", "Default");
                }

                
            }
            else
            {
                ViewData["StatusMessage"] = "Incorrect email or password";
            }
        }
        else
        {
            ViewData["StatusMessage"] = "Please enter all information correctly";
        }
        return View(model);
    }

    #endregion

    #region sign out
    [Route("/signout")]
    public async Task<IActionResult> SignOut()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("SignIn", "Auth");
    }

    #endregion


    #region facebook signin
    [HttpGet]
    public async Task<IActionResult> FacebookSignIn()
    {
        await StartProcessingExternalLogin();

        var azureFunctionUri = _configuration["Urls:ExternalLoginFacebookUrl"]!;
        return Redirect(azureFunctionUri);
    }

    [HttpGet]
    public async Task Callback(string code, string state) 
    {
        var azureFunctionUri = $"http://localhost:7234/signin-facebook/callback?code={code}&state={state}";
        var response = await _http.GetAsync(azureFunctionUri);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TokenResponse>(content);
        }
    }

    public class TokenResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; } = null!;
    }

    public async Task StartProcessingExternalLogin()
    {
        await _processor.StartProcessingAsync();
    }

    public async Task StopProcessingExternalLogin()
    {
        await _processor.StopProcessingAsync();
    }

    public async Task MessageHandler(ProcessMessageEventArgs args)
    {
        string message = args.Message.Body.ToString();

        if (!string.IsNullOrEmpty(message))
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(message);
            if (jsonToken != null)
            {
                var tokenS = jsonToken as JwtSecurityToken;

                if (tokenS != null)
                {
                    var jwtClaims = tokenS.Claims;
                    List<Claim> claimsList = [];

                    foreach (var claim in jwtClaims)
                    {
                        claimsList.Add(claim);
                    }

                    var nameIdentifier = claimsList[0].Value;
                    var name = claimsList[1].Value;
                    var email = claimsList[2].Value;


                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, nameIdentifier),
                        new Claim(ClaimTypes.Name, name),
                        new Claim(ClaimTypes.Email, email)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTime.Now.AddHours(1),
                        IsPersistent = true,
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    await args.CompleteMessageAsync(args.Message);
                }
            }
        }
    }

    public async Task ErrorHandler(ProcessErrorEventArgs args)
    {

    }

    #endregion
}

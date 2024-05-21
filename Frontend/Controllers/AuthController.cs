using Frontend.Models;
using Frontend.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace Frontend.Controllers;

public class AuthController : Controller
{
    private readonly HttpClient _http;
    private readonly IConfiguration _configuration;


    public AuthController(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _configuration = configuration;
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
            var response = await _http.PostAsJsonAsync("http://localhost:7234/api/SignIn", model);
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
}

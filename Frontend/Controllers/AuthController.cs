using Frontend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Net.WebRequestMethods;

namespace Frontend.Controllers;

public class AuthController : Controller
{
    private readonly HttpClient _http;

    public AuthController(HttpClient http)
    {
        _http = http;
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
            var result = await _http.PostAsJsonAsync("http://localhost:7234/api/SignUp", model);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Verify", "Verification");
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
            var result = await _http.PostAsJsonAsync("http://localhost:7234/api/SignIn", model);
            if (result.IsSuccessStatusCode)
            {
                return LocalRedirect("/");
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
}

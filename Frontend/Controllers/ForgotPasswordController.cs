using Frontend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Frontend.Controllers;

public class ForgotPasswordController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;

    [HttpGet]
    [Route("/forgotpassword")]
    public IActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost]
    [Route("/forgotpassword")]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
    {
        if(ModelState.IsValid)
        {
            var result = await _http.PostAsJsonAsync("", model);
            if(result.IsSuccessStatusCode)
            {
                return RedirectToAction("NewPassword", "ForgotPassword");
                //Ska Skicka en kod till email. 
                //Skriva in kod 
                //Få skriva in ett nytt lösenord
            }
        }
        else
        {
            ViewData["StatusMessage"] = "Please enter all information correctly.";
        }
        return View(model);
    }

    [HttpGet]
    [Route("/forgotpassword/newpassword")]
    public IActionResult NewPassword()
    {
        return View();
    }

    [HttpPost]
    [Route("/forgotpassword/newpassword")]
    public async Task<IActionResult> NewPassword(NewPasswordViewModel model)
    {
        if(ModelState.IsValid)
        {
            var result = await _http.PostAsJsonAsync("", model);
            if(result.IsSuccessStatusCode)
            {
                return RedirectToAction("SignIn", "Auth");
            }
            else
            {
                ViewData["StatusMessage"] = "Something went wrong";
            }
        }
        else
        {
            ViewData["StatusMessage"] = "Please enter all information correctly.";
        }
        return View(model);
    }
}

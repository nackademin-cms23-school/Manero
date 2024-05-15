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
                return RedirectToAction("ForgotPasswordNewPassword", "ForgotPassword");
                //Ska Skicka en kod till email. 
                //Skriva in kod 
                //Få skriva in ett nytt lösenord
            }
            else if(result.StatusCode == HttpStatusCode.Conflict)
            {
                ViewData["StatusMessage"] = "The emailaddress does not exists.";
            }
            else
            {
                ViewData["StatusMessage"] = "Something went wrong. Please try again.";
            }

        }
        else
        {
            ViewData["StatusMessage"] = "Please enter all information correctly.";
        }
        return View(model);
    }
}

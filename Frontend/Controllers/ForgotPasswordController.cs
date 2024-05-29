using Frontend.Models;
using Frontend.Services;
using Frontend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Frontend.Controllers;

public class ForgotPasswordController : Controller
{
    private readonly HttpClient _http;
    private readonly IConfiguration _configuration;

    public ForgotPasswordController(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _configuration = configuration;
    }

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
            var result = await _http.PostAsJsonAsync(_configuration["Urls:ForgotPasswordUrl"], model);
            if(result.IsSuccessStatusCode)
            {
                TempData["ForgotPasswordEmail"] = model.Email;
                return RedirectToAction("Verify", "ForgotPassword");
            }
        }
        else
        {
            ViewData["StatusMessage"] = "Please enter all information correctly.";
        }
        return View(model);
    }

    [HttpGet]
    [Route("/forgotpassword/verify")]
    public IActionResult Verify()
    {
        return View();
    }

    [HttpPost]
    [Route("/forgotpassword/verify")]
    public async Task<IActionResult> Verify(ForgotPasswordCodeViewModel model)
    {
        if(ModelState.IsValid)
        {
            var code = TypeConverter.StringArrayToString(model.Code);

            if(!string.IsNullOrEmpty(code))
            {
                var email = TempData["ForgotPasswordEmail"]!.ToString();

                var forgotPasswordValidate = new ForgotPasswordValidateModel
                {
                    Email = email!,
                    Code = code,
                };

                var result = await _http.PostAsJsonAsync(_configuration["Urls:ValidateForgotPasswordCodeUrl"], forgotPasswordValidate);

                if(result.IsSuccessStatusCode)
                {
                    TempData["ForgotPasswordEmail"] = email;
                    return RedirectToAction("ResetPassword", "ForgotPassword");
                }
            }
        }

        return View();
    }


    [HttpGet]
    [Route("/forgotpassword/resetpassword")]
    public IActionResult ResetPassword()
    {
        return View();
    }

    [HttpPost]
    [Route("/forgotpassword/resetpassword")]
    public async Task<IActionResult> ResetPassword(ResetForgotPasswordViewModel model)
    {
        if(ModelState.IsValid)
        {
            var resetForgotPasswordModel = new ResetForgotPasswordModel
            {
                Email = TempData["ForgotPasswordEmail"]!.ToString()!,
                Password = model.NewPassword,
                ConfirmPassword = model.ConfirmPassword
            };

            if (resetForgotPasswordModel != null!)
            {
                var result = await _http.PostAsJsonAsync(_configuration["Urls:ResetPasswordUrl"], resetForgotPasswordModel);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("SignIn", "Auth");
                }
                else
                {
                    ViewData["StatusMessage"] = "Something went wrong";
                }
            }
        }
        else
        {
            ViewData["StatusMessage"] = "Please enter all information correctly.";
        }
        return View(model);
    }
}

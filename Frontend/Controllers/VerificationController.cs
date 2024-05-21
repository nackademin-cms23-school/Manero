using Frontend.Models;
using Frontend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class VerificationController : Controller
{
    private readonly HttpClient _http;
    private readonly IConfiguration _configuration;

    public VerificationController(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _configuration = configuration;
    }

    [HttpGet]
    [Route("/verifyaccount")]
    public IActionResult VerifyAccount()
    {
        return View();
    }

    [HttpPost]
    [Route("/verifyaccount")]
    public async Task<IActionResult> VerifyAccount(VerifyAccountViewModel model)
    {
        if (ModelState.IsValid)
        {
            var code = string.Join("", model.Code);

            if(!string.IsNullOrEmpty(code))
            {
                var verifyAccount = new VerifyAccountModel
                {
                    Email = TempData["VerifyAccountEmail"]!.ToString()!,
                    Code = code,
                };

                if(verifyAccount != null)
                {
                    var result = await _http.PostAsJsonAsync(_configuration["Urls:ValidateVerificationCodeUrl"], verifyAccount);

                    if(result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("SignIn", "Auth");
                    }
                }
            }
        }
        return View();
    }
}

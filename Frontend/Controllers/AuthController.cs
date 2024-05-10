using Frontend.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
        }
        return View(model);
    }

    #endregion
}

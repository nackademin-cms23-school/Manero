using Frontend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Frontend.Controllers;

public class ProfileController(HttpClient http, IConfiguration config) : Controller
{
    private readonly HttpClient _http = http;
    private readonly IConfiguration _config = config;

    public IActionResult Index()
    {
        return View("Profile");
    }

    public async Task<IActionResult> Edit()
    {
        var result = await _http.GetAsync("url");
        var responseContent = await result.Content.ReadAsStringAsync();
        EditAccountViewModel? model = JsonConvert.DeserializeObject<EditAccountViewModel>(responseContent);
        return View(model);
    }

    public async Task<IActionResult> EditAccount(EditAccountViewModel model)
    {
        model.UserId = "9f8b99e0-9bc8-4c51-881f-07542689e9ca";


        var response = await _http.PutAsJsonAsync("url", model);

        return RedirectToAction("Edit");

    }
}

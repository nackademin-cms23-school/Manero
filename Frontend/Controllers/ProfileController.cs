﻿using Frontend.Interfaces;
using Frontend.Models;
using Frontend.Services;
using Frontend.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Frontend.Controllers;

[Authorize]
public class ProfileController(IAccountService accountService, HttpClient http, IConfiguration config) : Controller
{
    private readonly IAccountService _accountService = accountService;
    private readonly HttpClient _http = http;
    private readonly IConfiguration _config = config;


    [HttpGet]
    [Route("/profile")]
    public async Task<IActionResult> Index()
    {
        AccountViewModel model = await _accountService.GetAsync(User);
        if (model != null)
        {
            return View(model);
        }
        return null!;

    }

    [HttpGet]
    [Route("/profile/edit")]
    public async Task<IActionResult> AccountDetails()
    {
        AccountViewModel model = await _accountService.GetAsync(User);
        return View(model);
    }

    [HttpPost]
    [Route("/profile/postaccount")]
    public async Task<IActionResult> EditAccount(AccountViewModel form)
    {
        AccountViewModel model = await _accountService.UpdateAsync(form);
        return RedirectToAction("Index");
    }


    [HttpGet]
    [Route("profile/updateprofilepic")]
    public async Task<IActionResult> UpdateProfile(string profileUrl)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        if (!string.IsNullOrEmpty(profileUrl) && !string.IsNullOrEmpty(email))
        {
            var model = new UpdateProfilePicModel
            {
                Email = email,
                ImgUrl = profileUrl
            };

            var result = await _http.PostAsJsonAsync($"https://assignmentaccountprovider.azurewebsites.net/api/UpdateProfilePic?code={_config["Secrets:AccountProvider"]}", model);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("AccountDetails");
            }
        }
        return new BadRequestResult();
    }
}

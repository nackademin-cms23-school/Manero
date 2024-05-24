using Frontend.Interfaces;
using Frontend.Services;
using Frontend.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Frontend.Controllers;

[Authorize]
public class ProfileController(IAccountService accountService) : Controller
{
    private readonly IAccountService _accountService = accountService;


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
}

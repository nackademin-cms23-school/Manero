using Frontend.Interfaces;
using Frontend.Services;
using Frontend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;
public class ProfileController(IAccountService accountService, AddressService addressService) : Controller
{
    private readonly IAccountService _accountService = accountService;
    private readonly AddressService _addressService = addressService;
    private readonly string _userId = "9f8b99e0-9bc8-4c51-881f-07542689e9ca";


    [HttpGet]
    [Route("/profile")]
    public async Task<IActionResult> Index()
    {
        AccountViewModel model = await _accountService.GetAsync(_userId);
        return View(model);
    }

    [HttpGet]
    [Route("/profile/edit")]
    public async Task<IActionResult> Edit()
    {
        AccountViewModel model = await _accountService.GetAsync(_userId);
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

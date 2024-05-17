using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class AccountCreatedController : Controller
{
    public IActionResult AccountCreated()
    {
        return View();
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class DefaultController : Controller
{
    [Route("/")]
    public IActionResult Home()
    {
        return View();
    }
}

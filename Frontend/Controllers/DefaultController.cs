using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class DefaultController : Controller
{
    [Route("/home")]
    public IActionResult Home()
    {
        return View();
    }
}

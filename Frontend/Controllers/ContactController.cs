using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class ContactController : Controller
{
	[Route("/burger")]
	public IActionResult ContactMenu()
    {
        return View();
    }
}

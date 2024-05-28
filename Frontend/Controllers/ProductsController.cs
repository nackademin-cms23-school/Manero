using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class ProductsController : Controller
{
    [Route("/category")]
    public IActionResult Category()
	{
		return View();
	}

    [Route("/product")]
    public IActionResult ProductDescription()
    {
        return View();
    }
}

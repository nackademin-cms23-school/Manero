using Frontend.Models;
using Frontend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class ProductsController : Controller
{
	private readonly HttpClient _httpClient;
	public ProductsController(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}


	[Route("/category")]
    public IActionResult Category()
	{
		return View();
	}

    [Route("/singleProduct")]
    public IActionResult SingleProduct()
    {
        return View();
    }

    [Route("/products")]
	public async Task<IActionResult> Products()
	{
		return View();
	}
}

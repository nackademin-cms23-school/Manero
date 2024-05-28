using Frontend.Models;
using Frontend.ViewModels;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace Frontend.Controllers;

public class ProductsController(HttpClient httpClient) : Controller
{
	private readonly HttpClient _httpClient = httpClient;
	private string _productApiUrl = "https://mhsproducts.azurewebsites.net/api/GetAll?code=b9b60MT2HPX9uzbgAQuuMiwsFiD2Tt08fbd7VEEzO9XrAzFuIJp_ZQ%3D%3D";
	{
		_httpClient = httpClient;
	}
	{
		_httpClient = httpClient;
	}
	{
		_httpClient = httpClient;
	}
	{
		_httpClient = httpClient;
	}
	{
		_httpClient = httpClient;
	}
	{
		_httpClient = httpClient;
	}
	{
		_httpClient = httpClient;
	}
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

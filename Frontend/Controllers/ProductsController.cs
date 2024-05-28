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
        var viewModel = new ProductViewModel();

        try
        {
            var productResponse = await _httpClient.GetAsync(_productApiUrl);

            if (productResponse.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<Product>>(await productResponse.Content.ReadAsStringAsync());
                if (result != null)
                {
                    viewModel.Products = result;
                }
            }
        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return View(viewModel);
    }
}

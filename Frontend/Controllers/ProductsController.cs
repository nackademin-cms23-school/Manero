using Frontend.Models;
using Frontend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend.Controllers;

public class ProductsController(HttpClient httpClient) : Controller
{
	private readonly HttpClient _httpClient = httpClient;
    private readonly string _productApiUrl = "https://maneroproductsfunction.azurewebsites.net/api/GetAllProducts";


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
            Console.Error.WriteLine($"An error occurred while fetching products: {ex.Message}");
        }

        return View(viewModel);
    }
}

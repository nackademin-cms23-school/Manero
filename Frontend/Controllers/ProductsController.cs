using Frontend.Models;
using Frontend.ViewModels;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using static System.Net.WebRequestMethods;

namespace Frontend.Controllers;

public class ProductsController(HttpClient httpClient) : Controller
{
	private readonly HttpClient _httpClient = httpClient;
	private string _productApiUrl = "https://mhsproducts.azurewebsites.net/api/GetAll?code=b9b60MT2HPX9uzbgAQuuMiwsFiD2Tt08fbd7VEEzO9XrAzFuIJp_ZQ%3D%3D";
    private string _singleProductApiUrl = "https://mhsproducts.azurewebsites.net/api/products/{id}?code=BA468kTuQt5FQCqyki9m7j8ahnV-pHZgsS185_rHq9CUAzFuKR2x1Q%3D%3D";
    private string _getProductsByCategories = "https://mhsproducts.azurewebsites.net/api/GetProductsByCategory?code=4-w5CfXd-Ao4LWFdQOILT2Te3reNnlzupM1BjPbmlirvAzFuQ_Uk4A%3D%3D";



    [Route("/category")]
    public async Task<IActionResult> CategoryIndex()
    {
        var viewModel = new ProductViewModel();
        try
        {
            var categoryResponse = await _httpClient.GetAsync(_getProductsByCategories);

            if (categoryResponse.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<CategoryModel>>(await categoryResponse.Content.ReadAsStringAsync());
                if (result != null)
                {
                    viewModel.Categories = result;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return View("Category", viewModel);
    }

    [Route("/products")]
    public async Task<IActionResult> Products(string category)
    {
        var viewModel = new ProductViewModel();

        try
        {
            string apiUrl;

            if (!string.IsNullOrEmpty(category))
            {
                apiUrl = $"{_getProductsByCategories}&category={Uri.EscapeDataString(category)}";
            }
            else
            {
                apiUrl = _productApiUrl;
            }

            var productResponse = await _httpClient.GetAsync(apiUrl);

            if (productResponse.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<List<ProductModel>>(await productResponse.Content.ReadAsStringAsync());
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

    [Route("/products/{id}")]
    public async Task<IActionResult> SingleProduct(string id)
    {
        var viewModel = new ProductViewModel();
        try
        {
            var productResponse = await _httpClient.GetAsync($"{_singleProductApiUrl.Replace("{id}", id)}");

            if (productResponse.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ProductModel>(await productResponse.Content.ReadAsStringAsync());
                if (result != null)
                {
                    viewModel.Product = result;
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

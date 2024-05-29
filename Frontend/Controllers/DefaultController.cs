using Frontend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend.Controllers;

public class DefaultController(HttpClient client) : Controller
{
    private readonly HttpClient _client = client;

    [HttpGet]
    [Route("/home")]

    public async Task <IActionResult> Home()
    {
        var Response = await _client.GetAsync("https://mhsproducts.azurewebsites.net/api/GetAll?code=b9b60MT2HPX9uzbgAQuuMiwsFiD2Tt08fbd7VEEzO9XrAzFuIJp_ZQ%3D%3D");
        var data = await Response.Content.ReadAsStringAsync();
        var products = JsonConvert.DeserializeObject <IEnumerable<HomeProductModel>>(data);
        if (products != null)
        {
            var model = new ProductList
            {

                Bestsellers = products.Where(x=>x.IsBestseller == true).ToList(),
                Features = products.ToList()

            };
            return View(model);
        }
        return View();
    }
    

}

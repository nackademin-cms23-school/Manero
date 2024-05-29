using Frontend.Models;
using Frontend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend.Controllers;

public class WishListController : Controller
{
    private readonly HttpClient _http;
    private readonly IConfiguration _configuration;

    public WishListController(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _configuration = configuration;
    }

    [Route("/wishlist")]
    public async Task<IActionResult> Wishlist()
    {
        var products = new List<HomeProductModel>();
        var email = User.Identity!.Name;
        var wishlistRequest = new WishlistRequest { Email = email! };
        var result = await _http.PostAsJsonAsync(_configuration["Urls:GetWishlist"], wishlistRequest);
        if(result.IsSuccessStatusCode)
        {
            var wr = JsonConvert.DeserializeObject<List<WishlistResponse>>(await result.Content.ReadAsStringAsync());

            if(wr != null)
            {
                foreach(var item in wr)
                {
                    var productResult = await _http.PostAsJsonAsync(_configuration["Urls:ProductProviderUrl"], item.ProductId);
                    if(productResult.IsSuccessStatusCode)
                    {
                        var product = JsonConvert.DeserializeObject<HomeProductModel>(await result.Content.ReadAsStringAsync());
                        if(product != null)
                        {
                            products.Add(product);
                        }
                    }
                }
            }
        }

        var testList = new ProductList
        {
            Features = new List<HomeProductModel>
            {
                new HomeProductModel
                {
                    ProductName = "Byxor",
                    OriginalPrice = 59m
                },
                new HomeProductModel
                {
                    ProductName = "Klänning",
                    OriginalPrice= 899m
                },
                new HomeProductModel
                {
                    ProductName = "T-shirt",
                    OriginalPrice = 500m
                }
            }
        };
        return View(testList);
    }
}

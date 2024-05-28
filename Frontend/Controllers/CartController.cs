using Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class CartController : Controller
{
    [Route("/Cart")]
    public IActionResult Cart()
    {
        return View();
    }

    [HttpPost]
    [Route("/Cart")]
    public async Task<IActionResult> Cart(LineItemModel model)
    {
        if (ModelState.IsValid)
        {
            
        }
        return View();
    }

    [HttpPost]
    [Route("/checkout")]
    public async Task<IActionResult> Checkout(OrderRequest orderRequest)
    {
        if(ModelState.IsValid)
        {
            
        }

        return RedirectToAction("Cart");
    }
}

using Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class CartController : Controller
{
    public IActionResult Cart()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Checkout(OrderRequest orderRequest)
    {
        if(ModelState.IsValid)
        {
            
        }

        return RedirectToAction("Cart");
    }
}

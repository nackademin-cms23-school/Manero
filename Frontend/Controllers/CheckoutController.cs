using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class CheckoutController : Controller
    {
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }
    }
}

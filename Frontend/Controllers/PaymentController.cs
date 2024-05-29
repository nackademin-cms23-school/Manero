using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;



namespace Frontend.Controllers
{
    public class PaymentController(HttpClient http, IConfiguration configuration) : Controller
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly HttpClient _http = http;


        [Route("/Payment")]
        public IActionResult Index()
        {
            return View("Payment");
        }

        [HttpGet]
        [Route("/Add-Card")]
        public IActionResult PaymentMethod()
        {
            return View("Cardinfo");
        }


        [HttpPost]
        public async Task<IActionResult> PostCard(Cardmodel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _http.PostAsJsonAsync("https://cardinfoprovider.azurewebsites.net/api/CardCreater?code=iMos-SVafELbbcuDjl1xqeWuRuhU1HyxmDURj8QhcboPAzFutzCLVg%3D%3D", model);

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Payment");
                }
            }
            return View(model);
        }

}   }

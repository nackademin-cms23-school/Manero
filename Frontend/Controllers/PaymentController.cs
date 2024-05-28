using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;



namespace Frontend.Controllers
{
    public class PaymentController(HttpClient http, IConfiguration configuration) : Controller
    {

        private readonly HttpClient _http = http;
        private readonly IConfiguration _configuration = configuration;


        [Route("/Payment")]
        public IActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCard(Cardmodel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _http.PostAsJsonAsync(_configuration["CardInfoProviderUrl"], model);

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Payment");
                }
            }
            return View(model);
        }
    }

}

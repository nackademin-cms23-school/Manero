using Frontend.Services;
using Frontend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class AddressController(AddressService addressService) : Controller
    {
        private readonly AddressService _addressService = addressService;
        private readonly string _userId = "9f8b99e0-9bc8-4c51-881f-07542689e9ca";

        [HttpGet]
        [Route("address")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AddressViewModel> addresses = await _addressService.GetAllAsync(_userId);
            return View(addresses);
        }

        [HttpGet]
        [Route("address/{id}")]
        public async Task<IActionResult> AddressDetails(string id)
        {
            AddressViewModel address = await _addressService.GetOneAsync(_userId, id);
            return View(address);
        }

        [HttpPost]
        [Route("address/postaddress")]
        public async Task<IActionResult> Update(AddressViewModel form)
        {
            AddressViewModel address = await _addressService.UpdateAsync(form);
            return RedirectToAction("Index");
        }

        [Route("address/create")]
        public IActionResult AddAddress()
        {
            return View();
        }

        [Route("address/delete/{id}/{userId}")]
        public async Task<IActionResult> DeleteAddress(string id, string userId) 
        {
            bool result = await _addressService.DeleteAsync(id, userId);
            if (result)
            {
                return RedirectToAction("Index");
            }
            TempData["StatusMessage"] = "Something went wrong. Please try again.";
            return RedirectToAction("AddressDetails", new { id = id });
        }
    }
}

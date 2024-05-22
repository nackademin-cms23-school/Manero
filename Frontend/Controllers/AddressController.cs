using Frontend.Factories;
using Frontend.Interfaces;
using Frontend.ViewModels.Address;
using Microsoft.AspNetCore.Mvc;


namespace Frontend.Controllers
{
    public class AddressController(IAddressService addressService) : Controller
    {
        private readonly IAddressService _addressService = addressService;
        private readonly string _userId = "9f8b99e0-9bc8-4c51-881f-07542689e9ca";

        [HttpGet]
        [Route("address")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Address> addresses = await _addressService.GetAllAsync(_userId);
            AddressViewModelList viewModels = AddressFactory.Create(addresses);
            return View(viewModels);
        }

        [HttpGet]
        [Route("address/{key}")] 
        public async Task<IActionResult> AddressDetails(string key)
        {
            bool successfullParse = int.TryParse(key, out int keyAsInt);
            if (successfullParse)
            {
                IEnumerable<Address> addresses = await _addressService.GetAllAsync(_userId);
                var address = addresses.ElementAtOrDefault(keyAsInt);

                if (address != null)
                {
                    AddressViewModel viewModel = AddressFactory.Create(await _addressService.GetOneAsync(_userId, address.Id.ToString()), key);
                    if (viewModel != null)
                    {
                        return View(viewModel);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("address/editaddress")]
        public async Task<IActionResult> Update(AddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool successfullParse = int.TryParse(model.Key, out int keyAsInt);
                if (successfullParse)
                {
                    IEnumerable<Address> addresses = await _addressService.GetAllAsync(_userId);
                    var address = addresses.ElementAtOrDefault(keyAsInt);

                    if (address != null!)
                    {
                        var returnedModel = await _addressService.UpdateAsync(AddressFactory.Create(model, _userId, address.Id));
                        if (returnedModel != null!)
                        {
                            return RedirectToAction("Index");
                        }
                        
                    }
                    TempData["StatusMessage"] = "Something went wrong. Please try again";
                }
            }
            return View("AddressDetails", model);
        }

        [Route("address/create")]
        public IActionResult AddAddress()
        {
            return View();  
        }   

        [Route("address/createaddress")]
        public async Task<IActionResult> Create(AddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                AddressViewModel returnedModel = await _addressService.CreateAsync(AddressFactory.Create(model, _userId));
                if ( returnedModel != null)
                {
                    return RedirectToAction("Index");
                }
                TempData["StatusMessage"] = "Something went wrong. Please try again";
                return View("AddAddress", model);
            }
            return View("AddAddress", model);
        }

        [Route("address/delete/{key}")]
        public async Task<IActionResult> DeleteAddress(string key) 
        {
            bool successfullParse = int.TryParse(key, out int keyAsInt);
            if (successfullParse)
            {
                var addresses = await _addressService.GetAllAsync(_userId);
                var address = addresses.ElementAtOrDefault(keyAsInt);

                if (address != null)
                {
                    bool result = await _addressService.DeleteAsync(_userId, address.Id!);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            TempData["StatusMessage"] = "Something went wrong. Please try again.";
            return RedirectToAction("AddressDetails", new { key });
        }
    }
}

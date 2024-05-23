using Frontend.Factories;
using Frontend.Helpers;
using Frontend.Interfaces;
using Frontend.ViewModels.Address;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Frontend.Controllers;


[Authorize]
public class AddressController(IAddressService addressService) : Controller
{
    private readonly IAddressService _addressService = addressService;

    [HttpGet]
    [Route("address")]
    public async Task<IActionResult> Index()
    {
        IEnumerable<Address> addresses = await _addressService.GetAllAsync(User);
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
            IEnumerable<Address> addresses = await _addressService.GetAllAsync(User);
            var address = addresses.ElementAtOrDefault(keyAsInt);

            if (address != null)
            {
                AddressViewModel viewModel = AddressFactory.Create(await _addressService.GetOneAsync(User, address.Id.ToString()), key);
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
                IEnumerable<Address> addresses = await _addressService.GetAllAsync(User);
                var address = addresses.ElementAtOrDefault(keyAsInt);

                if (address != null!)
                {
                    var returnedModel = await _addressService.UpdateAsync(AddressFactory.Create(model, ClaimConvert.GetIdFromUserClaim(User), address.Id));
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
            AddressViewModel returnedModel = await _addressService.CreateAsync(AddressFactory.Create(model, ClaimConvert.GetIdFromUserClaim(User)));
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
            var addresses = await _addressService.GetAllAsync(User);
            var address = addresses.ElementAtOrDefault(keyAsInt);

            if (address != null)
            {
                bool result = await _addressService.DeleteAsync(User, address.Id!);
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

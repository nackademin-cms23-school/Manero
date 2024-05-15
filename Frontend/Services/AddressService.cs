using Frontend.Helpers;
using Frontend.Interfaces;
using Frontend.ViewModels;
using System.Diagnostics;

namespace Frontend.Services;
public class AddressService(HttpClient http, IConfiguration config) : IAddressService
{
    private readonly HttpClient _http = http;
    private readonly IConfiguration _config = config;

    public async Task<IEnumerable<AddressViewModel>> GetAllAsync(string userId)
    {
        try
        {
            var response = await _http.GetAsync($"https://assignmentaddressprovider.azurewebsites.net/api/AddressProvider/{userId}?code={_config["Secrets:AddressProvider"]}");
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<AddressViewModel> addresses = await JsonService.DeserializeToModelAsync<IEnumerable<AddressViewModel>>(response);
                return addresses;
            }
            return null!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return null!;
        }
    }
    public async Task<AddressViewModel> GetOneAsync(string userId, string addressId)
    {
        var response = await _http.GetAsync($"https://assignmentaddressprovider.azurewebsites.net/api/AddressProvider/{userId}/{addressId}?code={_config["Secrets:AddressProvider"]}");
        if (response.IsSuccessStatusCode)
        {
            AddressViewModel address = await JsonService.DeserializeToModelAsync<AddressViewModel>(response);
            return address;
        }
        return null!;
    }
    public async Task<AddressViewModel> UpdateAsync(AddressViewModel form)
    {
        var response = await _http.PutAsJsonAsync($"https://assignmentaddressprovider.azurewebsites.net/api/AddressProvider?code={_config["Secrets:AddressProvider"]}", form);
        if (response.IsSuccessStatusCode)
        {
            AddressViewModel address = await JsonService.DeserializeToModelAsync<AddressViewModel>(response);
            return address;
        }
        return null!;
    }
    public async Task<bool> DeleteAsync(string id, string userId)
    {
        try
        {
            var response = await _http.DeleteAsync($"https://assignmentaddressprovider.azurewebsites.net/api/AddressProvider/{userId}/{id}?code={_config["Secrets:AddressProvider"]}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public async Task<AddressViewModel> CreateAsync(AddressForm form)
    {
        try
        {
            var response = await _http.PostAsJsonAsync($"https://assignmentaddressprovider.azurewebsites.net/api/AddressProvider?code={_config["Secrets:AddressProvider"]}", form);
            if (response.IsSuccessStatusCode)
            {
                AddressViewModel model = await JsonService.DeserializeToModelAsync<AddressViewModel>(response);
                return model;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        return null!;
    }
}

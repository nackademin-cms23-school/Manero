using Frontend.Helpers;
using Frontend.Interfaces;
using Frontend.ViewModels;
using System.Diagnostics;


namespace Frontend.Services;

public class AccountService(HttpClient http, IConfiguration config) : IAccountService
{
    private readonly HttpClient _http = http;
    private readonly IConfiguration _config = config;

    public async Task<AccountViewModel> CreateAsync(AccountViewModel form)
    {
        try
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync($"https://assignmentaccountprovider.azurewebsites.net/api/AccountProvider/?code={_config["Secrets:AccountProvider"]}", form);
            if (response.IsSuccessStatusCode)
            {
                AccountViewModel model = await JsonService.DeserializeToModelAsync<AccountViewModel>(response);
                return model;
            }
            return null!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return null!;
        }
    }
    public async Task<AccountViewModel> GetAsync(string id)
    {
        try
        {
            var response = await _http.GetAsync($"https://assignmentaccountprovider.azurewebsites.net/api/AccountProvider/{id}?code={_config["Secrets:AccountProvider"]}");
            if (response.IsSuccessStatusCode)
            {
                AccountViewModel model = await JsonService.DeserializeToModelAsync<AccountViewModel>(response);
                return model;
            }
            return null!;
        } catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return null!;
        }
    }
    public async Task<AccountViewModel> UpdateAsync(AccountViewModel form)
    {
        try
        {
            var response = await _http.PutAsJsonAsync($"https://assignmentaccountprovider.azurewebsites.net/api/AccountProvider/?code={_config["Secrets:AccountProvider"]}", form);
            if (response.IsSuccessStatusCode)
            {
                AccountViewModel model = await JsonService.DeserializeToModelAsync<AccountViewModel>(response);
                return model;
            }
            return null!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return null!;
        }
    }
    public async Task<bool> DeleteAsync(string id)
    {
        try
        {
            var response = await _http.DeleteAsync($"https://assignmentaccountprovider.azurewebsites.net/api/AccountProvider/{id}?code={_config["Secrets:AccountProvider"]}");
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
}

using Frontend.Services;
using Frontend.ViewModels;

namespace Frontend.Interfaces;

public interface IAccountService
{
    Task<AccountViewModel> CreateAsync(AccountViewModel form);
    Task<AccountViewModel> GetAsync(string id);
    Task<AccountViewModel> UpdateAsync(AccountViewModel account);
    Task<bool> DeleteAsync(string id);
}

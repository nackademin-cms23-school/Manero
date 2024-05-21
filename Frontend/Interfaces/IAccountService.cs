using Frontend.ViewModels;

namespace Frontend.Interfaces;

public interface IAccountService
{
    Task<AccountViewModel> GetAsync(string id);
    Task<AccountViewModel> UpdateAsync(AccountViewModel account);
}

using Frontend.ViewModels;
using System.Security.Claims;

namespace Frontend.Interfaces;

public interface IAccountService
{
    Task<AccountViewModel> GetAsync(ClaimsPrincipal user);
    Task<AccountViewModel> UpdateAsync(AccountViewModel account);
}

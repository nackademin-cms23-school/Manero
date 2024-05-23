using Frontend.ViewModels.Address;
using System.Security.Claims;

namespace Frontend.Interfaces
{
    public interface IAddressService
    { 
        Task<AddressViewModel> CreateAsync(AddressForm form);
        Task<bool> DeleteAsync(ClaimsPrincipal user, string addressId);
        Task<IEnumerable<Address>> GetAllAsync(ClaimsPrincipal user);
        Task<Address> GetOneAsync(ClaimsPrincipal user, string addressId);
        Task<Address> UpdateAsync(Address form);
    }
}

using Frontend.ViewModels.Address;

namespace Frontend.Interfaces
{
    public interface IAddressService
    { 
        Task<AddressViewModel> CreateAsync(AddressForm form);
        Task<bool> DeleteAsync(string userId, string id);
        Task<IEnumerable<Address>> GetAllAsync(string userId);
        Task<Address> GetOneAsync(string userId, string addressId);
        Task<Address> UpdateAsync(Address form);
    }
}

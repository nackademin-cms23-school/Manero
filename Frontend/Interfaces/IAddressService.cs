using Frontend.ViewModels;

namespace Frontend.Interfaces
{
    public interface IAddressService
    { 
        Task<AddressViewModel> CreateAsync(AddressForm form);
        Task<bool> DeleteAsync(string id, string userId);
        Task<IEnumerable<AddressViewModel>> GetAllAsync(string userId);
        Task<AddressViewModel> GetOneAsync(string userId, string addressId);
        Task<AddressViewModel> UpdateAsync(AddressViewModel form);
    }
}

using Frontend.ViewModels.Address;

namespace Frontend.Factories
{
    public class AddressFactory
    {
        public static AddressForm Create(AddressViewModel model, string userId)
        {
            return new AddressForm
            {
                UserId = userId,
                Title = model.Title,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                PostalCode = model.PostalCode,
                City = model.City,
                Country = model.Country,
            };
        }
        public static Address Create(AddressViewModel model, string userId, string addressId)
        {
            return new Address
            {
                Id = addressId,
                UserId = userId,
                Title = model.Title,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                PostalCode = model.PostalCode,
                City = model.City,
                Country = model.Country,
            };
        }
        public static AddressViewModel Create(Address model, string key)
        {
            return new AddressViewModel
            {
                Key = key,
                Title = model.Title,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                PostalCode = model.PostalCode,
                City = model.City,
                Country = model.Country,
            };
        }
        public static AddressViewModelList Create(IEnumerable<Address> models) 
        {
            var addresses = new AddressViewModelList();
            int index = 0;
            foreach (var model in models)
            {
                addresses.Models = addresses.Models.Append(Create(model, index.ToString()));
                index++;
            }
            return addresses;
        }
    }
}

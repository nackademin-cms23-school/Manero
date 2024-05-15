using Frontend.ViewModels;

namespace Frontend.Factories
{
    public class AddressFactory
    {
        public static AddressForm Create(AddressViewModel model)
        {
            return new AddressForm
            {
                UserId = model.UserId,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                PostalCode = model.PostalCode,
                City = model.City,
                Country = model.Country,
            };
        }
    }
}

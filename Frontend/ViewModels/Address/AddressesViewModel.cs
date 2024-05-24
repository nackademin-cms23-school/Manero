namespace Frontend.ViewModels.Address
{
    public class AddressViewModelList
    {
        public IEnumerable<AddressViewModel> Models { get; set; }

        public AddressViewModelList()
        {
            Models = [];
        }
    }
}

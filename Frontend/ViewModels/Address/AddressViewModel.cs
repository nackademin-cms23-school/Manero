namespace Frontend.ViewModels.Address;

public class AddressViewModel
{
    public string? Key { get; set; }
    public string? Title { get; set; }
    public string AddressLine1 { get; set; } = null!;
    public string? AddressLine2 { get; set; }
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
}

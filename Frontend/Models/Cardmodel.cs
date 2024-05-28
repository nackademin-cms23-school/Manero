using System.ComponentModel.DataAnnotations;

namespace Frontend.Models;

public class Cardmodel
{
    [Required(ErrorMessage = "Cardholder name is required")]
    [StringLength(100, ErrorMessage = "Cardholder name cannot be longer than 100 characters")]
    public string CardholderName { get; set; } = null!;

    [Required(ErrorMessage = "Card number is required")]
    //[RegularExpression(@"^\d{16}$", ErrorMessage = "Card number must be exactly 16 digits")]
    public string CardNumber { get; set; } = null!;

    [Required(ErrorMessage = "Expiry date is required")]
    //[RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Expiry date must be in the format MM/YY")]
    public string ExpiryDate { get; set; } = null!;

    [Required(ErrorMessage = "CVV is required")]
    //[RegularExpression(@"^\d{3}$", ErrorMessage = "CVV must be exactly 3 digits")]
    public string CVV { get; set; } = null!;

}

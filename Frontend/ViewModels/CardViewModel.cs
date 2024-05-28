using System.ComponentModel.DataAnnotations;

namespace Frontend.ViewModels;

public class CardViewModel
{
  
 
    [Required]
    [Display(Name = "Cardholder Name", Prompt = "Enter cardholder name")]
    public string CardholderName { get; set; }=null!;

    [Required]
    [Display(Name = "Card Number", Prompt = "Enter card number")]
    [RegularExpression(@"^\d{16}$", ErrorMessage = "A valid 16-digit card number is required")]
    public string CardNumber { get; set; }=null!;

    [Required]
    [Display(Name = "Expiry Date", Prompt = "Enter expiry date (MM/YY)")]
    [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "A valid expiry date (MM/YY) is required")]
    public string ExpiryDate { get; set; }=null!; 

    [Required]
    [Display(Name = "CVV", Prompt = "Enter CVV")]
    [RegularExpression(@"^\d{3}$", ErrorMessage = "A valid 3-digit CVV is required")]
    public string CVV { get; set; } = null!;
    
}

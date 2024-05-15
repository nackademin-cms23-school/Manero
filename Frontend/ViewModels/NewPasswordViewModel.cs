using System.ComponentModel.DataAnnotations;

namespace Frontend.ViewModels;

public class NewPasswordViewModel
{
    [Required]
    [Display(Name = "Password", Prompt = "Enter your password")]
    //[RegularExpression(@"^(?=.[0-9])(?=.[a-z])(?=.[A-Z])(?=.[\W_])(?!.*\s).{8,}$", ErrorMessage = "A valid password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required]
    [Display(Name = "Confirm Password", Prompt = "Please confirm your password")]
    [Compare(nameof(Password))]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;
}

using System.ComponentModel.DataAnnotations;

namespace Frontend.ViewModels;

public class SignUpViewModel
{
    [Required]
    [Display(Name ="First Name", Prompt = "Enter your first name")]
    public string FirstName { get; set; } = null!;

    [Required]
    [Display(Name = "Last Name", Prompt = "Enter your last name")]
    public string LastName { get; set; } = null!;

    [Required]
    [Display(Name = "Email", Prompt = "Enter your email")]
    [RegularExpression(@"^[a-zA-Z0-9.!#$%&'+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?).[a-zA-Z]{2,}$", ErrorMessage = "An valid email address is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;


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

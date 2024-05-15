using System.ComponentModel.DataAnnotations;

namespace Frontend.ViewModels;

public class ForgotPasswordViewModel
{
    [Required]
    [Display(Name = "Email", Prompt = "Enter your email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
}

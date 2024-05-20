using System.ComponentModel.DataAnnotations;

namespace Frontend.ViewModels;

public class ResetForgotPasswordViewModel
{
    [Required]
    [Display(Name ="New Password", Prompt ="Enter your new password")]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; } = null!;

    [Required]
    [Display(Name = "Confirm Password", Prompt = "Please confirm your new password")]
    [Compare(nameof(NewPassword))]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set;} = null!;
}

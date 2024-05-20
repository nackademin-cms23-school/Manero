using System.ComponentModel.DataAnnotations;

namespace Frontend.ViewModels;

public class VerifyAccountViewModel
{
    [Required]
    public string[] Code { get; set; } = new string[5];
}

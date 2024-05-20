namespace Frontend.Models;

public class ForgotPasswordValidateModel
{
    public string Email { get; set; } = null!;
    public string Code { get; set; } = null!;
}

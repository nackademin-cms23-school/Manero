﻿namespace Frontend.Models;

public class VerifyAccountModel
{
    public string Email { get; set; } = null!;
    public string Code { get; set; } = null!;
}

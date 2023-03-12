using System.ComponentModel.DataAnnotations;

namespace Library.Service.DTOs.Account;

public class LoginUserDTO
{
    [Required]
    public string Mobile { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public bool RememberMe { get; set; }
}
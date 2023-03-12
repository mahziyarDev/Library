using System.ComponentModel.DataAnnotations;

namespace Library.Service.DTOs.Account;

public class RegisterUserDTO
{
    [Required]
    public string FullName { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Mobile { get; set; }


    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    // [Compare("Password", ErrorMessage = "کلمه های عبور باهم مغایرت دارند")]
    [Compare(nameof(Password), ErrorMessage = "کلمه های عبور باهم مغایرت دارند")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}
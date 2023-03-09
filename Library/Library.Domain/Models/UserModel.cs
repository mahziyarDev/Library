using System.ComponentModel.DataAnnotations;
using Library.Common.BaseModel;
using Microsoft.AspNetCore.Identity;

namespace Library.Domain.Models;

public class UserModel : IdentityUser<Guid>
{
    /// <summary>نام کاربر</summary>
    [MaxLength(250)]
    [Required]
    public string FullName { get; set; }

    [MaxLength(250)]
    [Required]
    public string Mobile { get; set; }

}
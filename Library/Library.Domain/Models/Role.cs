using Microsoft.AspNetCore.Identity;

namespace Library.Domain.Models;

public class Role : IdentityRole<Guid>
{
    public string Name { get; set; }
}
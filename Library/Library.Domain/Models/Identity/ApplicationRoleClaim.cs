using Microsoft.AspNetCore.Identity;

namespace Library.Domain.Models.Identity;

public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
{
    public virtual ApplicationRole Role { get; set; }
}
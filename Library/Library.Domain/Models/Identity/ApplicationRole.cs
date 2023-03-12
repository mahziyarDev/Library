using Microsoft.AspNetCore.Identity;

namespace Library.Domain.Models.Identity;

public class ApplicationRole : IdentityRole<Guid>
{
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
}
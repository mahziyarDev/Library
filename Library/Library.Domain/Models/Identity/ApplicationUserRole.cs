using Microsoft.AspNetCore.Identity;

namespace Library.Domain.Models.Identity;

public class ApplicationUserRole : IdentityUserRole<Guid>
{
    public virtual ApplicationUser User { get; set; }
    public virtual ApplicationRole Role { get; set; }
}
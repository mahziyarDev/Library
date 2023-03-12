using Microsoft.AspNetCore.Identity;

namespace Library.Domain.Models.Identity;

public class ApplicationUserLogin : IdentityUserLogin<Guid>
{
    public virtual ApplicationUser User { get; set; }
}
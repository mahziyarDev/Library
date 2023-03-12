using Microsoft.AspNetCore.Identity;

namespace Library.Domain.Models.Identity;

public class ApplicationUserToken : IdentityUserToken<Guid>
{
    public virtual ApplicationUser User { get; set; }
}
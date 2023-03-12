using Microsoft.AspNetCore.Identity;

namespace Library.Domain.Models.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FullName { get; set; }
    public int Age { get; set; }

    public virtual ICollection<ApplicationUserClaim> Claims { get; set; }
    public virtual ICollection<ApplicationUserLogin> Logins { get; set; }
    public virtual ICollection<ApplicationUserToken> Tokens { get; set; }
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
}
using Library.Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Domain.FluentApi.IdentityConfiguration;

public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {

        builder.Property(user => user.Email).HasMaxLength(260);
        
        builder.HasMany(e => e.Claims)
            .WithOne(e => e.User)
            .HasForeignKey(uc => uc.UserId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasMany(e => e.Logins)
            .WithOne(e => e.User)
            .HasForeignKey(ul => ul.UserId)
            .IsRequired();

        builder.HasMany(e => e.Tokens)
            .WithOne(e => e.User)
            .HasForeignKey(ut => ut.UserId)
            .IsRequired();

        builder.HasMany(e => e.UserRoles)
            .WithOne(e => e.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();
    }
}
using Library.Domain.FluentApi.IdentityConfiguration;
using Library.Domain.Models;
using Library.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

namespace Library.Domain.Context;

public class LibraryDataContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>
{
    public LibraryDataContext(DbContextOptions<LibraryDataContext> options) : base(options)
    {

    }
    
    public DbSet<BookModel> Books { get; set; }
    public DbSet<BorrowedBookModel> BorrowedBook { get; set; }
    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<BookCategoryModel> BookCategory { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
        // {
        //     relationship.DeleteBehavior = DeleteBehavior.Restrict;
        // }




        base.OnModelCreating(builder);

        // builder.Entity<ApplicationUser>(b =>
        // {
        //     b.ToTable("Users");
        //     b.Property(user => user.Email).HasMaxLength(260);
        //     // Each User can have many UserClaims
        //     b.HasMany(e => e.Claims)
        //         .WithOne(e => e.User)
        //         .HasForeignKey(uc => uc.UserId)
        //         .IsRequired();
        //
        //     // Each User can have many UserLogins
        //     b.HasMany(e => e.Logins)
        //         .WithOne(e => e.User)
        //         .HasForeignKey(ul => ul.UserId)
        //         .IsRequired();
        //
        //     // Each User can have many UserTokens
        //     b.HasMany(e => e.Tokens)
        //         .WithOne(e => e.User)
        //         .HasForeignKey(ut => ut.UserId)
        //         .IsRequired();
        //
        //     // Each User can have many entries in the UserRole join table
        //     b.HasMany(e => e.UserRoles)
        //         .WithOne(e => e.User)
        //         .HasForeignKey(ur => ur.UserId)
        //         .IsRequired();
        // });
        //
        // builder.Entity<ApplicationRole>(b =>
        // {
        //     b.ToTable("Roles");
        //     // Each Role can have many entries in the UserRole join table
        //     b.HasMany(e => e.UserRoles)
        //         .WithOne(e => e.Role)
        //         .HasForeignKey(ur => ur.RoleId)
        //         .IsRequired();
        //
        //     // Each Role can have many associated RoleClaims
        //     b.HasMany(e => e.RoleClaims)
        //         .WithOne(e => e.Role)
        //         .HasForeignKey(rc => rc.RoleId)
        //         .IsRequired();
        // });

        builder.ApplyConfiguration(new ApplicationUserConfig());
        builder.ApplyConfiguration(new ApplicationRoleConfig());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
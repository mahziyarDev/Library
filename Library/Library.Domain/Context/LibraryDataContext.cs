using Library.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Domain.Context;

public class LibraryDataContext : IdentityDbContext<IdentityUser>
{
    public LibraryDataContext(DbContextOptions<LibraryDataContext> options) : base(options)
    {

    }
    
    public DbSet<UserModel> Users { get; set; }
    public DbSet<BookModel> Books { get; set; }
    public DbSet<BorrowedBookModel> BorrowedBook { get; set; }
    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<BookCategoryModel> BookCategory { get; set; }



}

using Library.Common.PersianIdentityError;
using Library.Domain.Context;
using Library.Domain.Models.Identity;
using Library.IOC;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Service

DependencyContainer.RegisterService(builder.Services);
// Add services to the container.
builder.Services.AddControllersWithViews();

#endregion


#region DataBaseConfig

builder.Services.AddDbContext<LibraryDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryConnection"));
});

#endregion

#region Identity

builder.Services.AddIdentity<ApplicationUser,ApplicationRole>(option =>
    {
        option.User.RequireUniqueEmail = true;
        option.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        //signin
        option.SignIn.RequireConfirmedEmail = false;
        option.SignIn.RequireConfirmedPhoneNumber = true;


        //password
        option.Password.RequireUppercase = false;
        option.Password.RequireLowercase = true;
        option.Password.RequireDigit = true;
        option.Password.RequiredUniqueChars = 0;
        option.Password.RequireNonAlphanumeric = false;


        //Lockout
        option.Lockout.AllowedForNewUsers = false;
        option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
        option.Lockout.MaxFailedAccessAttempts = 3;


    })
    .AddEntityFrameworkStores<LibraryDataContext>()
    .AddDefaultTokenProviders()
    .AddErrorDescriber<PersianIdentityError>();
builder.Services.ConfigureApplicationCookie(option =>
{
    //اگر کاربر به یک بخش دسترسی نداشت به آدرس زیرهدایت میشود بهتر است به صفحه اصلی هدایت بشه
    option.AccessDeniedPath = "/";
    option.LoginPath = "/Login";
    option.LogoutPath = "/Logout";
    option.Cookie.HttpOnly = true;
    option.ExpireTimeSpan = TimeSpan.FromDays(3);
});


#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// app.GlobalException();
app.Run();

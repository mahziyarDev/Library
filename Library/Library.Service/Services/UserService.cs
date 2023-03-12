using Library.Common.OperationResult;
using Library.Domain.Context;
using Library.Domain.Models.Identity;
using Library.Service.DTOs.Account;
using Library.Service.DTOs.Admin.User;
using Library.Service.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.Service.Services;

public class UserService : IUserService
{
    private readonly LibraryDataContext _db;
    private readonly UserManager<ApplicationUser> _userManage;
    public UserService(LibraryDataContext db, UserManager<ApplicationUser> userManage)
    {
        _db = db;
        _userManage = userManage;
    }

    #region User Management

    public async Task<OperationResult<UserIndexDTO>> GetUser()
    {
        var users = await _db.Users.ToListAsync();

        var result = new UserIndexDTO
        {
            Users = users.Select(m => new UserDTO()
            {
                Id = m.Id,
                Email = m.Email,
                FullName = m.FullName, 
                Mobile= m.PhoneNumber,

            }).ToList()
        };

        return new OperationResult<UserIndexDTO>("0", true, OperationResultMessage.Success, result);
    }

    public async Task<OperationResult<UserDTO>> GetUserById(Guid id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user == null)
            return new OperationResult<UserDTO>("1", false, OperationResultMessage.NotFound);

        var userDto = new UserDTO()
        {
            Email = user.Email,
            FullName = user.FullName,
            Id = user.Id,
            Mobile = user.PhoneNumber,
        };

        return new OperationResult<UserDTO>("0", true, OperationResultMessage.Success, userDto);
    }

    public async Task<OperationResult> UpdateUser(UserDTO manage)
    {
        var user = await _db.Users.FirstOrDefaultAsync(m => m.Id == manage.Id);
        if (user == null)
            return new OperationResult("1", false, OperationResultMessage.NotFound);

        user.PhoneNumber = manage.Mobile;
        user.Email = manage.Email;
        user.FullName = manage.FullName;
        await _db.SaveChangesAsync();

        return new OperationResult("0", true, OperationResultMessage.Success);
    }

    #endregion

    #region Account
    public async Task<OperationResult<List<string>>> RegisterUser(RegisterUserDTO registerDto)
    {
        var user = new ApplicationUser()
        {
            Email = registerDto.Email,
            EmailConfirmed = true,
            PhoneNumber = registerDto.Mobile,
            PhoneNumberConfirmed = true,
            FullName = registerDto.FullName,
            UserName = registerDto.UserName
        };

        var createUser = await _userManage.CreateAsync(user, registerDto.Password);
        if (createUser.Succeeded)
            return new OperationResult<List<string>>("0", true, OperationResultMessage.Success);

        var errors = createUser.Errors.Select(m => m.Description).ToList();

        return new OperationResult<List<string>>("1", false, OperationResultMessage.RegisterError,errors);
    }

    public async Task<OperationResult<string>> Login(string phoneNumber)
    {
        var user = await _db.Users.FirstOrDefaultAsync(m => m.PhoneNumber ==phoneNumber);
        if (user == null)
            return new OperationResult<string>("1", false, OperationResultMessage.LoginError);
        return new OperationResult<string>("0", true, OperationResultMessage.Success, user.UserName);
    }
    #endregion

    public async ValueTask DisposeAsync()
    {
        await _db.DisposeAsync();
    }
}
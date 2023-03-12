using Library.Common.OperationResult;
using Library.Service.DTOs.Account;
using Library.Service.DTOs.Admin.User;

namespace Library.Service.IServices;

public interface IUserService:IAsyncDisposable
{
    #region User Management

    Task<OperationResult<UserIndexDTO>> GetUser();
    Task<OperationResult<UserDTO>> GetUserById(Guid id);
    Task<OperationResult> UpdateUser(UserDTO update);

    #endregion

    #region RegisterAndLogin

    Task<OperationResult<List<string>>> RegisterUser(RegisterUserDTO registerUserDto);
    Task<OperationResult<string>> Login(string phoneNumber);

    #endregion
}
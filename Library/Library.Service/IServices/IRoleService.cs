using Library.Common.OperationResult;
using Library.Service.DTOs.Admin.Role;

namespace Library.Service.IServices;

public interface IRoleService:IAsyncDisposable
{
    Task<OperationResult<RoleIndexDTO>> GetRoles();
    Task<OperationResult<RoleDTO>> GetRole(Guid id);
    Task<OperationResult> UpdateRole(RoleDTO roleDto);
    Task<OperationResult> DeleteRole(Guid id);
}
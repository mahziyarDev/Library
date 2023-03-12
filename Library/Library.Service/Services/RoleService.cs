using Library.Common.OperationResult;
using Library.Domain.Context;
using Library.Domain.Models.Identity;
using Library.Service.DTOs.Admin.Role;
using Library.Service.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.Service.Services;

public class RoleService :IRoleService
{
    private readonly LibraryDataContext _db;
    private readonly RoleManager<ApplicationRole> _roleManager;

    public RoleService(LibraryDataContext db, RoleManager<ApplicationRole> roleManager)
    {
        _db = db;
        _roleManager = roleManager;
    }

    public async ValueTask DisposeAsync()
    {
        await _db.DisposeAsync();
    }

    public async Task<OperationResult<RoleIndexDTO>> GetRoles()
    {
        var roles = await _db.Roles.ToListAsync();
        return new OperationResult<RoleIndexDTO>(
            "0",
            true,
            OperationResultMessage.Success,
            new RoleIndexDTO
            {
                Roles = roles.Select(m =>
                    new RoleDTO
                    {
                        Id = m.Id,
                        Title = m.Name
                    }).ToList()
            });
    }

    public async Task<OperationResult<RoleDTO>> GetRole(Guid id)
    {
        var role = await _db.Roles.FirstOrDefaultAsync(m => m.Id == id);
        if (role == null)
            return new OperationResult<RoleDTO>("1", false, OperationResultMessage.NotFound);
        return new OperationResult<RoleDTO>("0", true, OperationResultMessage.Success, new RoleDTO
        {
            Id = role.Id,
            Title = role.Name
        });
    }

    public async Task<OperationResult> UpdateRole(RoleDTO roleDto)
    {
        if (roleDto.Id.HasValue)
        {
            var role = await _db.Roles.FirstOrDefaultAsync(m => m.Id == roleDto.Id);
            if (role == null)
                return new OperationResult("1", false, OperationResultMessage.NotFound);
            role.Name = roleDto.Title;
            if (!(await _roleManager.UpdateAsync(role)).Succeeded)
                return new OperationResult("1", false, OperationResultMessage.Error);
        }
        else
        {
            var role = new ApplicationRole{ Name = roleDto.Title };
            
            if (!(await _roleManager.CreateAsync(role)).Succeeded)
                return new OperationResult("1", false, OperationResultMessage.Error);
        }
        await _db.SaveChangesAsync();
        return new OperationResult("0", true, OperationResultMessage.Success);
    }

    public async Task<OperationResult> DeleteRole(Guid id)
    {
        var role = await _db.Roles.FirstOrDefaultAsync(m => m.Id == id);
        if (role == null)
            return new OperationResult("1", false, OperationResultMessage.NotFound);
        _db.Remove(role);
        await _db.SaveChangesAsync();
        return new OperationResult("0", true, OperationResultMessage.Success);
    }

}
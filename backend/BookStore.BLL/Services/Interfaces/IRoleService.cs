using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.Entities;
using BookStore.DTO.DTOs;
using BookStore.Shared.Response;

namespace BookStore.BLL.Services.Interfaces
{
    public interface IRoleService
    {
        Task<Result<IEnumerable<RoleDTO>>> GetAllRoles();
        Task<Result> CreateRole(RoleDTO roleDTO);
        Task<Result> UpdateRole(UpdateRoleDTO updateRole);
        Task<Result> DeleteRole(long id);
    }
}

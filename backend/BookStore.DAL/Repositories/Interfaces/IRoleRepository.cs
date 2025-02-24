using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.Entities;
using BookStore.DTO.DTOs;
using BookStore.DAL.Repositories.Interfaces;

namespace BookStore.DAL.Repositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<IEnumerable<RoleDTO>> GetAllRoleExtendedAsync();
        Task CreateRoleAsync(RoleDTO newRole);
        Task UpdateRoleAsync(UpdateRoleDTO updateRole);
    }
}

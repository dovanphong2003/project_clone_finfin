using BookStore.DAL.Entities;
using BookStore.DAL.Modal;
using BookStore.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<UserExtendedRole>> GetAllExtendedAsync();
        Task<IEnumerable<string>> GetAllEmailsAsync();
    }
}

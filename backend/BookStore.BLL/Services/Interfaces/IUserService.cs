using BookStore.DAL.Entities;
using BookStore.DAL.Modal;
using BookStore.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<Result<IEnumerable<User>>> GetAllUsers();
        Task<Result<IEnumerable<UserExtendedRole>>> GetAllUsersxtendedRole();
        Task<Result> CreateUser(User user);
        Task<Result> UpdateUser(User user, Dictionary<string, object> FieldsToUpdate, long id);
        Task<Result> DeleteUser(long id);
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.Entities;
using BookStore.Shared.Response;

namespace BookStore.BLL.Services.Interfaces
{
    public interface IPermissionService
    {
        Task<Result<IEnumerable<Permission>>> GetAllPermissions();
        Task<Result> CreatePermission(Permission permission);
        Task<Result> UpdatePermission(Permission permission, Dictionary<string, object> FieldsToUpdate, long id);
        Task<Result> DeletePermission(long id);
    }
}

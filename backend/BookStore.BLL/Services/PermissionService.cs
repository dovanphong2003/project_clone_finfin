using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.BLL.Services.Interfaces;
using BookStore.DAL.Entities;
using BookStore.DAL.UnitOfWorks;
using BookStore.Shared.Response;

namespace BookStore.BLL.Services
{
        public class PermissionService : IPermissionService
        {
            private readonly IUnitOfWork _unitOfWork;

            public PermissionService(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<IEnumerable<Permission>>> GetAllPermissions()
            {
                var permissions = await _unitOfWork.PermissionRepository.GetAllAsync();
                return Result.Success(permissions);
            }

            public async Task<Result> CreatePermission(Permission permission)
            {
                try
                {
                    await _unitOfWork.PermissionRepository.AddAsync(permission);

                    // only commit, data add to database.
                    _unitOfWork.Commit();
                    return Result.Success();

                }
                catch (Exception ex)
                {
                    return Result.Failure(ex.Message);
                }
            }

            public async Task<Result> UpdatePermission(Permission permission, Dictionary<string, object> FieldsToUpdate, long id)
            {
                try
                {
                    await _unitOfWork.PermissionRepository.UpdateAsync(permission, FieldsToUpdate, id);

                    _unitOfWork.Commit();
                    return Result.Success();
                }
                catch (Exception ex)
                {
                    return Result.Failure(ex.Message);
                }
            }

            public async Task<Result> DeletePermission(long id)
            {
                try
                {
                    await _unitOfWork.PermissionRepository.DeleteAsync(id);
                    _unitOfWork.Commit();
                    return Result.Success();
                }
                catch (Exception ex)
                {
                    return (Result.Failure(ex.Message));
                }
            }

        }
}

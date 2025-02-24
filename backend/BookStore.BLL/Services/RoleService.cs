using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.BLL.Services.Interfaces;
using BookStore.DAL.Entities;
using BookStore.DAL.UnitOfWorks;
using BookStore.DTO.DTOs;
using BookStore.Shared.Response;

namespace BookStore.BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<RoleDTO>>> GetAllRoles()
        {

            var Roles = await _unitOfWork.RoleRepository.GetAllRoleExtendedAsync();
            return Result.Success(Roles);



        }

        public async Task<Result> CreateRole(RoleDTO roleDTO)
        {
            try
            {
                await _unitOfWork.RoleRepository.CreateRoleAsync(roleDTO);

                // only commit, data add to database.
                _unitOfWork.Commit();
                return Result.Success();

            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> UpdateRole(UpdateRoleDTO updateRole)
        {
            try
            {
                await _unitOfWork.RoleRepository.UpdateRoleAsync(updateRole);

                _unitOfWork.Commit();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> DeleteRole(long id)
        {
            try
            {
                await _unitOfWork.RoleRepository.DeleteAsync(id);
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

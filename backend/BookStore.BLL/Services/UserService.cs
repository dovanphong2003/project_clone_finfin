using BookStore.BLL.Services.Interfaces;
using BookStore.DAL.Entities;
using BookStore.DAL.Modal;
using BookStore.DAL.UnitOfWorks;
using BookStore.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<User>>> GetAllUsers()
        {

                var Users = await _unitOfWork.UserRepository.GetAllAsync();
                return Result.Success(Users);
            
            

        }
        public async Task<Result<IEnumerable<UserExtendedRole>>> GetAllUsersxtendedRole()
        {
            var Users = await _unitOfWork.UserRepository.GetAllExtendedAsync();
            return Result.Success(Users);
        }
        public async Task<Result> CreateUser(User user)
        {
            try
            {
                var emails = await _unitOfWork.UserRepository.GetAllEmailsAsync();

                // Kiểm tra nếu email đã tồn tại
                if (emails.Contains(user.email))
                {
                    return Result.Failure("Email đã được sử dụng. Vui lòng chọn email khác.");
                }
                if (!string.IsNullOrEmpty(user.password))
                {
                    // Mã hóa password bằng Base64 (có thể giải mã)
                    var plainTextBytes = Encoding.UTF8.GetBytes(user.password);
                    user.password = Convert.ToBase64String(plainTextBytes);
                }
                await _unitOfWork.UserRepository.AddAsync(user);

                // only commit, data add to database.
                _unitOfWork.Commit();
                return Result.Success();

            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> UpdateUser(User User, Dictionary<string, object> fieldsToUpdate, long id)
        {
            try
            {
                var password = fieldsToUpdate["password"]?.ToString(); // Chuyển thành chuỗi nếu cần
                if (!string.IsNullOrEmpty(password))
                {
                    var plainTextBytes = Encoding.UTF8.GetBytes(password);
                    fieldsToUpdate["password"] = Convert.ToBase64String(plainTextBytes);
                }
                await _unitOfWork.UserRepository.UpdateAsync(User, fieldsToUpdate, id);

                _unitOfWork.Commit();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> DeleteUser(long id)
        {
            try
            {
                await _unitOfWork.UserRepository.DeleteAsync(id);
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

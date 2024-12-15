using BookStore.DAL.Entities;
using BookStore.DAL.UnitOfWorks;
using BookStore.DTO.DTOs;
using BookStore.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            return Result.Success(categories);
        }

        public async Task<Result> CreateCategory(Category category)
        {
            try
            {
             await _unitOfWork.CategoryRepository.AddAsync(category);

            // only commit, data add to database.
                _unitOfWork.Commit();
            return Result.Success();

            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> UpdateCategory(Category category, Dictionary<string, object> FieldsToUpdate, long id)
        {
            try
            {
                await _unitOfWork.CategoryRepository.UpdateAsync(category, FieldsToUpdate, id);
                
                _unitOfWork.Commit();
                return Result.Success();
            }
            catch ( Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> DeleteCategory(long id)
        {
            try
            {
                await _unitOfWork.CategoryRepository.DeleteAsync(id);
                _unitOfWork.Commit();
                return Result.Success();
            }
            catch(Exception ex)
            {
                return (Result.Failure(ex.Message));
            }
        }

    }
}

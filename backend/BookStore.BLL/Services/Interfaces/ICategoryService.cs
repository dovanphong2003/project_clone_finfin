using BookStore.DAL.Entities;
using BookStore.DTO.DTOs;
using BookStore.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Services
{
    public interface ICategoryService
    {
        Task<Result<IEnumerable<Category>>> GetAllCategories();
        Task<Result> CreateCategory(Category category);
        Task<Result> UpdateCategory(Category category, Dictionary<string, string> FieldsToUpdate, long id);
        Task<Result> DeleteCategory(long id);

    }
}

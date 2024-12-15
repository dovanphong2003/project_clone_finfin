using BookStore.DAL.Entities;
using BookStore.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Services
{
    public interface IAuthorService
    {
        Task<Result<IEnumerable<Author>>> GetAllAuthors();
        Task<Result> CreateAuthor(Author Author);
        Task<Result> UpdateAuthor(Author Author, Dictionary<string, object> FieldsToUpdate, long id);
        Task<Result> DeleteAuthor(long id);

    }
}

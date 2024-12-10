using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.Entities;
using BookStore.DTO.DTOs;
using BookStore.Shared.Response;
namespace BookStore.BLL.Services
{
    public interface IBookService
    {
        Task<Result<IEnumerable<Book>>> GetAllBooks();

        Task<Result<IEnumerable<BookExtendedDTO>>> GetAllBooksExtended();
        Task<Result> CreateBook(Book book);
        Task<Result> UpdateBook(Book book, Dictionary<string, string> FieldsToUpdate, long id);
        Task<Result> DeleteBook(long id);
    }
}

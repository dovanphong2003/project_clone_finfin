using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DTO.DTOs;
using BookStore.Shared.Response;
namespace BookStore.BLL.Services
{
    public interface IBookService
    {
        Task<Result<IEnumerable<BookDTO>>> GetAllBooks();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.UnitOfWorks;
using BookStore.DTO.DTOs;
using BookStore.Shared.Response;
namespace BookStore.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<BookDTO>>> GetAllBooks()
        {
            var books = await _unitOfWork.BookRepository.GetAllAsync();
            var bookDTOs = books.Select(b => new BookDTO { id = b.id, title = b.title });
            return Result.Success(bookDTOs);
        }
    }

}

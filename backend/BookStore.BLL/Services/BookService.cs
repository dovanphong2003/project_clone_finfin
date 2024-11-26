using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.UnitOfWorks;
using BookStore.DTO.DTOs;
namespace BookStore.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            var books = _unitOfWork.BookRepository.GetAll();
            return books.Select(b => new BookDTO { id = b.id, title = b.title, author = b.author });
            //        return new List<BookDTO>
            //{
            //    new BookDTO { Id = 123456, Title = "sach hay viet nam", Author = "sach hay viet nam" },
            //    new BookDTO { Id = 555555, Title = "sach hay viet nam", Author = "sach hay viet nam" },
            //    new BookDTO { Id = 888888, Title = "sach hay viet nam", Author = "sach hay viet nam" },
            //};
        }
    }

}

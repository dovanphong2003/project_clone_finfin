using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DTO.DTOs;
namespace BookStore.BLL.Services
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetAllBooks();
    }
}

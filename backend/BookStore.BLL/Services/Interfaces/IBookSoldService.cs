using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.Entities;
using BookStore.DAL.Modal;
using BookStore.DTO.DTOs;
using BookStore.Shared.Response;
namespace BookStore.BLL.Services
{
    public interface IBookSoldService
    {
        Task<Result<IEnumerable<Order>>> GetAllBookSolds();

        Task<Result<IEnumerable<BookSoldExtendedDTO>>> GetAllBookSoldsExtended();
        Task<Result> CreateBookSold(AddOrder addOrder);
        Task<Result> UpdateBookSold(Order order, Dictionary<string, object> FieldsToUpdate, long id);
        Task<Result> DeleteBookSold(long id);
    }
}

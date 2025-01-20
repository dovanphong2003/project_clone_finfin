using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.BLL.Services.Interfaces;
using BookStore.DAL.Entities;
using BookStore.DAL.Modal;
using BookStore.DAL.UnitOfWorks;
using BookStore.DTO.DTOs;
using BookStore.Shared.Response;
namespace BookStore.BLL.Services
{
    public class BookSoldService : IBookSoldService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookSoldService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<Order>>> GetAllBookSolds()
        {

            var BookSolds = await _unitOfWork.BookSoldRepository.GetAllAsync();
            return Result.Success(BookSolds);



        }

        public async Task<Result<IEnumerable<BookSoldExtendedDTO>>> GetAllBookSoldsExtended()
        {
            var BookSoldsExtended = await _unitOfWork.BookSoldRepository.GetAllOrdersExtendedAsync();
            return Result.Success(BookSoldsExtended);
        }

        public async Task<Result> CreateBookSold(AddOrder addOrder)
        {
            try
            {
                // Lưu đối tượng BookSold vào cơ sở dữ liệu
                await _unitOfWork.BookSoldRepository.CreateOrderAsync(addOrder);
               _unitOfWork.Commit();
                return Result.Success();

            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> UpdateBookSold(Order order, Dictionary<string, object> FieldsToUpdate, long id)
        {
            try
            {
                await _unitOfWork.BookSoldRepository.UpdateAsync(order, FieldsToUpdate, id);

                _unitOfWork.Commit();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> DeleteBookSold(long id)
        {
            try
            {
                await _unitOfWork.BookSoldRepository.DeleteAsync(id);
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

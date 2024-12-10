using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.BLL.Services.Interfaces;
using BookStore.DAL.Entities;
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

        public async Task<Result<IEnumerable<Book>>> GetAllBooks()
        {

            var Books = await _unitOfWork.BookRepository.GetAllAsync();
            return Result.Success(Books);



        }

        public async Task<Result<IEnumerable<BookExtendedDTO>>> GetAllBooksExtended()
        {
            var BooksExtended = await _unitOfWork.BookRepository.GetAllExtendedAsync();
            return Result.Success(BooksExtended);
        }

        public async Task<Result> CreateBook(Book book)
        {
            try
            {
                await _unitOfWork.BookRepository.AddAsync(book);

                // only commit, data add to database.
                _unitOfWork.Commit();
                return Result.Success();

            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> UpdateBook(Book book, Dictionary<string, string> FieldsToUpdate, long id)
        {
            try
            {
                await _unitOfWork.BookRepository.UpdateAsync(book, FieldsToUpdate, id);

                _unitOfWork.Commit();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> DeleteBook(long id)
        {
            try
            {
                await _unitOfWork.BookRepository.DeleteAsync(id);
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

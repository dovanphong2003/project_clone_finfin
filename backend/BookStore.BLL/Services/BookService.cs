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

        public async Task<Result<IEnumerable<SelectOptionsOfBookDTO>>> GetAllSelectOptionsOfBook()
        {
            var OptionsBook = await _unitOfWork.BookRepository.GetAllOptionsOfBookAsync();
            return Result.Success(OptionsBook);
        }

        public async Task<Result> CreateBook(BookCreateDTO bookDTO)
        {
            try
            {

                var book = new Book
                {
                    book_id = bookDTO.book_id,
                    ISBN = bookDTO.ISBN,
                    title = bookDTO.title,
                    price = bookDTO.price,
                    author_id = bookDTO.author_id,
                    publisher_id = bookDTO.publisher_id,
                    category_id = bookDTO.category_id,
                    stock_quantity = bookDTO.stock_quantity,
                    status = bookDTO.status,
                    createdBy = bookDTO.createdBy,
                    ReceiveDate = bookDTO.ReceiveDate,
                    // Cập nhật URL ảnh đã upload
                    imageUrl = bookDTO.imageUrl,  
                    content_data = null, 
                    isDeleted = false
                };

                // Lưu đối tượng book vào cơ sở dữ liệu
                await _unitOfWork.BookRepository.AddAsync(book);
               _unitOfWork.Commit();
                return Result.Success();

            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> UpdateBook(Book book, Dictionary<string, object> FieldsToUpdate, long id)
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

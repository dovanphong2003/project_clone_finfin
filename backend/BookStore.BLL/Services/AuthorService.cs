using BookStore.DAL.Entities;
using BookStore.DAL.UnitOfWorks;
using BookStore.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<Author>>> GetAllAuthors()
        {
            var authors = await _unitOfWork.AuthorRepository.GetAllAsync();
            return Result.Success(authors);
        }

        public async Task<Result> CreateAuthor(Author Author)
        {
            try
            {
                await _unitOfWork.AuthorRepository.AddAsync(Author);

                // only commit, data add to database.
                _unitOfWork.Commit();
                return Result.Success();

            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> UpdateAuthor(Author Author, Dictionary<string, string> FieldsToUpdate, long id)
        {
            try
            {
                await _unitOfWork.AuthorRepository.UpdateAsync(Author, FieldsToUpdate, id);

                _unitOfWork.Commit();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> DeleteAuthor(long id)
        {
            try
            {
                await _unitOfWork.AuthorRepository.DeleteAsync(id);
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

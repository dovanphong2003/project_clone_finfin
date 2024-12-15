using BookStore.BLL.Services.Interfaces;
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
    public class PublisherService : IPublisherService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PublisherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<Publisher>>> GetAllPublishers()
        {

                var publishers = await _unitOfWork.PublisherRepository.GetAllAsync();
                return Result.Success(publishers);
            
            

        }

        public async Task<Result> CreatePublisher(Publisher publisher)
        {
            try
            {
                await _unitOfWork.PublisherRepository.AddAsync(publisher);

                // only commit, data add to database.
                _unitOfWork.Commit();
                return Result.Success();

            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> UpdatePublisher(Publisher publisher, Dictionary<string, object> FieldsToUpdate, long id)
        {
            try
            {
                await _unitOfWork.PublisherRepository.UpdateAsync(publisher, FieldsToUpdate, id);

                _unitOfWork.Commit();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> DeletePublisher(long id)
        {
            try
            {
                await _unitOfWork.PublisherRepository.DeleteAsync(id);
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

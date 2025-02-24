using BookStore.DAL.Entities;
using BookStore.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Services.Interfaces
{
    public interface IPublisherService
    {
        Task<Result<IEnumerable<Publisher>>> GetAllPublishers();
        Task<Result> CreatePublisher(Publisher publisher);
        Task<Result> UpdatePublisher(Publisher publisher, Dictionary<string, object> FieldsToUpdate, long id);
        Task<Result> DeletePublisher(long id);
    }
}

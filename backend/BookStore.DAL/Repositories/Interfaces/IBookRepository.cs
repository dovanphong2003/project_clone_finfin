using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.Entities;
using BookStore.DAL.Repositories.Interfaces;
using BookStore.DTO.DTOs;
namespace BookStore.DAL.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<BookExtendedDTO>> GetAllExtendedAsync();
        Task<IEnumerable<SelectOptionsOfBookDTO>> GetAllOptionsOfBookAsync();
    }

}

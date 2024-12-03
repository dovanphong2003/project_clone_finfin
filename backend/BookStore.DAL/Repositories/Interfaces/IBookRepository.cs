using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.Entities;
using BookStore.DAL.Repositories.Interfaces;
namespace BookStore.DAL.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        
    }

}

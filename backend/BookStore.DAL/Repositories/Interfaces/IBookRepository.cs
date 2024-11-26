using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.Entities;
namespace BookStore.DAL.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
    }

}

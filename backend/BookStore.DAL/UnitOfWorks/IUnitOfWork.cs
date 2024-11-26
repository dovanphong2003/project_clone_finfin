using BookStore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository BookRepository { get; }
        void Commit();    // Xác nhận transaction
        void Rollback();  // Hủy bỏ transaction
    }

}

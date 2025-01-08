using BookStore.DAL.Repositories;
using BookStore.DAL.Repositories.Interfaces;
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
        ICategoryRepository CategoryRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IPublisherRepository PublisherRepository { get; }
        IPermissionRepository PermissionRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        void Commit();    // Xác nhận transaction
        void Rollback();  // Hủy bỏ transaction
    }

}

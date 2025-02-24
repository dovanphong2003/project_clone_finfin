using BookStore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; // Sử dụng MySQL
using BookStore.DataAccess.DataContext;
using BookStore.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BookStore.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MySqlConnection _connection; // Thay đổi SqlConnection thành MySqlConnection
        private readonly MySqlTransaction _transaction; // Thay đổi SqlTransaction thành MySqlTransaction
        private bool _disposed = false;

        public IBookRepository BookRepository { get; }
        public IBookSoldRepository BookSoldRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IAuthorRepository AuthorRepository { get; }
        public IPublisherRepository PublisherRepository { get; }

        public IPermissionRepository PermissionRepository { get; }

        public IRoleRepository RoleRepository { get; }

        public IUserRepository UserRepository { get; }

        public UnitOfWork(DbContext dbContext, IConfiguration configuration)
        {
            _connection = dbContext.GetConnection(); // MySQL connection
            _connection.Open();
            _transaction = _connection.BeginTransaction(); // MySQL transaction
    
            // Khởi tạo các repository
            BookRepository = new BookRepository(_connection, _transaction, configuration);
            BookSoldRepository = new BookSoldRepository(_connection, _transaction);
            CategoryRepository = new CategoryRepository(_connection, _transaction);
            AuthorRepository = new AuthorRepository(_connection, _transaction);
            PublisherRepository = new PublisherRepository(_connection, _transaction);
            PermissionRepository = new PermissionRepository(_connection, _transaction);
            RoleRepository = new RoleRepository(_connection, _transaction);
            UserRepository = new UserRepository(_connection, _transaction);
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit(); // Commit transaction MySQL
            }
            catch
            {
                _transaction.Rollback(); // Rollback transaction MySQL
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback(); // Rollback transaction MySQL
            Dispose();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _transaction.Dispose(); // Dispose transaction MySQL
                _connection.Dispose(); // Dispose connection MySQL
                _disposed = true;
            }
        }
    }
}

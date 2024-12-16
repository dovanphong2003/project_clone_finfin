
using BookStore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using BookStore.DataAccess.DataContext;
using BookStore.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BookStore.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;
        private bool _disposed = false;

        public IBookRepository BookRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IAuthorRepository AuthorRepository { get; }
        public IPublisherRepository PublisherRepository { get; }

        public IPermissionRepository PermissionRepository { get; }

        public UnitOfWork(DbContext dbContext, IConfiguration configuration)
        {
            _connection = dbContext.GetConnection();
            _connection.Open();
            _transaction = _connection.BeginTransaction();

            BookRepository = new BookRepository(_connection, _transaction, configuration);
            CategoryRepository = new CategoryRepository(_connection, _transaction);
            AuthorRepository = new AuthorRepository(_connection, _transaction);
            PublisherRepository = new PublisherRepository(_connection, _transaction);
            PermissionRepository = new PermissionRepository(_connection, _transaction);
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }
        public void Dispose()
        {
            if (!_disposed)
            {
                _transaction.Dispose();
                _connection.Dispose();
                _disposed = true;
            }
        }


    }

}

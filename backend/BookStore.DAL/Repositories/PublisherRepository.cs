using BookStore.DAL.Entities;
using BookStore.DAL.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BookStore.DAL.Repositories
{
    public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;

        public PublisherRepository(SqlConnection connection, SqlTransaction transaction) : base(connection, transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }
    }
}

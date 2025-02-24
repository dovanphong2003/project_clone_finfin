using BookStore.DAL.Repositories.Interfaces;
using MySql.Data.MySqlClient; // Sử dụng MySQL
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.Entities;
namespace BookStore.DAL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly MySqlConnection _connection;
        private readonly MySqlTransaction _transaction;

        public CategoryRepository(MySqlConnection connection, MySqlTransaction transaction) : base(connection, transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }
    }
}

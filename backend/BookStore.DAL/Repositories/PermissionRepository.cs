using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.Entities;
using BookStore.DAL.Repositories.Interfaces;
using MySql.Data.MySqlClient; // Sử dụng MySQL

namespace BookStore.DAL.Repositories
{
    internal class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        private readonly MySqlConnection _connection;
        private readonly MySqlTransaction _transaction;

        public PermissionRepository(MySqlConnection connection, MySqlTransaction transaction) : base(connection, transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }
   }
}

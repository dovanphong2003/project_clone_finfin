using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.Entities;
using BookStore.DAL.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace BookStore.DAL.Repositories
{
    internal class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;

        public PermissionRepository(SqlConnection connection, SqlTransaction transaction) : base(connection, transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }
   }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BookStore.DAL.Entities;
using Microsoft.Data.SqlClient;
namespace BookStore.DAL.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;

        public BookRepository(SqlConnection connection, SqlTransaction transaction) : base(connection, transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

    }

}

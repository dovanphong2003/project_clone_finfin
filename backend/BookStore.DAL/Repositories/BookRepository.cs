using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BookStore.DAL.Entities;
using Microsoft.Data.SqlClient;
namespace BookStore.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;

        public BookRepository(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var books = new List<Book>();
            var query = "SELECT * FROM Book";

            try
            {
                using (var command = new SqlCommand(query, _connection))
                {
                    command.Transaction = _transaction;
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var book = new Book
                            {
                                id = reader.GetInt64(0),          // Cột 0: Id
                                title = reader.GetString(1),      // Cột 1: Title
                               
                            };
                            books.Add(book);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Xử lý lỗi liên quan đến SQL
                Console.WriteLine($"Lỗi SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác
                Console.WriteLine($"Lỗi: {ex.Message}");
            }

            return books;
        }

    }

}

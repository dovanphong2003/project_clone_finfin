using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DAL.Entities;
using MySql.Data.MySqlClient;
using BookStore.DTO.DTOs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BookStore.DAL.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly MySqlConnection _connection;
        private readonly MySqlTransaction _transaction;
        private readonly IConfiguration _configuration;

        public BookRepository(MySqlConnection connection, MySqlTransaction transaction, IConfiguration configuration) : base(connection, transaction)
        {
            _connection = connection;
            _transaction = transaction;
            _configuration = configuration;
        }

        public async Task<IEnumerable<BookExtendedDTO>> GetAllExtendedAsync()
        {
            var items = new List<BookExtendedDTO>();
            var query = @"
                SELECT 
                    b.book_id, b.ISBN, b.title, b.price, b.author_id, a.name AS author_name, 
                    b.publisher_id, p.name AS publisher_name, b.category_id, c.name AS category_name, 
                    b.imageUrl, b.stock_quantity, b.content_data, b.status, 
                    b.ReceiveDate, b.updatedAt, b.isDeleted, b.createdBy, b.updatedBy, b.deleteBy
                FROM Book b
                INNER JOIN Author a ON b.author_id = a.author_id
                INNER JOIN Publisher p ON b.publisher_id = p.publisher_id
                INNER JOIN Category c ON b.category_id = c.category_id
                WHERE b.isDeleted = 0";
            
            try
            {
                using (var command = new MySqlCommand(query, _connection, _transaction))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var item = new BookExtendedDTO
                        {
                        book_id = reader.GetInt64(reader.GetOrdinal("book_id")),
                        ISBN = reader.IsDBNull(reader.GetOrdinal("ISBN")) ? null : reader.GetString(reader.GetOrdinal("ISBN")),
                        title = reader.GetString(reader.GetOrdinal("title")),
                        price = (long)reader.GetDecimal(reader.GetOrdinal("price")),
                        author_id = reader.GetInt64(reader.GetOrdinal("author_id")),
                        author_name = reader.GetString(reader.GetOrdinal("author_name")),
                        publisher_id = reader.GetInt64(reader.GetOrdinal("publisher_id")),
                        publisher_name = reader.GetString(reader.GetOrdinal("publisher_name")),
                        category_id = reader.GetInt64(reader.GetOrdinal("category_id")),
                        category_name = reader.GetString(reader.GetOrdinal("category_name")),
                        imageUrl = reader.GetString(reader.GetOrdinal("imageUrl")),
                        stock_quantity = reader.GetInt32(reader.GetOrdinal("stock_quantity")),
                        content_data = reader.IsDBNull(reader.GetOrdinal("content_data")) ? null : reader.GetString(reader.GetOrdinal("content_data")),
                        status = reader.GetBoolean(reader.GetOrdinal("status")),
                        ReceiveDate = reader.GetDateTime(reader.GetOrdinal("ReceiveDate")),
                        updatedAt = reader.IsDBNull(reader.GetOrdinal("updatedAt")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("updatedAt")),
                        isDeleted = reader.GetBoolean(reader.GetOrdinal("isDeleted")),
                        createdBy = reader.GetInt64(reader.GetOrdinal("createdBy")),
                        updatedBy = reader.IsDBNull(reader.GetOrdinal("updatedBy")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("updatedBy")),
                        deleteBy = reader.IsDBNull(reader.GetOrdinal("deleteBy")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("deleteBy"))
                        };
                        items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi từ Repository: " + ex.Message, ex);
            }
            return items;
        }

        public async Task<IEnumerable<SelectOptionsOfBookDTO>> GetAllOptionsOfBookAsync()
        {
            var options = new List<SelectOptionsOfBookDTO>();
            var query = @"
                SELECT 'author' AS type, author_id AS id, name FROM Author
                UNION
                SELECT 'category' AS type, category_id AS id, name FROM Category
                UNION
                SELECT 'publisher' AS type, publisher_id AS id, name FROM Publisher";

            try
            {
                using (var command = new MySqlCommand(query, _connection, _transaction))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    var authorList = new List<SelectOptionDTO>();
                    var categoryList = new List<SelectOptionDTO>();
                    var publisherList = new List<SelectOptionDTO>();
                    
                    while (await reader.ReadAsync())
                    {
var type = reader.GetString(reader.GetOrdinal("type"));
var id = reader.GetInt64(reader.GetOrdinal("id"));
var name = reader.GetString(reader.GetOrdinal("name"));


                        var selectOption = new SelectOptionDTO { Id = id, Name = name };

                        if (type == "author") authorList.Add(selectOption);
                        else if (type == "category") categoryList.Add(selectOption);
                        else if (type == "publisher") publisherList.Add(selectOption);
                    }
                    
                    options.Add(new SelectOptionsOfBookDTO { Authors = authorList, Categories = categoryList, Publishers = publisherList });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi từ Repository: " + ex.Message, ex);
            }
            return options;
        }
    }
}

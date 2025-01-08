using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BookStore.DAL.Entities;
using Microsoft.Data.SqlClient;
using BookStore.DTO.DTOs;
using Microsoft.Extensions.Configuration;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;
namespace BookStore.DAL.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;
        private readonly IConfiguration _configuration;

        public BookRepository(SqlConnection connection, SqlTransaction transaction, IConfiguration configuration) : base(connection, transaction)
        {
            _connection = connection;
            _transaction = transaction;
            _configuration = configuration; 
        }
        public async Task<IEnumerable<BookExtendedDTO>> GetAllExtendedAsync()
        {
            var items = new List<BookExtendedDTO>();

            // Câu truy vấn SQL để lấy tất cả thông tin từ bảng Book và các trường name từ Author, Publisher, Category
            var query = @"
        SELECT 
            b.book_id, 
            b.title, 
            b.price,
            b.author_id, 
            a.name AS author_name, 
            b.publisher_id, 
            p.name AS publisher_name, 
            b.category_id, 
            c.name AS category_name, 
            b.imageUrl, 
            b.stock_quantity, 
            b.content_data, 
            b.status, 
            b.ReceiveDate, 
            b.updatedAt, 
            b.isDeleted, 
            b.createdBy, 
            b.updatedBy, 
            b.deleteBy
        FROM Book b
        INNER JOIN Author a ON b.author_id = a.author_id
        INNER JOIN Publisher p ON b.publisher_id = p.publisher_id
        INNER JOIN Category c ON b.category_id = c.category_id
        WHERE b.isDeleted = 0";  // Điều kiện lọc sách chưa bị xóa

            try
            {
                using (var command = new SqlCommand(query, _connection, _transaction))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            // Ánh xạ kết quả đọc từ SqlDataReader vào DTO
                            var item = new BookExtendedDTO
                            {
                                book_id = reader.GetInt64(reader.GetOrdinal("book_id")),
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
                SELECT 
                    'author' AS type, 
                    author_id AS id, 
                    name AS name
                FROM Author
                UNION
                SELECT 
                    'category' AS type, 
                    category_id AS id, 
                    name AS name
                FROM Category
                UNION
                SELECT 
                    'publisher' AS type, 
                    publisher_id AS id, 
                    name AS name
                FROM Publisher";


            try
            {
                using (var command = new SqlCommand(query, _connection, _transaction))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        // Danh sách để chứa các lựa chọn cho tác giả, thể loại và nhà xuất bản
                        var authorList = new List<SelectOptionDTO>();
                        var categoryList = new List<SelectOptionDTO>();
                        var publisherList = new List<SelectOptionDTO>();

                        // Đọc dữ liệu và ánh xạ vào DTO
                        while (await reader.ReadAsync())
                        {
                            var type = reader.GetString(reader.GetOrdinal("type"));  // Lấy cột 'type' để phân biệt

                            var id = reader.GetInt64(reader.GetOrdinal("id"));  // Lấy id
                            var name = reader.GetString(reader.GetOrdinal("name"));  // Lấy name

                            var selectOption = new SelectOptionDTO
                            {
                                Id = id,
                                Name = name
                            };

                            // Phân loại vào các danh sách dựa vào loại (type)
                            if (type == "author")
                            {
                                authorList.Add(selectOption);
                            }
                            else if (type == "category")
                            {
                                categoryList.Add(selectOption);
                            }
                            else if (type == "publisher")
                            {
                                publisherList.Add(selectOption);
                            }
                        }

                        // Tạo đối tượng SelectOptionsOfBookDTO và thêm vào danh sách options
                        var option = new SelectOptionsOfBookDTO
                        {
                            Authors = authorList,
                            Categories = categoryList,
                            Publishers = publisherList
                        };

                        options.Add(option);  // Thêm vào danh sách kết quả trả về
                    }
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

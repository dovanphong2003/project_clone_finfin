using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BookStore.DAL.Entities;
using Microsoft.Data.SqlClient;
using BookStore.DTO.DTOs;
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
        public async Task<IEnumerable<BookExtendedDTO>> GetAllExtendedAsync()
        {
            var items = new List<BookExtendedDTO>();

            // Câu truy vấn SQL để lấy tất cả thông tin từ bảng Book và các trường name từ Author, Publisher, Category
            var query = @"
        SELECT 
            b.book_id, 
            b.title, 
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
            b.coupon_id, 
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
                                author_id = reader.GetInt64(reader.GetOrdinal("author_id")),
                                author_name = reader.GetString(reader.GetOrdinal("author_name")),
                                pulisher_id = reader.GetInt64(reader.GetOrdinal("publisher_id")),
                                publisher_name = reader.GetString(reader.GetOrdinal("publisher_name")),
                                category_id = reader.GetInt64(reader.GetOrdinal("category_id")),
                                category_name = reader.GetString(reader.GetOrdinal("category_name")),
                                imageUrl = reader.GetString(reader.GetOrdinal("imageUrl")),
                                stock_quantity = reader.GetInt32(reader.GetOrdinal("stock_quantity")),
                                content_data = reader.IsDBNull(reader.GetOrdinal("content_data")) ? null : reader.GetString(reader.GetOrdinal("content_data")),
                                status = reader.GetBoolean(reader.GetOrdinal("status")),
                                coupon_id = reader.IsDBNull(reader.GetOrdinal("coupon_id")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("coupon_id")),
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


    }

}

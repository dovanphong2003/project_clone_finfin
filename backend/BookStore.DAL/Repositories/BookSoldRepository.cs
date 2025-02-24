using BookStore.DAL.Repositories.Interfaces;
using MySql.Data.MySqlClient; // Sử dụng MySQL
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DAL.Entities;
using BookStore.DTO.DTOs;
using BookStore.DAL.Modal;
namespace BookStore.DAL.Repositories
{
    public class BookSoldRepository : GenericRepository<Order>, IBookSoldRepository
    {
        private readonly MySqlConnection _connection;
        private readonly MySqlTransaction _transaction;

        public BookSoldRepository(MySqlConnection connection, MySqlTransaction transaction) : base(connection, transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }
        public async Task<IEnumerable<BookSoldExtendedDTO>> GetAllOrdersExtendedAsync()
        {
            var items = new List<BookSoldExtendedDTO>();

            // Câu truy vấn SQL để lấy dữ liệu từ bảng Order và các thông tin liên quan
            var query = @"
    SELECT 
        o.order_id,
        o.user_id,
        o.status,
        o.order_date,
        o.createdAt,
        o.updatedAt,
        o.isDeleted,
        o.cart_id,
        o.shippingAddress,
        o.paymentMethod,
        o.seller,
        s.user_id AS seller_user_id,
        s.name AS seller_name,
        s.email AS seller_email,
        s.age AS seller_age,
        s.gender AS seller_gender,
        s.role_id AS seller_role_id
    FROM [Order] o
    LEFT JOIN [User] s ON o.seller = s.user_id
    WHERE o.isDeleted = 0"; // Lọc các đơn hàng chưa bị xóa

            try
            {
                using (var command = new MySqlCommand(query, _connection, _transaction))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            // Ánh xạ kết quả đọc từ SqlDataReader vào DTO
                            var item = new BookSoldExtendedDTO
                            {
                                order_id = reader.GetInt64(reader.GetOrdinal("order_id")),
                                user_id = reader.IsDBNull(reader.GetOrdinal("user_id")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("user_id")),
                                status = reader.GetString(reader.GetOrdinal("status")),
                                order_date = reader.GetDateTime(reader.GetOrdinal("order_date")),
                                createdAt = reader.GetDateTime(reader.GetOrdinal("createdAt")),
                                updatedAt = reader.IsDBNull(reader.GetOrdinal("updatedAt")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("updatedAt")),
                                isDeleted = reader.GetBoolean(reader.GetOrdinal("isDeleted")),
                                cart_id = reader.IsDBNull(reader.GetOrdinal("cart_id")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("cart_id")),
                                shippingAddress = reader.IsDBNull(reader.GetOrdinal("shippingAddress")) ? null : reader.GetString(reader.GetOrdinal("shippingAddress")),
                                paymentMethod = reader.GetString(reader.GetOrdinal("paymentMethod")),
                                seller = reader.IsDBNull(reader.GetOrdinal("seller")) ? (long?)null : reader.GetInt64(reader.GetOrdinal("seller")),

                                // Ánh xạ thông tin của người bán nếu tồn tại
                                infoSeller = reader.IsDBNull(reader.GetOrdinal("seller_user_id")) ? null : new SellerInfo
                                {
                                    user_id = reader.GetInt64(reader.GetOrdinal("seller_user_id")),
                                    name = reader.GetString(reader.GetOrdinal("seller_name")),
                                    email = reader.GetString(reader.GetOrdinal("seller_email")),
                                    age = reader.GetByte(reader.GetOrdinal("seller_age")),
                                    gender = reader.GetString(reader.GetOrdinal("seller_gender")),
                                    role_id = reader.GetInt64(reader.GetOrdinal("seller_role_id"))
                                }
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
       public async Task CreateOrderAsync(AddOrder order)
{
    // Query để chèn dữ liệu vào Cart
    var queryCart = @"
DECLARE @cartId bigint;
SET @cartId = CAST((RAND() * 9000000000 + 1000000000) AS bigint);

INSERT INTO Cart (cart_id, createdAt)
VALUES (@cartId, @createdAt);

SELECT @cartId;";  // Trả về cart_id đã tạo

    // Query để chèn dữ liệu vào Item
    var queryItem = @"
INSERT INTO Item (cart_id, book_id, quantity, createdAt)
VALUES (@cart_id, @book_id, @quantity, @createdAt);";

    // Query để chèn dữ liệu vào Order
    var queryOrder = @"
INSERT INTO [Order] (order_id, cart_id, status, order_date, createdAt, updatedAt, isDeleted, paymentMethod, seller)
VALUES (@order_id, @cart_id, @status, @order_date, @createdAt, @updatedAt, @isDeleted, @paymentMethod, @seller);";

    try
    {
        // 1. Tạo Cart và lấy cart_id
        long cartId;
        using (var command = new MySqlCommand(queryCart, _connection, _transaction))
        {
            command.Parameters.AddWithValue("@createdAt", order.createdAt);

            cartId = (long)await command.ExecuteScalarAsync();
        }

        // 2. Thêm các mục Item vào Cart
        foreach (var item in order.data)
        {
            using (var command = new MySqlCommand(queryItem, _connection, _transaction))
            {
                command.Parameters.AddWithValue("@cart_id", cartId);
                command.Parameters.AddWithValue("@book_id", item.book.book_id);
                command.Parameters.AddWithValue("@quantity", item.quantity);
                command.Parameters.AddWithValue("@createdAt", DateTime.UtcNow);

                await command.ExecuteNonQueryAsync();
            }
        }

        // 3. Tạo Order liên kết với Cart
        using (var command = new MySqlCommand(queryOrder, _connection, _transaction))
        {
                    command.Parameters.AddWithValue("@order_id", order.order_id);
                    command.Parameters.AddWithValue("@cart_id", cartId);
            command.Parameters.AddWithValue("@status", "Hoàn Thành");
            command.Parameters.AddWithValue("@order_date", DateTime.UtcNow);
            command.Parameters.AddWithValue("@createdAt", DateTime.UtcNow);
            command.Parameters.AddWithValue("@updatedAt", DateTime.UtcNow);
            command.Parameters.AddWithValue("@isDeleted", false);
            command.Parameters.AddWithValue("@paymentMethod", "thanh toán trực tiếp");
            command.Parameters.AddWithValue("@seller", order.createdBy);

            await command.ExecuteNonQueryAsync();
        }

        // Commit transaction
        _transaction.Commit();
    }
    catch (Exception ex)
    {
        // Rollback transaction nếu có lỗi
        _transaction.Rollback();
        throw new Exception("Lỗi khi thực hiện các thao tác trong transaction: " + ex.Message, ex);
    }
}


        }
    }

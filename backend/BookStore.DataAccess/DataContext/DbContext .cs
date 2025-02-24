using MySql.Data.MySqlClient; // Dùng thư viện của MySQL
using Microsoft.Extensions.Configuration;
using System;

namespace BookStore.DataAccess.DataContext
{
    public class DbContext
    {
        private readonly string _connectionString;
    
        public DbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        
        }

        public MySqlConnection GetConnection() // Sử dụng MySqlConnection thay vì SqlConnection
        {
            return new MySqlConnection(_connectionString);
        }

        // Phương thức kiểm tra kết nối
        public string TestConnection()
        {
            using (var connection = GetConnection()) // Mở kết nối MySQL
            {
                try
                {
                    connection.Open(); // Cố gắng mở kết nối
                    return "trueeeeeee"; // Nếu kết nối thành công, trả về true
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu kết nối không thành công
                    Console.WriteLine($"Error connecting to MySQL: {ex.Message}");
                    return "falseeeeee"; // Nếu kết nối thất bại, trả về false
                }
            }
        }
    }
}

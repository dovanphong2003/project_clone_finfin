
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
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
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }
}

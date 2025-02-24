using BookStore.DataAccess.DataContext;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient; // Sử dụng MySQL
namespace BookStore.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            // Đăng ký DbContext
            services.AddSingleton<DbContext>();
            services.AddSingleton<MySqlConnection>();
            return services;
        }
    }

}

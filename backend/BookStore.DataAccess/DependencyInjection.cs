using BookStore.DataAccess.DataContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;
namespace BookStore.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            // Đăng ký DbContext
            services.AddSingleton<DbContext>();
            services.AddSingleton<SqlConnection>();
            return services;
        }
    }
}

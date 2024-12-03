using BookStore.BLL.Services;
using BookStore.DAL.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBussinessLogicLayer(this IServiceCollection services)
        {
            // Đăng ký Repositories
            //services.AddScoped<IBookRepository, BookRepository>();

            // Đăng ký UnitOfWork
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}

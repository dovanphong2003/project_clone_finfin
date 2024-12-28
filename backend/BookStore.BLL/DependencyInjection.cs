using BookStore.BLL.Services;
using BookStore.BLL.Services.Interfaces;
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
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IRoleService, RoleService>();

            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using BookStore.DAL.UnitOfWorks;
using BookStore.DAL.Repositories;

namespace BookStore.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

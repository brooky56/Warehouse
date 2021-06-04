using DataModel.Entity.EntityContext;
using DataModel.Repository;
using DataModel.Repository.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace DataModel
{
    public static class Dependencies
    {
        /// <summary>
        /// Регистрирует репозитории
        /// </summary>
        /// <param name="services">The services.</param>
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IBaseRepository, BaseDecorator>();
        }

        /// <summary>
        /// Регистрирует контекст
        /// </summary>
        /// <param name="services">The services.</param>
        public static void RegisterDataContext(IServiceCollection services)
        {
            services.AddScoped<IDataBaseContext>(provider => provider.GetService<DataBaseContext>());
        }
    }
}

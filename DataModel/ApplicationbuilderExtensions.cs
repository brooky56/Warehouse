using System.Linq;
using DataModel.Entity.EntityContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataModel
{
    public static class ApplicationbuilderExtensions
    {
        public static IApplicationBuilder SeedMainData(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<DataBaseContext>();
            context.Database.EnsureCreated();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            context.SeedMainData();

            return app;
        }
    }
}

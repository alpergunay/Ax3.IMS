using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ax3.IMS.DataAccess.EntityFramework
{
    public static class DbContextExtensions
    {
        public static void InitializeContext<TContext>(this IServiceProvider container)
            where TContext : BaseDbContext<TContext>
        {
            using (var scope = container.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<TContext>();
                {
#if !DEBUG
                    context.Database.EnsureCreated();
#else
                    context.Database.Migrate();
#endif
                }
            }
        }
    }
}
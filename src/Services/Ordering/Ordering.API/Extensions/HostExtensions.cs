using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host,
            Action<TContext, IServiceProvider> seeder, int? retry = 0) where TContext : DbContext
        {

        }
    }
}

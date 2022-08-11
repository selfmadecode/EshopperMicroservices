using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class SeedOrder
    {
        public static async Task SeedOrder(OrderContext context, ILogger<SeedOrder> logger)
        {
            if (!context.Orders.Any())
            {
                var newOrders = new List<Order>()
                {
                    
                };
                await context.Orders.AddRangeAsync(newOrders);
                await context.SaveChangesAsync();
            }

           
        }
    }
}

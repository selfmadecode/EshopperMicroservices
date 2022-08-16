using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class SeedOrder
    {
        public static async Task SeedOrderAsync(OrderContext context, ILogger<SeedOrder> logger)
        {
            if (!context.Orders.Any())
            {
                var newOrders = new List<Order>()
                {
                    new Order
                    {
                        UserName = "swn",
                        FirstName = "Test",
                        LastName = "Orders",
                        EmailAddress = "kentekz61@yopmail.com",
                        AddressLine = "Valley waters",
                        Country = "Nigeria",
                        TotalPrice = 350
                    },
                    new Order
                    {
                        UserName = "swn",
                        FirstName = "Test1",
                        LastName = "Orders1",
                        EmailAddress = "kentekz61@yopmail.com",
                        AddressLine = "Valley waters",
                        Country = "Nigeria",
                        TotalPrice = 350
                    }
                };

                await context.Orders.AddRangeAsync(newOrders);
                await context.SaveChangesAsync();

                logger.LogInformation("Seeding orders");
            }           
        }
    }
}

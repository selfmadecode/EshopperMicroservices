using Shopping.Aggregator.Models;
using System;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public class BasketService : IBasketService
    {
        public Task<BasketModel> GetBasket(string userName)
        {
            throw new NotImplementedException();
        }
    }
}

using AspnetRunBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public class BasketService : IBasketService
    {
        public Task CheckOutBasket(BasketCheckoutModel model)
        {
            throw new NotImplementedException();
        }

        public Task<BasketModel> GetBasket(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<BasketModel> UpdateBasket(BasketModel model)
        {
            throw new NotImplementedException();
        }
    }
}

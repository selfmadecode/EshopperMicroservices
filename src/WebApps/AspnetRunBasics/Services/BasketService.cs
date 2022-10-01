using AspnetRunBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _client;
        public BasketService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
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

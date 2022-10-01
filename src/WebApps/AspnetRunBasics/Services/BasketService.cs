using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    /// <summary>
    /// The urls being called are defined in the gateway, the gateway then redirects the request
    /// to the actual endpoint configured on the DownstreamPathTemplate  
    /// Check OcelotApiGw
    /// </summary>
    public class BasketService : IBasketService
    {
        private readonly HttpClient _client;
        public BasketService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task CheckOutBasket(BasketCheckoutModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketModel> GetBasket(string userName)
        {
            var response = await _client.GetAsync($"/Basket/{userName}");
            return await response.ReadContentAs<BasketModel>();
        }

        public async Task<BasketModel> UpdateBasket(BasketModel model)
        {
            throw new NotImplementedException();
        }
    }
}

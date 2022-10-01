using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;
        public CatalogService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public Task<CatalogModel> CreateCatalog(CatalogModel product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalog()
        {
            // Call /Catalog on the gateway which will redirect to catalog api
            var response = await _client.GetAsync("/Catalog");
            return await response.ReadContentAs<List<CatalogModel>>();
        }

        
    }
}

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
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;
        public CatalogService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<CatalogModel> CreateCatalog(CatalogModel model)
        {
            var response = await _client.PostAsJson($"/Catalog", model);

            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<CatalogModel>();
            }

            throw new Exception("Something went wrong!");
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalog()
        {
            // Call /Catalog on the gateway which will redirect to catalog api
            var response = await _client.GetAsync("/Catalog");
            return await response.ReadContentAs<List<CatalogModel>>();
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string categoryName)
        {
            var response = await _client.GetAsync($"/Catalog/GetProductByCategory/{categoryName}");
            return await response.ReadContentAs<List<CatalogModel>>();
        }

        public async Task<CatalogModel> GetCatalog(string id)
        {
            var response = await _client.GetAsync($"/Catalog/{id}");
            return await response.ReadContentAs<CatalogModel>();
        }
    }
}

using Catalog.API.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        private readonly CatalogDbConfig _catalogDbConfig;

        public CatalogContext(IOptions<CatalogDbConfig> catalogDbConfig)
        {
            _catalogDbConfig = catalogDbConfig.Value;
            var client = new MongoClient(_catalogDbConfig.ConnectionString); // connect to the db
            var database = client.GetDatabase(_catalogDbConfig.DatabaseName); // returns the db if found, if not it creates it

            Products = database.GetCollection<Product>(_catalogDbConfig.CollectionName);

            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}

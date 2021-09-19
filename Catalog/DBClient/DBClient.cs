using Catalog.Entities;
using Catalog.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.DBClient
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Item> _items;

        public DbClient(IOptions<MongoDbConfig> mongoDbConfig)
        {
            var client = new MongoClient(mongoDbConfig.Value.CONNECTION_STRING);
            var database = client.GetDatabase(mongoDbConfig.Value.Database_Name);
            _items = database.GetCollection<Item>(mongoDbConfig.Value.Collection_Name);
        }

        public IMongoCollection<Item> GetCollection() => _items;
    }
}

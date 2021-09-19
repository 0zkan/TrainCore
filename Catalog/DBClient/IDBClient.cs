using Catalog.Entities;
using MongoDB.Driver;

namespace Catalog.DBClient
{
    public interface IDbClient
    {
        IMongoCollection<Item> GetCollection();
    }
}

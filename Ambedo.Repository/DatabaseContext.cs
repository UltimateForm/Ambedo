using Ambedo.Models;
using Ambedo.Models.Options;
using Ambedo.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Ambedo.Repositories
{
    public class DatabaseContext : IDatabaseContext
    {
        protected readonly IMongoDatabase _database;
        protected readonly DatabaseOptions _options;
        public DatabaseContext(IOptions<DatabaseOptions> databaseOptions, IConfiguration configuration)
        {
            _options = databaseOptions.Value;
            var client = new MongoClient(_options.ConnectionString.Replace("<password>", configuration["Database:Password"]));
            _database = client.GetDatabase(_options.DatabaseName);
        }

        public IMongoCollection<Thootle> Thootles => GetCollection<Thootle>(_options.ThootlesCollectionName);

        public IMongoCollection<T> GetCollection<T>(string collectionName) =>
            _database.GetCollection<T>(collectionName);
    }
}

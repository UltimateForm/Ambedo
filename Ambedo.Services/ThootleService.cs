using Ambedo.Models;
using Ambedo.Repositories.Interfaces;
using Ambedo.Services.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ambedo.Services
{
    public class ThootlesService : IThootlesService
    {
        protected readonly IDatabaseContext _databaseContext;
        protected readonly IMongoCollection<Thootle> _thootles;
        public ThootlesService(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _thootles = _databaseContext.Thootles;
        }

        public FilterDefinition<Thootle> GetIdFilter(string id)
        {
            var builder = Builders<Thootle>.Filter;
            var idFilter = builder.Eq(t => t.Id, id);
            return idFilter;
        }

        public async Task<Thootle> CreateThootle(Thootle data)
        {
            await _thootles.InsertOneAsync(data);
            return await Task.FromResult(data);
        }

        public async Task<IEnumerable<Thootle>> GetThootles(FilterDefinition<Thootle> filter)
        {
            var items = (await _thootles.FindAsync(filter ?? FilterDefinition<Thootle>.Empty)).ToEnumerable();
            return await Task.FromResult(items);
        }

        public async Task<IEnumerable<Thootle>> GetThootles()
        {
            var items = (await _thootles.FindAsync(FilterDefinition<Thootle>.Empty)).ToEnumerable();
            return await Task.FromResult(items);
        }

        public async Task<Thootle> GetThootle(string id)
        {
            var item = (await _thootles.FindAsync(GetIdFilter(id))).FirstOrDefault();
            return await Task.FromResult(item);
        }

        public async Task<ReplaceOneResult> UpdateThootle(string id, Thootle data)
        {
            var result = await _thootles.ReplaceOneAsync(GetIdFilter(id), data);
            return await Task.FromResult(result);
        }

        public Task<ReplaceOneResult> UpdateThootle(Thootle data)
        {
            return UpdateThootle(data.Id, data);
        }

        public Task<DeleteResult> DeleteThootle(string id)
        {
            return _thootles.DeleteOneAsync(GetIdFilter(id)); ;
        }

        public Task<DeleteResult> DeleteThootle(Thootle data)
        {
            return DeleteThootle(data.Id);
        }
    }

}

using Ambedo.Models;
using Ambedo.Repositories.Interfaces;
using Ambedo.Services.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;
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

		protected static FilterDefinition<Thootle> GetIdFilter(string id)
		{
			var builder = Builders<Thootle>.Filter;
			var idFilter = builder.Eq(t => t.Id, id);
			return idFilter;
		}

		public async Task<Thootle> CreateThootle(Thootle data)
		{
			await _thootles.InsertOneAsync(data);
			Log.Debug("CRUD CreateThootle Thootle:{@data}", data);
			return await Task.FromResult(data);
		}

		public async Task<IEnumerable<Thootle>> GetThootles(FilterDefinition<Thootle> filter)
		{
			var items = (await _thootles.FindAsync(filter ?? FilterDefinition<Thootle>.Empty)).ToList();
			Log.Debug("CRUD GetThootles Filter:{Filter}; Count:{Count}; Thootles:{@Thootles}", filter, items.Count, items);
			return await Task.FromResult(items);
		}

		public async Task<IEnumerable<Thootle>> GetThootles()
		{
			var items = (await _thootles.FindAsync(FilterDefinition<Thootle>.Empty)).ToList();
			Log.Debug("CRUD GetThootles Count:{Count}; Thootles:{@Thootles}", items.Count, items);
			return await Task.FromResult(items);
		}

		public async Task<Thootle> GetThootle(string id)
		{
			var item = (await _thootles.FindAsync(GetIdFilter(id))).FirstOrDefault();
			Log.Debug("CRUD GetThootle Thootle:{@Thootle}", item);
			return await Task.FromResult(item);
		}

		public async Task<ReplaceOneResult> UpdateThootle(string id, Thootle data)
		{
			var result = await _thootles.ReplaceOneAsync(GetIdFilter(id), data);
			Log.Debug("CRUD UpdateThootle Id:{Id}; Thootle:{@Thootle}; Result:{@Result}", id, data, result);
			return await Task.FromResult(result);
		}

		public async Task<ReplaceOneResult> UpdateThootle(Thootle data)
		{
			var result = await UpdateThootle(data.Id, data);
			Log.Debug("CRUD UpdateThootle Thootle:{@Thootle}; Result:{@Result}", data, result);
			return await Task.FromResult(result); ;
		}

		public Task<DeleteResult> DeleteThootle(string id)
		{
			var result = _thootles.DeleteOneAsync(GetIdFilter(id));
			Log.Debug("CRUD DeleteThootle Id:{Id}; Result:{@Result}", id, result);
			return _thootles.DeleteOneAsync(GetIdFilter(id));
		}

		public Task<DeleteResult> DeleteThootle(Thootle data)
		{
			return DeleteThootle(data.Id);
		}
	}

}

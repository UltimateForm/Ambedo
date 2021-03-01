using Ambedo.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ambedo.Services.Interfaces
{
    public interface IThootlesService
    {
        Task<Thootle> CreateThootle(Thootle data);
        Task<DeleteResult> DeleteThootle(string id);
        Task<DeleteResult> DeleteThootle(Thootle data);
        Task<Thootle> GetThootle(string id);
        Task<IEnumerable<Thootle>> GetThootles(FilterDefinition<Thootle> filter);
        Task<IEnumerable<Thootle>> GetThootles();
        Task<ReplaceOneResult> UpdateThootle(string id, Thootle data);
        Task<ReplaceOneResult> UpdateThootle(Thootle data);
    }
}
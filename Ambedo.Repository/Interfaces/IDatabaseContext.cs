using Ambedo.Models;
using MongoDB.Driver;

namespace Ambedo.Repositories.Interfaces
{
    public interface IDatabaseContext
    {
        IMongoCollection<Thootle> Thootles { get; }
    }
}
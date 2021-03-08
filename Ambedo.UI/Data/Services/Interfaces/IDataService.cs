using System.Collections.Generic;
using System.Threading.Tasks;
using Ambedo.Contract.Dtos;

namespace Ambedo.UI.Data.Services.Interfaces
{
    public interface IDataService
    {
        Task<IEnumerable<Thootle>> GetThootlesAsync();
    }
}
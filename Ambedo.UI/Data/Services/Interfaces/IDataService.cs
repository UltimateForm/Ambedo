﻿using Ambedo.Contract.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ambedo.UI.Data.Services.Interfaces
{
    public interface IDataService
    {
        Task<IEnumerable<Thootle>> GetThootlesAsync();
        Task<int> PostThootleAsync(Thootle thootle);
        Task DeleteThootleAsync(string thootleId);
        Task DeleteThootleAsync(Thootle thootle);
        Task UpdateThootleAsync(Thootle thootle);
    }
}
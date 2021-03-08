using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Ambedo.Contract.Dtos;
using Ambedo.UI.Data.Options;
using Ambedo.UI.Data.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Ambedo.UI.Data.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient _httpClient;
        private readonly AmbedoAPIOptions _config;
        public DataService(HttpClient httpClient, IOptions<AmbedoAPIOptions> options)
        {
            _httpClient = httpClient;
            _config = options.Value;
        }

        public async Task<IEnumerable<Thootle>> GetThootlesAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"{_config.Url}/Thootles");
                var data = JsonConvert.DeserializeObject<IEnumerable<Thootle>>(response, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
                return data;
            }
            catch(Exception e)
            {
                throw new Exception($"Rest request failed with because: {e.Message}");
            }
        }

    }
}

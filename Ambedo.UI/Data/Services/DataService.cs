using Ambedo.Contract.Dtos;
using Ambedo.UI.Data.Options;
using Ambedo.UI.Data.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

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

        public async Task DeleteThootleAsync(string thootleId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_config.Url}/Thootles/{thootleId}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Response bad statuscode {response.StatusCode}");
                }
            }
            catch (Exception e)
            {
                throw new Exception($"HTTP request for Thootle deletion failed!\n{e.Message}");
            }
        }

        public Task DeleteThootleAsync(Thootle thootle)
        {
            return DeleteThootleAsync(thootle.Id);
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
            catch (Exception e)
            {
                throw new Exception($"HTTP request for Thootle fetch failed!\n{e.Message}");
            }
        }

        public async Task<int> PostThootleAsync(Thootle thootle)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_config.Url}/Thootles", thootle);
                return (int)response.StatusCode;
            }
            catch (Exception e)
            {
                throw new Exception($"HTTP request for Thootle creation failed!\n{e.Message}");
            }
        }
    }
}

using Ambedo.Models;
using Ambedo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Ambedo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThootlesController : Controller
    {
        protected IThootlesService _service;
        public ThootlesController(IThootlesService thootlesService)
        {
            _service = thootlesService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Thootle data)
        {
            var result = await _service.CreateThootle(data);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] Thootle filter)
        {
            var result = await _service.GetThootles(JsonConvert.SerializeObject(filter, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }));
            return Ok(result);
        }

        [HttpGet("one/{id}")]
        public async Task<ActionResult> GetOne([FromRoute] string id)
        {
            var result = await _service.GetThootle(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] string id, [FromBody] Thootle data)
        {
            var result = await _service.UpdateThootle(id, data);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] string id)
        {
            var result = await _service.DeleteThootle(id);
            return Ok(result);
        }
    }
}

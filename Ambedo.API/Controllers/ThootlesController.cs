using Ambedo.Models;
using Ambedo.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dtos=Ambedo.Contract.Dtos;
namespace Ambedo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThootlesController : Controller
    {
        protected readonly IThootlesService _service;
        protected readonly IMapper _mapper;
        public ThootlesController(IThootlesService thootlesService, IMapper mapper)
        {
            _service = thootlesService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Dtos.Thootle>> Post([FromBody] Dtos.UnidentifiedThootle data)
        {
            var result = await _service.CreateThootle(_mapper.Map<Dtos.UnidentifiedThootle, Thootle>(data));
            return CreatedAtAction(nameof(GetOne), new { id=result.Id },_mapper.Map<Thootle, Dtos.Thootle>(result));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dtos.Thootle>>> Get([FromQuery] Dtos.ThootleFilter filter)
        {
            var result = await _service.GetThootles(JsonConvert.SerializeObject(filter, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }));
            return Ok(_mapper.Map<IEnumerable<Thootle>, IEnumerable<Dtos.Thootle>>(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dtos.Thootle>> GetOne([FromRoute] string id)
        {
            var result = await _service.GetThootle(id);
            return Ok(_mapper.Map<Thootle, Dtos.Thootle>(result));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Dtos.ReplaceOneResult>> Put([FromRoute] string id, [FromBody] Dtos.UnidentifiedThootle data)
        {
            var result = await _service.UpdateThootle(id, _mapper.Map<Dtos.UnidentifiedThootle, Thootle>(data));
            return Ok(_mapper.Map<ReplaceOneResult, Dtos.ReplaceOneResult>(result));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Dtos.DeleteResult>> Delete([FromRoute] string id)
        {
            var result = await _service.DeleteThootle(id);
            return Ok(_mapper.Map<DeleteResult, Dtos.DeleteResult>(result));
        }
    }
}

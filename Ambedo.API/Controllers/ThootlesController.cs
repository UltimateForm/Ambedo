using Ambedo.Models;
using Ambedo.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dtos = Ambedo.Contract.Dtos;

namespace Ambedo.API.Controllers
{
    //@TODO: refactor and enhance logging for this controller, possibly into a middleware, serilog is nice but doesnt do all the work
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
			return CreatedAtAction(nameof(GetOne), new { id = result.Id }, _mapper.Map<Thootle, Dtos.Thootle>(result));
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Dtos.Thootle>>> Get([FromQuery] string filter)
		{
			var result = await _service.GetThootles(filter);
			var response = _mapper.Map<IEnumerable<Thootle>, IEnumerable<Dtos.Thootle>>(result);
			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Dtos.Thootle>> GetOne([FromRoute] string id)
		{
			if (!ObjectId.TryParse(id, out _))
			{
				return BadRequest(new { error = $"Provided id '{id}' is not a valid id. Id must be a 24 digit hex string." });
			}
			var result = await _service.GetThootle(id);
			return Ok(_mapper.Map<Thootle, Dtos.Thootle>(result));
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Dtos.ReplaceOneResult>> Put([FromRoute] string id, [FromBody] Dtos.UnidentifiedThootle data)
		{
			if (!ObjectId.TryParse(id, out _))
			{
				return BadRequest(new { error = $"Provided id '{id}' is not a valid id. Id must be a 24 digit hex string." });
			}
			var result = await _service.UpdateThootle(id, _mapper.Map<Dtos.UnidentifiedThootle, Thootle>(data));
			return Ok(_mapper.Map<ReplaceOneResult, Dtos.ReplaceOneResult>(result));
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Dtos.DeleteResult>> Delete([FromRoute] string id)
		{
			if (!ObjectId.TryParse(id, out _))
			{
				return BadRequest(new { error = $"Provided id '{id}' is not a valid id. Id must be a 24 digit hex string." });
			}
			var result = await _service.DeleteThootle(id);
			return Ok(_mapper.Map<DeleteResult, Dtos.DeleteResult>(result));
		}
	}
}

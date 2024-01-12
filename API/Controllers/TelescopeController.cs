using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data.DTOs;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

    [ApiController]
    [Route("[controller]")]

    public class TelescopeController : ControllerBase
    {
        private UniverseContext _context;
        private IMapper _mapper;

        public TelescopeController(UniverseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    [HttpPost]
        public IActionResult AddTelescope([FromBody] CreateTelescopeDTO telescopeDTO)
        {
            Telescope telescope = _mapper.Map<Telescope>(telescopeDTO);
            _context.Telescopes.Add(telescope);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecoverTelescopeById), new { Id = telescope.Id }, telescopeDTO);
        }

        [HttpGet]
        public IEnumerable<ReadTelescopeDTO> RecoverTelescope([FromQuery] int? addressId = null)
        {
            if(addressId == null)
            {
                return _mapper.Map<List<ReadTelescopeDTO>>(_context.Telescopes.ToList());

            }
        return _mapper.Map<List<ReadTelescopeDTO>>
            (_context.Telescopes.FromSqlRaw($"SELECT Id, Name, AddressId, CelestialId FROM telescopes WHERE telescopes.AddressId = {addressId}").ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecoverTelescopeById(int id)
        {
            Telescope telescope = _context.Telescopes.FirstOrDefault(telescope => telescope.Id == id);
            if (telescope != null)
            {
                ReadTelescopeDTO telescopeDTO = _mapper.Map<ReadTelescopeDTO>(telescope);
                return Ok(telescopeDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTelescope(int id, [FromBody] UpdateTelescopeDTO telescopeDTO)
        {
            Telescope telescope = _context.Telescopes.FirstOrDefault(telescope => telescope.Id == id);
            if (telescope == null)
            {
                return NotFound();
            }
            _mapper.Map(telescopeDTO, telescope);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Telescope telescope = _context.Telescopes.FirstOrDefault(telescope => telescope.Id == id);
            if (telescope == null)
            {
                return NotFound();
            }
            _context.Remove(telescope);
            _context.SaveChanges();
            return NoContent();
        }
    }

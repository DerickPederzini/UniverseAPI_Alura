using API.Data.DTOs;
using API.Data;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("[controller]")]

public class SessionController : ControllerBase
{
    private UniverseContext _context;
    private IMapper _mapper;

    public SessionController(UniverseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddSession([FromBody] CreateSessionDTO sessionDTO)
    {
        Session session = _mapper.Map<Session>(sessionDTO);
        _context.Sessions.Add(session);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecoverSessionById), new { celesialId = session.CelestialId, addressId = session.AddressId}, session);
    }

    [HttpGet]
    public IEnumerable<ReadSessionDTO> RecoverSession()
    {
        return _mapper.Map<List<ReadSessionDTO>>(_context.Sessions.ToList());
    }

    [HttpGet("{celestialId}/{addressId}")]
    public IActionResult RecoverSessionById(int celestialId, int addressId)
    {
        Session session = _context.Sessions.FirstOrDefault(session => session.CelestialId == celestialId && session.AddressId == addressId);
        if (session != null)
        {
            ReadSessionDTO sessionDTO = _mapper.Map<ReadSessionDTO>(session);

            return Ok(sessionDTO);
        }
        return NotFound();
    }

}

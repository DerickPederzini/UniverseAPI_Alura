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
        return CreatedAtAction(nameof(RecoverSessionById), new { id = session.Id }, session);
    }

    [HttpGet]
    public IEnumerable<ReadSessionDTO> RecoverSession()
    {
        return _mapper.Map<List<ReadSessionDTO>>(_context.Sessions.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecoverSessionById(int id)
    {
        Session session = _context.Sessions.FirstOrDefault(session => session.Id == id);
        if (session != null)
        {
            ReadSessionDTO sessionDTO = _mapper.Map<ReadSessionDTO>(session);

            return Ok(sessionDTO);
        }
        return NotFound();
    }

}

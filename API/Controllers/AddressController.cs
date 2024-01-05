using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Data.DTOs;
using API.Models;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private UniverseContext _context;
    private IMapper _mapper;

    public AddressController(UniverseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddAddress([FromBody] CreateAddressDTO addressDTO)
    {
        Address address = _mapper.Map<Address>(addressDTO);
        _context.Addresses.Add(address);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecoverAddressById), new { Id = address.Id }, address);
    }

    [HttpGet]
    public IEnumerable<ReadAddressDTO> RecoverAddress()
    {
        return _mapper.Map<List<ReadAddressDTO>>(_context.Addresses);
    }
   
    [HttpGet("{id}")]
    public IActionResult RecoverAddressById(int id)
    {
        Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if (address != null)
        {
            ReadAddressDTO addressDTO = _mapper.Map<ReadAddressDTO>(address);

            return Ok(addressDTO);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDTO addressDTO)
    {
        Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if (address == null)
        {
            return NotFound();
        }
        _mapper.Map(addressDTO, address);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(int id)
    {
        Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if (address == null)
        {
            return NotFound();
        }
        _context.Remove(address);
        _context.SaveChanges();
        return NoContent();
    }
}

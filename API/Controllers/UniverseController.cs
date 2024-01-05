using API.Data;
using API.Data.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UniverseController : ControllerBase
{

    private UniverseContext _context;
    private IMapper _mapper;

    public UniverseController(UniverseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="astroDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddCelestialBody([FromBody] CreateUniverseDTO astroDto)
    {
        Celestial astro = _mapper.Map<Celestial>(astroDto);

        //Utilizando Data Notations do c# para validar os parametros em tempo de execução e de forma fácil
        _context.CelestialBodies.Add(astro);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecoverFilmsById), new {id = astro.Id}, astroDto);//Mantendo o código no padrão REST, retornando o local onde pode ser encontrado
        //o objeto criado pela requisição 
    }




    [HttpGet]
    public IEnumerable<ReadUniverseDTO> RecoverFilms([FromQuery] int skip = 0, [FromQuery] int take = 5)//fromQuery diz que o usuario irá mandar as informaçoes de skip e take 
        //atraves de uma requisição
    {
        return _mapper.Map<List<ReadUniverseDTO>>(_context.CelestialBodies.Skip(skip).Take(take).ToList());//permite o usuario dizer quantos elementos ele irá pular e quantos irá pegar na hora de fazer requisições
    }

    [HttpGet("{id}")]//realiza um bind, caso seja passado um id no get, ele vai realizar esse metodo, caso contrario, realizará o acima
    public IActionResult RecoverFilmsById(int id)//retorna o resultado de uma ação executada, ou é notFound ou é Ok
    { 
        var celest = _context.CelestialBodies.FirstOrDefault(nebula => nebula.Id == id);
        if(celest ==  null)return NotFound();
        var universeDto = _mapper.Map<ReadUniverseDTO>(celest);

        return Ok(universeDto);
    }

    [HttpPut("{id}")]//serve para atualizar os filmes
    public IActionResult UpdatesUniverse(int id, [FromBody] UpdateUniverseDTO celestialDTO)
    {
        var universe = _context.CelestialBodies.FirstOrDefault(universe => universe.Id == id);

        if(universe == null) return NotFound();

        _mapper.Map(celestialDTO, universe);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]//patch é utilizado para atualizar parcialmente as informalçoes
    public IActionResult UpdatesUniversePartial(int id, JsonPatchDocument<UpdateUniverseDTO> patch)//foi utilizada a extensao newtonofjson
    {
        var universe = _context.CelestialBodies.FirstOrDefault(universe => universe.Id == id);
        if (universe == null) return NotFound();

       var attUniverse =  _mapper.Map<UpdateUniverseDTO>(universe); // will change to update universe, so it can pass through an update

        patch.ApplyTo(attUniverse, ModelState);

        if (!TryValidateModel(attUniverse))//will verify if all the validations are correct, name, type of content, path, etc
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(attUniverse, universe);//changes back to universe so it can be applied in the system
        _context.SaveChanges();

        return NoContent();
    }

    //Deletando
    [HttpDelete("{id}")]
    public IActionResult deletsUniverse(int id)
    {
        var universe = _context.CelestialBodies.FirstOrDefault(universe => universe.Id == id);
        if (universe == null) return NotFound();
        _context.Remove(universe);
        _context.SaveChanges();

        return NoContent();
    }


}
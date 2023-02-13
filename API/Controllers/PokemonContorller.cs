using API.Data.Dto;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonContorller : Controller
{
    private readonly IPokemonRepository _pokemonRepository;
    private readonly IMapper _mapper;

    public PokemonContorller(IPokemonRepository pokemonRepository, IMapper mapper)
    {
        _pokemonRepository = pokemonRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerator<Pokemon>))]
    public IActionResult GetPokemons()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());

        return Ok(pokemons);
    }

    [HttpGet("{pokeId:int}")]
    [ProducesResponseType(200, Type = typeof(Pokemon))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemon(int pokeId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_pokemonRepository.PokemonExists(pokeId))
            return NotFound();

        var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokeId));

        return Ok(pokemon);
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreatePokemon([FromQuery] int ownerId, [FromQuery] int catId,
        [FromBody] PokemonDto pokemonCreate)
    {
        if (pokemonCreate == null)
            return BadRequest(ModelState);

        var pokemons = _pokemonRepository.GetPokemonTrimToUpper(pokemonCreate);

        if (pokemons != null)
        {
            ModelState.AddModelError("", "Owner already exists");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pokemonMap = _mapper.Map<Pokemon>(pokemonCreate);


        if (!_pokemonRepository.CreatePokemon(ownerId, catId, pokemonMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created");
    }
}
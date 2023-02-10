using API.Data.Dto;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : Controller
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public CountryController(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
    public IActionResult GetCountries()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var country = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());

        return Ok(country);
    }

    [HttpGet("{countryId:int}")]
    [ProducesResponseType(200, Type = typeof(Country))]
    [ProducesResponseType(400)]
    public IActionResult GetCountry(int countryId)
    {
        if (!_countryRepository.CountryExists(countryId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(countryId));

        return Ok(country);
    }

    [HttpGet("owners/{ownerId:int}")]
    [ProducesResponseType(200, Type = typeof(Country))]
    [ProducesResponseType(400)]
    public IActionResult GetCountryOfAnOwner(int ownerId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var country = _mapper.Map<CategoryDto>(_countryRepository.GetCountryByOwner(ownerId));
        return Ok(country);
    }
}
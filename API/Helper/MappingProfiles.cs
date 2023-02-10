using API.Data.Dto;
using API.Models;
using AutoMapper;

namespace API.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Pokemon, PokemonDto>();
        CreateMap<Category, CategoryDto>();
    }
}
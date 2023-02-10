using System.ComponentModel.DataAnnotations;

namespace API.Data.Dto;

public class PokemonDto : BaseDto
{
    public string? Name { get; set; }
    public DateTime? BirthDate { get; set; }
}
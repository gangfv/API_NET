using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Owner : BaseModel
{
    public string? Name { get; set; }
    public string? Gym { get; set; }
    public Country? Country { get; set; }
    public ICollection<PokemonOwner>? PokemonOwners { get; set; }
}
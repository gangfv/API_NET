using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class PokemonOwner
{
    [Key] public int PokemonId { get; set; }
    public int OwnerId { get; set; }
    public Pokemon Pokemon { get; set; }
    public Owner Owner { get; set; }
}
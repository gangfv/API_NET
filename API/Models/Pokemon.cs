﻿using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Pokemon
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<PokemonOwner> PokemonOwners { get; set; }
    public ICollection<PokemonCategory> PokemonCategories { get; set; }
}
﻿using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Category : BaseModel
{
    public string? Name { get; set; }
    public ICollection<PokemonCategory>? PokemonCategories { get; set; }
}
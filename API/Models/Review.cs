﻿using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Review : BaseModel
{
    public string? Title { get; set; }
    public string? Text { get; set; }
    public Reviewer? Reviewer { get; set; }
    public Pokemon? Pokemon { get; set; }
}
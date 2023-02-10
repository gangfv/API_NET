using System.ComponentModel.DataAnnotations;

namespace API.Data.Dto;

public class BaseDto
{
    [Key] public int Id { get; set; }
}
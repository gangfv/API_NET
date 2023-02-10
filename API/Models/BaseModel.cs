using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class BaseModel
{
    [Key] public int? Id { get; set; }
}
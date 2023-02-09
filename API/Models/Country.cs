using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Country
{
    [Key] public int MyProperty { get; set; }
    public string Name { get; set; }
    public ICollection<Owner> Owners { get; set; }
}
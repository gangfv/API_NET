using API.Models;

namespace API.Interfaces;

public interface IOwnerRepository
{
    ICollection<Owner?> GetOwners();
    Owner? GetOwner(int ownerId);
    List<Owner?> GetOwnerOfAPokemon(int pokeId);
    ICollection<Pokemon> GetPokemonByOwner(int ownerId);
    bool OwnerExists(int ownerId);
}
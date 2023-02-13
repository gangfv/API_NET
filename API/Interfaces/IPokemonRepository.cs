using API.Data.Dto;
using API.Models;

namespace API.Interfaces;

public interface IPokemonRepository
{
    List<Pokemon?> GetPokemons();
    Pokemon? GetPokemon(int id);
    Pokemon? GetPokemon(string name);
    Pokemon GetPokemonTrimToUpper(PokemonDto pokemonCreate);
    decimal GetPokemonRating(int pokeId);
    bool PokemonExists(int pokeId);
    bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon);
    bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon);
    bool DeletePokemon(Pokemon pokemon);
    bool Save();
}
using API.Data;
using API.Interfaces;
using API.Models;

namespace API.Repository;

public class PokemonRepository : IPokemonRepository
{
    private readonly DataContext _context;

    public PokemonRepository(DataContext context)
    {
        _context = context;
    }

    public List<Pokemon> GetPokemons()
    {
        return _context.Pokemon.OrderBy(p => p!.Id).ToList();
    }

    public Pokemon? GetPokemon(int id)
    {
        return _context.Pokemon.FirstOrDefault(p => p!.Id == id);
    }

    public Pokemon? GetPokemon(string name)
    {
        return _context.Pokemon.FirstOrDefault(p => p!.Name == name);
    }

    public decimal GetPokemonRating(int pokeId)
    {
        return 0;
    }

    public bool PokemonExists(int pokeId)
    {
        return _context.Pokemon.Any(p => p!.Id == pokeId);
    }
}
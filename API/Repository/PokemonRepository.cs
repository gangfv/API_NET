using API.Data;
using API.Data.Dto;
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

    public List<Pokemon?> GetPokemons()
    {
        return _context.Pokemon.OrderBy(p => p!.Id).ToList()!;
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

    public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
    {
        var pokemonOwnerEntity = _context.Owners.FirstOrDefault(a => a.Id == ownerId);
        var category = _context.Categories.FirstOrDefault(a => a.Id == categoryId);
        var pokemonOwner = new PokemonOwner()
        {
            Owner = pokemonOwnerEntity,
            Pokemon = pokemon,
        };

        _context.Add(pokemonOwner);

        var pokemonCategory = new PokemonCategory()
        {
            Category = category,
            Pokemon = pokemon,
        };

        _context.Add(pokemonCategory);

        _context.Add(pokemon);

        return Save();
    }

    public Pokemon GetPokemonTrimToUpper(PokemonDto pokemonCreate)
    {
        return GetPokemons().FirstOrDefault(c =>
            String.Equals(c!.Name!.Trim(), pokemonCreate.Name!.TrimEnd(), StringComparison.CurrentCultureIgnoreCase))!;
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon)
    {
        _context.Update(pokemon);
        return Save();
    }

    public bool DeletePokemon(Pokemon pokemon)
    {
        _context.Remove(pokemon);
        return Save();
    }
}
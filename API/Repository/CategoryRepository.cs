using API.Data;
using API.Interfaces;
using API.Models;

namespace API.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly DataContext _context;

    public CategoryRepository(DataContext context)
    {
        _context = context;
    }

    public ICollection<Category> GetCategories()
    {
        return _context.Categories.ToList();
    }

    public Category GetCategory(int id)
    {
        return _context.Categories.FirstOrDefault(e => e.Id == id)!;
    }

    public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
    {
        return _context.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList()!;
    }

    public bool CategoryExists(int id)
    {
        return _context.Pokemon.Any(p => p!.Id == id);
    }
}
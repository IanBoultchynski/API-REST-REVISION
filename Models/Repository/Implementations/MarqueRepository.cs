using API_REST_Revision;
using API_REST_REVISION.Models;
using Microsoft.EntityFrameworkCore;

public class MarqueRepository : IMarqueRepository
{
    private readonly ProduitsDbContext _context;

    public MarqueRepository(ProduitsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Marque>> GetAllAsync() => await _context.Marques.ToListAsync();

    public async Task<Marque?> GetByIdAsync(int id) => await _context.Marques.FindAsync(id);

    public async Task AddAsync(Marque entity) => await _context.Marques.AddAsync(entity);

    public Task UpdateAsync(Marque entity)
    {
        _context.Marques.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Marque entity)
    {
        _context.Marques.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();

    public async Task<IEnumerable<Marque>> GetAllWithProductsAsync()
    {
        return await _context.Marques
            .Include(m => m.Produits)
            .ToListAsync();
    }
}


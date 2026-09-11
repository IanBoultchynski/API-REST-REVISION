using API_REST_Revision;
using API_REST_REVISION.Models;
using Microsoft.EntityFrameworkCore;

public class ProduitRepository : IProduitRepository
{
    private readonly ProduitsDbContext _context;

    public ProduitRepository(ProduitsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Produit>> GetAllAsync() => await _context.Produits.ToListAsync();

    public async Task<Produit?> GetByIdAsync(int id) => await _context.Produits.FindAsync(id);

    public async Task AddAsync(Produit entity) => await _context.Produits.AddAsync(entity);

    public Task UpdateAsync(Produit entity)
    {
        _context.Produits.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Produit entity)
    {
        _context.Produits.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();

    public async Task<IEnumerable<Produit>> GetAllWithDetailsAsync() =>
        await _context.Produits
            .Include(p => p.IdMarqueNavigation)
            .Include(p => p.IdTypeProduitNavigation)
            .ToListAsync();

    public async Task<Produit?> GetByIdWithDetailsAsync(int id) =>
        await _context.Produits
            .Include(p => p.IdMarqueNavigation)
            .Include(p => p.IdTypeProduitNavigation)
            .FirstOrDefaultAsync(p => p.IdProduit == id);

    public async Task<IEnumerable<Produit>> GetByMarqueAsync(int idMarque) =>
        await _context.Produits.Where(p => p.IdMarque == idMarque).ToListAsync();

    public async Task<IEnumerable<Produit>> SearchByNameAsync(string term) =>
        await _context.Produits.Where(p => p.NomProduit != null && p.NomProduit.Contains(term)).ToListAsync();
}
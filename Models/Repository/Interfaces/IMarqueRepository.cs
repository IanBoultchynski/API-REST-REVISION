using API_REST_REVISION.Models;

public interface IMarqueRepository : IRepository<Marque>
{
    Task<IEnumerable<Marque>> GetAllWithProductsAsync();
}


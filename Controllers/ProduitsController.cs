// Controllers/ProduitsController.cs
using API_REST_REVISION.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProduitsController : ControllerBase
{
    private readonly IProduitRepository _repository;

    public ProduitsController(IProduitRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Produit>>> GetProduits()
    {
        return Ok(await _repository.GetAllWithDetailsAsync());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Produit>> GetProduit(int id)
    {
        var produit = await _repository.GetByIdWithDetailsAsync(id);
        if (produit == null) return NotFound();
        return Ok(produit);
    }

    [HttpGet("marque/{idMarque}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Produit>>> GetByMarque(int idMarque)
    {
        return Ok(await _repository.GetByMarqueAsync(idMarque));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Produit>> PostProduit(Produit p)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        await _repository.AddAsync(p);
        await _repository.SaveAsync();

        return CreatedAtAction(nameof(GetProduit), new { id = p.IdProduit }, p);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PutProduit(int id, Produit p)
    {
        if (id != p.IdProduit) return BadRequest();

        await _repository.UpdateAsync(p);
        await _repository.SaveAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduit(int id)
    {
        var produit = await _repository.GetByIdAsync(id);
        if (produit == null) return NotFound();

        await _repository.DeleteAsync(produit);
        await _repository.SaveAsync();

        return NoContent();
    }
}
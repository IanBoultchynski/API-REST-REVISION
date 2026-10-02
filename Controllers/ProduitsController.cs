// Controllers/ProduitsController.cs
using API_REST_REVISION.Models;
using API_REST_REVISION.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProduitsController : ControllerBase
{
    private readonly IProduitRepository _repository;
    private readonly IMapper _mapper;

    public ProduitsController(IProduitRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ProduitDto>>> GetProduits()
    {
        var produits = await _repository.GetAllWithDetailsAsync();
        return Ok(_mapper.Map<IEnumerable<ProduitDto>>(produits));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProduitDetailDto>> GetProduit(int id)
    {
        var produit = await _repository.GetByIdWithDetailsAsync(id);
        if (produit == null) return NotFound();
        return Ok(_mapper.Map<ProduitDetailDto>(produit));
    }

    [HttpGet("marque/{idMarque}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ProduitDto>>> GetByMarque(int idMarque)
    {
        var produits = await _repository.GetByMarqueAsync(idMarque);
        return Ok(_mapper.Map<IEnumerable<ProduitDto>>(produits));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProduitDto>> PostProduit(Produit p)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        await _repository.AddAsync(p);
        await _repository.SaveAsync();

        return CreatedAtAction(nameof(GetProduit), new { id = p.IdProduit }, _mapper.Map<ProduitDto>(p));
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

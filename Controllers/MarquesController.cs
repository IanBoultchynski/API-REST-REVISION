using API_REST_REVISION.Models;
using API_REST_REVISION.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class MarquesController : ControllerBase
{
    private readonly IMarqueRepository _repository;
    private readonly IMapper _mapper;

    public MarquesController(IMarqueRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<MarqueDto>>> GetMarques()
    {
        var marques = await _repository.GetAllWithProductsAsync();
        return Ok(_mapper.Map<IEnumerable<MarqueDto>>(marques));
    }
}


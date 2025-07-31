using Fiap.Api.Donation5.Data;
using Fiap.Api.Donation5.Models;
using Fiap.Api.Donation5.Repository;
using Fiap.Api.Donation5.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Donation5.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{

    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaController(DataContext dataContext)
    {
        _categoriaRepository = new CategoriaRepository(dataContext);
    }

    [HttpGet]
    public async Task <ActionResult<IList<CategoriaModel>>> Get()
    {
        var categorias = await _categoriaRepository.FindAllAsync() ?? new List<CategoriaModel>();
        return Ok(categorias);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoriaModel>> Get([FromRoute] int id)
    {
        var categoria = await _categoriaRepository.FindByIdAsync(id);

        if (categoria == null)
        {
            return NotFound();
        } else
        {
            return Ok(categoria);
        }
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaModel>> Post([FromBody] CategoriaModel categoriaModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        } 
        else
        {
            categoriaModel.CategoriaId = await _categoriaRepository.InsertAsync(categoriaModel);

            return CreatedAtAction( nameof(Get), new { id = categoriaModel.CategoriaId} , categoriaModel);
        }

    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put([FromRoute] int id, [FromBody] CategoriaModel categoriaModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (categoriaModel.CategoriaId != id)
        {
            return BadRequest(new { erro = "IDs divergentes" });
        }

        if (await _categoriaRepository.FindByIdAsync(id) == null)
        {
            return NotFound();
        } 

        await _categoriaRepository.UpdateAsync(categoriaModel);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {

        if (id == 0)
        {
            return BadRequest();
        }

        if (await _categoriaRepository.FindByIdAsync(id) == null)
        {
            return NotFound();
        }

        await _categoriaRepository.DeleteAsync(id);
        return NoContent();
    }
}

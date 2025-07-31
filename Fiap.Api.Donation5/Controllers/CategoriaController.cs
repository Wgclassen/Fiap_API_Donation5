using Fiap.Api.Donation5.Data;
using Fiap.Api.Donation5.Models;
using Fiap.Api.Donation5.Repository;
using Fiap.Api.Donation5.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Donation5.Controllers
{
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
        public ActionResult<IList<CategoriaModel>> Get()
        {
            var categorias = _categoriaRepository.FindAll() ?? new List<CategoriaModel>();
            return Ok(categorias);
        }

        [HttpGet("{id:int}")]
        public ActionResult<CategoriaModel> Get([FromRoute] int id)
        {
            var categoria = _categoriaRepository.FindById(id);

            if (categoria == null)
            {
                return NotFound();
            } else
            {
                return Ok(categoria);
            }
        }

        [HttpPost]
        public ActionResult<CategoriaModel> Post([FromBody] CategoriaModel categoriaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            else
            {
                categoriaModel.CategoriaId = _categoriaRepository.Insert(categoriaModel);

                return CreatedAtAction( nameof(Get), new { id = categoriaModel.CategoriaId} , categoriaModel);
            }

        }

        [HttpPut("{id:int}")]
        public ActionResult Put([FromRoute] int id, [FromBody] CategoriaModel categoriaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (categoriaModel.CategoriaId != id)
            {
                return BadRequest(new { erro = "IDs divergentes" });
            }

            if (_categoriaRepository.FindById(id) == null)
            {
                return NotFound();
            } 

            _categoriaRepository.Update(categoriaModel);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete([FromRoute] int id)
        {

            if (id == 0)
            {
                return BadRequest();
            }

            if (_categoriaRepository.FindById(id) == null)
            {
                return NotFound();
            }

            _categoriaRepository.Delete(id);
            return NoContent();
        }
    }
}

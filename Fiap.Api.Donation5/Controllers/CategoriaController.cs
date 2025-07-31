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
        public IList<CategoriaModel> Get()
        {
            return _categoriaRepository.FindAll();
        }

        [HttpGet("{id:int}")]
        public CategoriaModel Get([FromRoute] int id)
        {
            return new CategoriaModel()
            {
                CategoriaId = 1,
                NomeCategoria = "Celular"
            };
        }

        [HttpPost]
        public int Post([FromBody] CategoriaModel categoriaModel)
        {
            return 1311;
        }

        [HttpPut("{id:int}")]
        public int Put([FromRoute] int id, [FromBody] CategoriaModel categoriaModel)
        {
            return 1311;
        }

        [HttpDelete("{id:int}")]
        public int Delete([FromRoute] int id)
        {
            return 1333;
        }
    }
}

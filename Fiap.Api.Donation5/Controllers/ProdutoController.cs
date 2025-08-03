using Fiap.Api.Donation5.Data;
using Fiap.Api.Donation5.Models;
using Fiap.Api.Donation5.Repository;
using Fiap.Api.Donation5.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Donation5.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(DataContext dataContext)
        {
            _produtoRepository = new ProdutoRepository(dataContext);
        }

        [HttpGet()]
        [ApiVersion("3.0")]
        public async Task<ActionResult<dynamic>> GetV3([FromQuery] int idRef = 0, [FromQuery] int tamanho = 5)
        {
            var produtos = await _produtoRepository.FindAllByIdRefAsync(idRef, tamanho) ?? new List<ProdutoModel>();
            var ultimo = produtos.LastOrDefault();

            var retorno = new
            {
                Proximo = $"/api/produto?idRef={ultimo.ProdutoId}&tamanho={tamanho}",
                Produtos = produtos
            };

            return Ok(retorno);
        }

        [HttpGet()]
        [ApiVersion("2.0")]
        public async Task<ActionResult<dynamic>> GetV2([FromQuery] int pagina = 0, [FromQuery] int tamanho = 5)
        {
            var produtos = await _produtoRepository.FindAllAsync(pagina, tamanho) ?? new List<ProdutoModel>();
            var totalProdutos = await _produtoRepository.CountAsync();

            var totalPaginas = Convert.ToInt16(Math.Ceiling((double)totalProdutos / tamanho));

            var retorno = new
            {
                Total = totalProdutos,
                TotalPaginas = totalPaginas,
                LinkProximo = (pagina < totalPaginas - 1) ? $"/api/produto?{pagina + 1}=0&tamanho={tamanho}" : "",
                LinkAnterior = (pagina > 0) ? $"/api/produto?{pagina - 1}=0&tamanho={tamanho}" : "",
                Produtos = produtos
            };

            return Ok(retorno);
        }

        [HttpGet()]
        [ApiVersion("1.0")]
        public async Task<ActionResult<ProdutoModel>> GetV1()
        {
            var produtos = await _produtoRepository.FindAllAsync() ?? new List<ProdutoModel>();

            return Ok(produtos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoModel>> GetById(int id)
        {
            var produto = await _produtoRepository.FindByIdAsync(id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

    }
}

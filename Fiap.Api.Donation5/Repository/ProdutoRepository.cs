using Fiap.Api.Donation5.Data;
using Fiap.Api.Donation5.Models;
using Fiap.Api.Donation5.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Donation5.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly DataContext _dataContext;

        public ProdutoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> CountAsync()
        {
            return await _dataContext.Produtos.CountAsync();
        }

        public Task DeleteAsync(ProdutoModel produtoModel)
        {
            return null;
        }

        public async Task DeleteAsync(int id)
        {
            var produto = new ProdutoModel() { ProdutoId = id };

            _dataContext.Produtos.Remove(produto);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IList<ProdutoModel>> FindAllAsync(int pagina = 0, int tamanho = 5)
        {
            return await _dataContext.Produtos
                .AsNoTracking()
                .Include(p => p.Categoria)
                .Include(p => p.Usuario)
                    .Skip(pagina * tamanho)
                    .Take(tamanho)
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        public async Task<IList<ProdutoModel>> FindAllAsync()
        {
            return await _dataContext.Produtos
                .AsNoTracking()
                .Include(p => p.Categoria)
                .Include(p => p.Usuario)
                .ToListAsync();
        }

        public async Task<IList<ProdutoModel>> FindAllByIdRefAsync(int idRef = 0, int tamanho = 5)
        {
            return await _dataContext.Produtos
               .AsNoTracking()
               .Include(p => p.Categoria)
               .Include(p => p.Usuario)
                   .Where (p => p.ProdutoId > idRef)
                   .Take(tamanho)
               .OrderBy(p => p.Nome)
               .ToListAsync();
        }

        public async Task<ProdutoModel> FindByIdAsync(int id)
        {
            return await _dataContext.Produtos.AsNoTracking().FirstOrDefaultAsync(c => c.CategoriaId == id);
        }

        public Task<IList<ProdutoModel>> FindByNomeAsync(string nome)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertAsync(ProdutoModel produtoModel)
        {
            _dataContext.Produtos.Add(produtoModel);
            await _dataContext.SaveChangesAsync();

            return produtoModel.ProdutoId;
        }

        public async Task UpdateAsync(ProdutoModel produtoModel)
        {
            _dataContext.Produtos.Update(produtoModel);
            await _dataContext.SaveChangesAsync();
        }
    }
}

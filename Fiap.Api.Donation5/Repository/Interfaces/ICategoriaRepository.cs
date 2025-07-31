using Fiap.Api.Donation5.Data;
using Fiap.Api.Donation5.Models;

namespace Fiap.Api.Donation5.Repository.Interfaces
{
    public interface ICategoriaRepository
    {
        public Task DeleteAsync(int id);
        public Task<IList<CategoriaModel>> FindAllAsync();
        public Task<CategoriaModel> FindByIdAsync(int id);
        public Task<int> InsertAsync(CategoriaModel categoriaModel);
        public Task UpdateAsync(CategoriaModel categoriaModel);
    }
}

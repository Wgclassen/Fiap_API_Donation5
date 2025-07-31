using Fiap.Api.Donation5.Data;
using Fiap.Api.Donation5.Models;

namespace Fiap.Api.Donation5.Repository.Interfaces
{
    public interface ICategoriaRepository
    {
        public void Delete(int id);
        public IList<CategoriaModel> FindAll();
        public CategoriaModel FindById(int id);
        public int Insert(CategoriaModel categoriaModel);
        public void Update(CategoriaModel categoriaModel);
    }
}

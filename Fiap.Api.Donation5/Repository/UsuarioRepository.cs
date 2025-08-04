using Fiap.Api.Donation5.Data;
using Fiap.Api.Donation5.Models;
using Fiap.Api.Donation5.Repository.Interfaces;

namespace Fiap.Api.Donation5.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _dataContext;

        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UsuarioModel>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioModel> FindByEmailAndSenhaAsync(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioModel> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(UsuarioModel usuarioModel)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UsuarioModel usuarioModel)
        {
            throw new NotImplementedException();
        }
    }
}

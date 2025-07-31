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


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<UsuarioModel> FindAll()
        {
            throw new NotImplementedException();
        }

        public UsuarioModel FindByEmailAndSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public UsuarioModel FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(UsuarioModel usuarioModel)
        {
            throw new NotImplementedException();
        }

        public void Update(UsuarioModel usuarioModel)
        {
            throw new NotImplementedException();
        }
    }
}

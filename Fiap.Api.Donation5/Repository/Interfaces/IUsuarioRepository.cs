using Fiap.Api.Donation5.Models;

namespace Fiap.Api.Donation5.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        public IList<UsuarioModel> FindAll();

        public UsuarioModel FindById(int id);

        public UsuarioModel FindByEmailAndSenha(string email, string senha);

        public int Insert(UsuarioModel usuarioModel);

        public void Update(UsuarioModel usuarioModel);

        public void Delete(int id);
    }
}

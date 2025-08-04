using Fiap.Api.Donation5.Models;

namespace Fiap.Api.Donation5.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IList<UsuarioModel>> FindAllAsync();

        Task<UsuarioModel> FindByIdAsync(int id);

        Task<UsuarioModel> FindByEmailAndSenhaAsync(string email, string senha);

        Task<int> InsertAsync(UsuarioModel usuarioModel);

        Task UpdateAsync(UsuarioModel usuarioModel);

        Task DeleteAsync(int id);
    }
}

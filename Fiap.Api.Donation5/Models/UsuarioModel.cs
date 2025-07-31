namespace Fiap.Api.Donation5.Models
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; }

        public string NomeUsuario { get; set; }

        public string EmailUsuario { get; set; }

        public string Senha {  get; set; }

        public string? Regra {  get; set; }

        public UsuarioModel()
        {

        }

        public UsuarioModel(int usuarioId, string nomeUsuario, string emailUsuario, string senha, string? regra)
        {
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            EmailUsuario = emailUsuario;
            Senha = senha;
            Regra = regra;
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Fiap.Api.Donation5.ViewModel
{
    public record LoginRequestViewModel
    {
        [Required(ErrorMessage = "Email é requerido")]
        public string EmailUsuario { get; set; }

        [Required(ErrorMessage = "Senha é requerida")]
        public string Senha { get; set; }

    }
}

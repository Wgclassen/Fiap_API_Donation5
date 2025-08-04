namespace Fiap.Api.Donation5.ViewModel
{
    public class ProdutoResponseViewModel
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public bool Disponivel { get; set; }
        public string? Descricao { get; set; }
        public string SugestaoTroca { get; set; }
        public double Valor { get; set; }
        public DateTime DataExpiracao { get; set; }
        public int CategoriaId { get; set; }
        public string NomeCategoria { get; set; }
        public string NomeUsuario { get; set; }
    }
}

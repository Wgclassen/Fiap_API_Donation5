namespace Fiap.Api.Donation5.ViewModel
{
    public class ProdutoPaginadoResponseViewModel
    {
        public int TotalGeral { get; set; }
        public int TotalPaginas { get; set; }
        public string LinkProximo { get; set; }
        public string LinkAnterior { get; set; }
        public IList<ProdutoResponseViewModel> Produtos { get; set; }
    }
}
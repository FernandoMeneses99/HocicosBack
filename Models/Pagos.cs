namespace HocicosBack.Models
{
    public class Pagos
    {
        public int PagoId { get; set; }
        public int PedidoId { get; set; }
        public object PedidoID { get; internal set; }
        public DateTime FechaDePago { get; set; }
        public decimal MontoDePago { get; set; }
        public string MetodoDePago { get; set; }
        public object Pedido { get; internal set; }
    }
}

namespace HocicosBack.Models
{
    public class Pedidos
    {
        public int PedidoID { get; set; }
        public int ClienteID { get; set;}
        public DateTime FechaDePedido { get; set;}
        public decimal MontoTotal { get; set;}
        public string EstadoDelPedido { get; set}
    }
}

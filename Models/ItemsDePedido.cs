namespace HocicosBack.Models
{
    public class ItemsDePedido
    {
        public int ItemDePedidoID { get; set; }
        public int PedidoID { get; set; }
        public int ProductoID {  get; set; }
        public int SaborID { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get;
    }
}

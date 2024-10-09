using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace HocicosBack.Models
   
{
    public class ItemsDePedido
    {
        public int ItemDePedidoID { get; set; }
        public int PedidoID { get; set; }
        public int ProductoID {  get; set; }
        public int SaborID { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        // Propiedad de navegación

        [JsonIgnore]
        [ForeignKey("ClienteID")]
        public Pedidos? Pedidos { get; set;}
        public object Productos { get; internal set; }
        public object Sabores { get; internal set; }
    }
}

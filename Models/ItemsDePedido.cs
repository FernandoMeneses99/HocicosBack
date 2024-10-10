using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HocicosBack.Models
{
    public class ItemsDePedido
    {
        [Key]
        public int ItemDePedidoID { get; set; }

        [Required]
        public int PedidoID { get; set; }

        [Required]
        public int ProductoID { get; set; }

        [Required]
        public int SaborID { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal Precio { get; set; }

        // Propiedades de navegagaciones
        [JsonIgnore]
        [ForeignKey("PedidoID")]
        public Pedidos? Pedido { get; set; }

        [JsonIgnore]
        [ForeignKey("ProductoID")]
        public Productos? Producto { get; set; }

        [JsonIgnore]
        [ForeignKey("SaborID")]
        public Sabores? Sabor { get; set; }
    }
}

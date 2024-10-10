using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HocicosBack.Models
{
    public class Pedidos
    {
        [Key]
        public int PedidoID { get; set; }

        [Required]
        public int ClienteID { get; set; }

        [Required]
        public DateTime FechaDePedido { get; set; }

        [Required]
        public decimal MontoTotal { get; set; }

        [Required]
        [StringLength(50)]
        public string EstadoDelPedido { get; set; }

        // Propiedades de navegación
        [JsonIgnore]
        [ForeignKey("ClienteID")]
        public Clientes? Cliente { get; set; }

        [JsonIgnore]
        public ICollection<ItemsDePedido>? ItemsDePedidos { get; set; }

        [JsonIgnore]
        public ICollection<Pagos>? Pagos { get; set; }

        [JsonIgnore]
        public ICollection<Envios>? Envios { get; set; }
    }
}

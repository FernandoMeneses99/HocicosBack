using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Threading;

namespace HocicosBack.Models
{
    public class Pedidos
    {
        public int PedidoID { get; set; }
        public int ClienteID { get; set;}
        public DateTime FechaDePedido { get; set;}
        public decimal MontoTotal { get; set;}
        public string EstadoDelPedido { get; set;}
        // Propiedad de navegación
        [JsonIgnore]
        [ForeignKey("ClienteID")]
        public Clientes? Clientes {get; set;}
        [JsonIgnore]
        public ICollection<ItemsDePedido>? ItemsDePedidos { get; set; }
        [JsonIgnore]
        public ICollection<Pagos>? Pagos { get; set; }
        [JsonIgnore]
        public ICollection<Envios>? Envios { get; set; }
    }
}

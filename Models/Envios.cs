using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HocicosBack.Models
{
    public class Envios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnvioID { get; set; } 

        [Required]
        public int PedidoID { get; set; }

        [Required]
        [StringLength(50)]
        public string MetodoDeEnvio { get; set; }

        [Required]
        [StringLength(500)]
        public string DireccionDeEnvio { get; set; }

        public DateTime? FechaDeEnvio { get; set; }

        [JsonIgnore]
        [ForeignKey("PedidoID")]
        public Pedidos? Pedido { get; set; } 
    }
}

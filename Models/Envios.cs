using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HocicosBack.Models
{
    public class Envios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnvíoID { get; set; }

        [Required]
        public int PedidoID { get; set; }

        [Required]
        [StringLength(50)]
        public string MétodoDeEnvío { get; set; }

        [Required]
        [StringLength(500)]
        public string DirecciónDeEnvío { get; set; }

        public DateTime? FechaDeEnvío { get; set; }
        [JsonIgnore]
        [ForeignKey("PedidoID")]
        public Pedidos? Pedidos { get; set; }
        public object? EnvioID { get; internal set; }
        public object Pedido { get; internal set; }
    }
}

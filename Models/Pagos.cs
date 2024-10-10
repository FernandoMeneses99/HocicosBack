using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HocicosBack.Models
{
    public class Pagos
    {
        [Key]
        public int PagoId { get; set; }

        [Required]
        public int PedidoId { get; set; }

        [Required]
        public DateTime FechaDePago { get; set; }

        [Required]
        public decimal MontoDePago { get; set; }

        [Required]
        [StringLength(50)]
        public string MetodoDePago { get; set; }

        // Propiedad de navegación
        [ForeignKey("PedidoId")]
        public Pedidos? Pedido { get; set; }
    }
}

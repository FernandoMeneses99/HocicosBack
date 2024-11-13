using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HocicosBack.Models
{
    public class Sabores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaborID { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        [Required]
        [Range(0, 100)] // Ajusta el rango según corresponda
        public decimal ContenidoDeColageno { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }

        [Required]
        public int CantidadEnStock { get; set; }

        [ForeignKey("ProductoID")]
        public int ProductoID { get; set; }

        // Propiedad de navegación
        public ICollection<ItemsDePedido>? ItemsDePedidos { get; set; }
        public Productos? Producto { get; set; }
    }
}

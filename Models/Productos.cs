using HocicosBack.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HocicosBack.Models
{
    public class Productos
    {
        [Key]
        public int ProductoID { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty!;

        public string Descripcion { get; set; } = string.Empty!;

        [Required]
        public decimal PrecioDeCompra { get; set; }

        [Required]
        public decimal PrecioDeVenta { get; set; }

        [Required]
        public DateTime FechaDeCreacion { get; set; }

        public int ID_Proveedor { get; set; }
        public int? SaborID { get; set; }

        [ForeignKey("ID_Proveedor")]
        public Proveedores? Proveedor { get; set; }

        [ForeignKey("SaborID")]
        public Sabores? Sabor { get; set; }
    }
}

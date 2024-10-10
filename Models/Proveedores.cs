using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HocicosBack.Models
{
    public class Proveedores
    {
        [Key]
        public int ID_Proveedor { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(15)]
        public string Telefono { get; set; }

        [MaxLength(200)]
        public string Direccion { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        // Relación con Productos
        public ICollection<Productos>? Productos { get; set; }
    }
}

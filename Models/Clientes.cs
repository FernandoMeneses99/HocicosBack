using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HocicosBack.Models
{
    public class Clientes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteID { get; set; }

        [Required]
        [StringLength(255)]
        public string NombreComercial { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoDeCliente { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string CorreoElectronico { get; set; }

        [Required]
        [StringLength(255)]
        public string ContrasenaHash { get; set; }

        [Required]
        [StringLength(500)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(50)]
        public string Telefono { get; set; }

        public DateTime? FechaDeCreación { get; set; }

        [JsonIgnore]
        public ICollection<Pedidos>? Pedidos { get; set; }
    }

}

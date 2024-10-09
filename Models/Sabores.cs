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
        public string NombreDeSabor { get; set; }

        [Required]
        [StringLength(50)]
        public Decimal ContenidoDeColageno { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(255)]
        public int CantidadEnStock { get; set; }
    }

}


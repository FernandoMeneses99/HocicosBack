using HocicosBack.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HocicosBacks.Models
{ 
    public class Productos
    {
        public int ProductoID { get; set; }
        public object? ProductoId { get; internal set; }
        public string Nombre { get; set; } = string.Empty!;
        public int Descripcion { get; set; }
        public string PrecioDeCompra { get; set; } = "";
        public int PrecioDeVenta { get; set; }
        public string FechaDeCreacion { get; set; } = "";
        public string ID_Proveedor { get; set; } = "";
        public int? SaborID { get; set; }

        [JsonIgnore]
        [ForeignKey("SaborID")] 
        public Sabores? sabores { get; set; }

        [JsonIgnore]
        public ICollection<Sabores>? Sabores { get; set; } 
    }
}
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HocicosBack.Models
{
    public class Sabores
    {
        public int pedidoID { get; set; }
        public int clienteID { get; set; }
        public string clienteName { get; set; }
        [JsonIgnore]
        [ForeignKey("ProductoID")]
        public Productos? Productos { get; set; }

       
    }
}

    

using System.ComponentModel.DataAnnotations;

namespace Entrenamiento_netcore_cliente.Models
{
    public class M_ciudad_request
    {
        [Key]
        public string? id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Nombre { get; set; }
    }
}

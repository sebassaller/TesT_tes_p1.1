using System.ComponentModel.DataAnnotations;

namespace Entrenamiento_netcore_cliente.Models
{
    public class M_Unicod_request
    {
        [Key]
        [Required]
        public string? Id { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Entrenamiento_netcore_cliente.Models
{
    public class M_Factura
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int idCliente { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        [MaxLength(200)]
        public string? Detalle { get; set; }
        [Required]
        public decimal Importe{get;set;} 
       
    }
}

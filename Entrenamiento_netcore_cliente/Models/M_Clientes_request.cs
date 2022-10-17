using System.ComponentModel.DataAnnotations;

namespace Entrenamiento_netcore_cliente.Models
{
    public class M_Clientes_request
    {
        [Key]
        [Required]
        public string? id { get; set; }=string.Empty;
        [Required]
        [MaxLength(50)]
        public string? Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Apellido { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Ciudad { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Domicilio { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Password { get; set; }
        [Required]
        public string? idCiudad { get; set; }
        [Required]
        [MaxLength(50)]
        public byte Habilitado { get; set; }
    }
}

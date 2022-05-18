using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Pais
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Abreviatura { get; set; }

        public int? Poblacion { get; set; }
        public string Descripcion { get; set; }
    }
}
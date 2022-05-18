using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Provincia
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Provincias { get; set; }
    }
}

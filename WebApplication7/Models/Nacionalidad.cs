using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Nacionalidad
    {
        public int Id { get; set; }
        [Required]
        
        public string Situacion { get; set; }
    }
}

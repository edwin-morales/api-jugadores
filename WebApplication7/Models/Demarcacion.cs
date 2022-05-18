using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Demarcacion
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}

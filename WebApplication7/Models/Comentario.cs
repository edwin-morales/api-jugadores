using System;

namespace WebApplication7.Models
{
    public class Comentario 
    {
        public int Id { get; set; }
        public int IdVideo { get; set; }
        public string Texto { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

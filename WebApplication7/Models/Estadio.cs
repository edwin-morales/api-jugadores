using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Estadio
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Capacidad { get; set; }
        public string Direccion { get; set; }
        public string CP { get; set; }
        public string Provincia { get; set; }
        public string Telefono { get; set; }
        public DateTime Inauguracion { get; set; }
        public string Propietario { get; set; }
        public string Dimensiones { get; set; }
        public string OtrasInstalaciones { get; set; }
        public string Localidad { get; set; }

    }
}

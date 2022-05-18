using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Equipo
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string NombreOficial { get; set; }
        public string Direccion { get; set; }
        public string CP { get; set; }
        public int Provincia { get; set; }
        public string Pais { get; set; }
        public string DireccionInternet { get; set; }
        public string Email { get; set; }
        public string Peñas { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string OtrasSecciones { get; set; }  
        public DateTime FechaFundacion { get; set; }

        public string Historia { get; set; }

        public int Estadio { get; set; }

        public string Localidad { get; set; }





    }
}

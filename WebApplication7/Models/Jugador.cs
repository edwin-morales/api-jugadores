using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class Jugador
    {        
        public int Id { get; set; }

        [Required]
        public string NombreFutbolistico { get; set; }

       
        public string Nombre { get; set; }
        public string  Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string LugarDeNacimiento { get; set; }
        public int Provincia { get; set; }
        public int Pais { get; set; }
        public int Pie { get; set; }
        public int Demarcacion { get; set; }
        public int Situacion { get; set; }
        public int Altura{ get; set; }
        public int Peso { get; set; }
        public int Cantera { get; set; }
        public string Internacional { get; set; }
        public string Historia { get; set; }
        public int Representante { get; set; }
        public string PaisNacionalidad { get; set; }
        public string Retirado { get; set; }

    }
}

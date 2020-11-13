using System;
using System.Collections.Generic;
//modelo
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmergenciasChats.EL
{
    public class UsuariosHospitalesEL
    {
      
        //el nombreusuario me sirvira como id 
        public string Username { get; set; }
        public string NombreCompleto { get; set; }
        public string Apellidos { get; set; }
      
        public string Direccion { get; set; }
      
        public string Dui { get; set; }
        public string Telefono { get; set; }
        [RegularExpression("\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}\b", ErrorMessage = "Mail incorrecto")]
        public string Email { get; set; }

        [DisplayName("Imagen")]
        public string Imagen { get; set; }

        public string Password { get; set; }
        public bool Estado { get; set; }
        
    }
}

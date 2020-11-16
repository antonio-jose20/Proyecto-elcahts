using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//using validate campo
using System.ComponentModel;

namespace EmergenciasChats.EL
{
    public class UsuarioClienteEL
    {
     // public  string IdUsuarioC { get; set; }
      public string Username { get; set; }
      public string NombreCompleto { get; set; }
      public string Apellidos { get; set; }
      public string Direccion { get; set; }
      public string Dui { get; set; }
      public string Telefono { get; set; }
        [DisplayName("Imagen")]
        public string Imagen { get; set; }
        [RegularExpression("\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}\b", ErrorMessage = "Mail incorrecto")]
        public string Email { get; set; }
      public string Password { get; set; }

    }
}

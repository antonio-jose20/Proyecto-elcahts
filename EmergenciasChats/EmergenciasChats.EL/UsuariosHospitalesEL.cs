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
      
        public string NombreUsuarios { get; set; }
        public string NombreCompleto { get; set; }
        public string Apellidos { get; set; }
        public string NombreUsuario { get; set; }
        public string Direccion { get; set; }
        public string Dui { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        [DisplayName("Imagen")]
        public string Imagen { get; set; }

        public string Password { get; set; }
    }
}

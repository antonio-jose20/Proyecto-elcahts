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
        public string UserdhID { get; set; }
        public string Username { get; set; }
       // Username, NombreCompleto, Apellidos, Direccion, Dui, Telefono, Email, Imagen, Password,  
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
       public bool state { get; set; }
        
     
        public int like { get; set; }
        //Mensaje
        public int  mensaje { get; set; }

        // contructor vacio

        public UsuariosHospitalesEL() { }

        //construtor parametrizado
        public UsuariosHospitalesEL(string pUsername, string pNombreCompleto, string pEmail, string pImagen)
        {
            Username = pUsername;
            NombreCompleto = pNombreCompleto;
            Email = pEmail;
            Imagen = pImagen;
        }

    }
}

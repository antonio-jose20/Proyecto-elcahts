using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmergenciasChats.EL
{
    public class AdminEL
    { 

        public string IDAdmin { get; set; }
        //public string IdRol { get; set; }
        //Propiedad de Relacion 
        public string Nombres { get; set; }
        [RegularExpression("^[a-zñáéíóúA-ZÑÁÉÍÓÚ _]*$", ErrorMessage = "Solo se permiten letras")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Apellidos { get; set; }
        [RegularExpression("^[a-zñáéíóúA-ZÑÁÉÍÓÚ _]*$", ErrorMessage = "Solo se permiten letras")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Rol { get; set; } 
        public string Sexo { get; set; }
        public string Dui { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }  
        public string Usuario { get; set; }
        //public string Usuario { get; set; }
        //public string Contrasena { get; set; }

        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
          ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //Validacion de datos password
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(15, ErrorMessage = "Longitud entre 6 y 15 caracteres.",
                      MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //public string Image { get; set; }
        public bool Estado { get; set; }
        //Propiedad de navegacion
        //public Rol Rol { get; set; }

    }
}

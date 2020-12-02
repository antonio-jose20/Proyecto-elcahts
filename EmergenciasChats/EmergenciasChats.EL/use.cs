using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// DtaAnnotations para Validar los campos
using System.ComponentModel.DataAnnotations;

namespace EmergenciasChats.EL
{
   public class use
    {
        public string  IDHospital { get; set; }
        //Propiedad de Relacion 
        [RegularExpression("^[a-zñáéíóúA-ZÑÁÉÍÓÚ _]*$", ErrorMessage = "Solo se permiten letras")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombre { get; set; }
        [RegularExpression("^[a-zñáéíóúA-ZÑÁÉÍÓÚ _]*$", ErrorMessage = "Solo se permiten letras")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Rol { get; set; }
        [Required]
        [Display(Name = "Email or Phone")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Please enter a valid email address or phone number")]
        public string Telefono { get; set; }
        //No validado
        public string Direccion { get; set; }
        [MaxLength(50, ErrorMessage = "El {0} no puede superar los {1} caracteres")]
        [Range(8, 10, ErrorMessage = "{0} INCORRECTO !!!")]
        public string NombreUsuario { get; set; }
        [Range(0, short.MaxValue, ErrorMessage = "Debe ingresar un valor numérico.")]
        public string CodigoH { get; set; }
        [RegularExpression("\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}\b", ErrorMessage = "Mail incorrecto")]
        public string Email { get; set; }
        [Compare("Email.Password",
       ErrorMessage = "La clave y la verificación del pwd no son correctas")]
        public string Password { get; set; }
     
        //public string Image { get; set; }
        public bool Estado { get; set; }


    }
}

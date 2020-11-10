using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmergenciasChats.EL
{
    public class HospitalEN
    {
        public string IdHospital { get; set; }

        [RegularExpression("^[a-zñáéíóúA-ZÑÁÉÍÓÚ _]*$", ErrorMessage = "Solo se permiten letras")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombre { get; set; }

        public string Direccion { get; set; }
        [DisplayName("Imagen")]
        public string Imagen { get; set; }
        public string Telefono { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmergenciasChats.EL
{
   public class Hospitales
    {
        public  string IDHospit  {get; set;}
        public string Nombre { get; set; }
        public string   Direccion { get; set; }
        public string Telefono { get; set; } 
        public string photoURL { get; set; }
    }
}

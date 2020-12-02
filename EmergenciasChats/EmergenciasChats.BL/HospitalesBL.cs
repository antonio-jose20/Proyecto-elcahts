using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergenciasChats.DAL;
using EmergenciasChats.EL;

namespace EmergenciasChats.BL
{
   
   public class HospitalesBL
    {
        private HospitalesDAL hDAL = new HospitalesDAL();
        //lista
        public  List<Hospitales> obtenerHospitales()
        {
            return hDAL.ObtenerHospitales(); 
        }
        //eliminar
        public int eliminarHospitales(Hospitales en)
        {
            return hDAL.EliminarHospitales(en);
        }
    }
}

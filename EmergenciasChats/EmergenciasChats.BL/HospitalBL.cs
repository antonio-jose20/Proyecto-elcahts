using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//refe
using EmergenciasChats.EL;
using EmergenciasChats.DAL;

namespace EmergenciasChats.BL
{
    public class HospitalBL
    {
        private HospitalDAL hospitalDal = new HospitalDAL();

        public int AgregarHospital(HospitalEN hospital)
        {
           return hospitalDal.AgregarHospital(hospital);
        }

        public int EliminarHospital(HospitalEN hospital)
        {
            return hospitalDal.EliminarHospital(hospital);
        }
        public List<HospitalEN> ObtenerTodosLosHospitales()
        {
            return hospitalDal.ObtenerTodosLosHospitales();
        }

    }
}

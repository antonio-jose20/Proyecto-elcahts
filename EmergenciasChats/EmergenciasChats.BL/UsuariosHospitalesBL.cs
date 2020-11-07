using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergenciasChats.DAL;
using EmergenciasChats.EL;

namespace EmergenciasChats.BL
{
   public class UsuariosHospitalesBL
    {
        //instancia de la DAL
        private UsuariosHospitalesDAL UhDAL = new UsuariosHospitalesDAL();

       
        public int AgregarUsuarisHospitales(UsuariosHospitalesEL en)
        {
            return UhDAL.AgregarUsuarisHospitales(en);
        }

        public int EliminarUsuariosHospitales(UsuariosHospitalesEL en)
        {
            return UhDAL.EliminarUsuariosHospitales(en);
        }
        //modificar
        public int Modificar(UsuariosHospitalesEL en)
        {
            return UhDAL.Modificar(en);
        }
        public List<UsuariosHospitalesEL> ObtenerUsuarisHospitales()
        {
            return UhDAL.ObtenerUsuarisHospitales();
        }
        //Metodo Obtener por ID
        public UsuariosHospitalesEL GetUsuarioById(string id)
        {
            return UhDAL.GetUsuarioById(id);
        }

    }
}

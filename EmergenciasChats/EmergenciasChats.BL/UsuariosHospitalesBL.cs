﻿using System;
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
        private UsuariosHospitalesDAL UDAL = new UsuariosHospitalesDAL();

       
        public int AgregarUsuariosHospitales(UsuariosHospitalesEL en)
        {
            return UDAL.AgregarUsuariosHospitales(en);
        }

        public int EliminarUsuariosHospitales(UsuariosHospitalesEL en)
        {
            return UDAL.EliminarUsuariosHospitales(en);
        }
        //modificar
        public int Modificar(UsuariosHospitalesEL en)
        {
            return UDAL.Modificar(en);
        }
        public List<UsuariosHospitalesEL> ObtenerUsuarisHospitales()
        {
            return UDAL.ObtenerUsuarisHospitales();
        }
        //Metodo Obtener por ID
        public UsuariosHospitalesEL GetUsuarioById(string id)
        {
            return UDAL.GetUsuarioById(id);
        }

    }
}

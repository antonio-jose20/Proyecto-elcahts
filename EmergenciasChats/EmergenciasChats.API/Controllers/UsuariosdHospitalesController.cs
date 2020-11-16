using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using
using EmergenciasChats.EL;
using EmergenciasChats.BL;

namespace EmergenciasChats.API.Controllers
{
    public class UsuariosdHospitalesController : ApiController
    {


        //instancia de la clase Bl
        UsuariosHospitalesBL UHBL = new UsuariosHospitalesBL();
        //obtener lista 
        public List<UsuariosHospitalesEL> Get()
        {
            return UHBL.ObtenerUsuarisHospitales();
        }
        //obtener  por id
        public UsuariosHospitalesEL Get(string Id)
        {
            return UHBL.GetUsuarioById(Id);
        }
        //metodo para crear 
        public int Post([FromBody] UsuariosHospitalesEL Uen)
        {
            return UHBL.AgregarUsuariosHospitales(Uen);
        }
        //hhh modificar
        public int Put(string id, [FromBody] UsuariosHospitalesEL Uen)
        {
            int r = 0;
            var prod = UHBL.GetUsuarioById(id);
            if (prod.Username !="")
            //if (prod.Username > 0)
            {
                r = UHBL.Modificar(Uen);
            }
            return r;

        }
        //eliminar
        //public int Delete(string id)
        //{
        //    int r = 0;
        //    var prod = UHBL.GetUsuarioById(id);
        //    if (prod.Username != "")
                
        //        {
        
        //        r = UHBL.EliminarUsuariosHospitales(id);
  
        //    }
        //    //retorna mi product eliminado
        //    return r;
        //}



    }
}

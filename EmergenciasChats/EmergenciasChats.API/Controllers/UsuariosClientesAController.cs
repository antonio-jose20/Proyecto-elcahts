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
    public class UsuariosClientesAController : ApiController
    {


        //instancia de la clase Bl
        UsuarioClieteBL UCBL = new UsuarioClieteBL();
        //obtener lista 
        public List<UsuarioClienteEL> Get()
        {
            return UCBL.ObtenerUsuariosHospitales();
        }
        //obtener  por id
        public UsuarioClienteEL Get(string Id)
        {
            return UCBL.GetUsuarioById(Id);
        }
        //metodo para crear 
        public int Post([FromBody] UsuarioClienteEL Uen)
        {
            return UCBL.AgregarUsuarioclientes(Uen);
        }
        //hhh modificar
        public int Put(string id, [FromBody] UsuarioClienteEL Uen)
        {
            int r = 0;
            var prod = UCBL.GetUsuarioById(id);
            if (prod.Username != "")
            //if (prod.Username > 0)
            {
                r = UCBL.ModificarUsuarioclientes(Uen);
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

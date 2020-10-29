using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//
using EmergenciasChats.EL;
using EmergenciasChats.BL;

namespace EmergenciasChats.APP.Controllers
{
    public class UsuariosClientesController : Controller
    {
        UsuarioClieteBL usuariosclientesBL = new UsuarioClieteBL();
        // GET: Hospital
        public ActionResult Index()
        {
            ViewBag.usuariosClientes = usuariosclientesBL.ObtenerUsuariosHospitales();
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        //
        public ActionResult Modificar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Agregarusuariosclientes(UsuarioClienteEL usuariosclientes)
        {
            int r = usuariosclientesBL.AgregarUsuarioclientes(usuariosclientes);
            return Content(Convert.ToString(r));
        }
        //Modificar
        [HttpPost]
        public ActionResult Modificarusuariosclientes(UsuarioClienteEL usuariosclientes)
        {
            try
            {
                int r = usuariosclientesBL.ModificarUsuarioclientes(usuariosclientes);
                return Content(Convert.ToString(r));
            }
            catch (Exception )
            {
                return null;
            }
        
        }

        [HttpPost]
        public ActionResult Eliminarusuariosclientes(UsuarioClienteEL usuariosclientes)
        {
            int r = usuariosclientesBL.EliminarUsuarioclientes(usuariosclientes);
            return Content(Convert.ToString(r));
        }
        // GET: UsuariosClientes
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}
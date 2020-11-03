using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmergenciasChats.BL;
using EmergenciasChats.EL;

namespace EmergenciasChats.APP.Controllers
{
    public class UsuariosHospitalesController : Controller
    {
        // GET: UsuariosHospitales
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //vzvzgxvzcvfxgvhbhg
        UsuariosHospitalesBL usuarioshBL = new UsuariosHospitalesBL();
        public ActionResult Index()
        {
            ViewBag.usuariosHospitales = usuarioshBL.ObtenerUsuarisHospitales();
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }
        //modificar
        public ActionResult Modificar(string id)
        {
            return View(usuarioshBL.GetUsuarioById((id)));
        }
        //public ActionResult Modificar()
        //{
        //    return View();
        //}


        [HttpPost]
        public ActionResult AgregarUsuarisHospitales(UsuariosHospitalesEL en)
        {
            int r = usuarioshBL.AgregarUsuarisHospitales(en);
            return Content(Convert.ToString(r));
        }


        //Modificar
        [HttpPost]
        public ActionResult Modificar(UsuariosHospitalesEL en)
        {
            try
            {
                int r = usuarioshBL.Modificar(en);
                return Content(Convert.ToString(r));
            }
            catch (Exception)
            {
                return null;
            }

        }

        [HttpPost]
        public ActionResult EliminarUsuariosHospitales(UsuariosHospitalesEL en)
        {
            int r = usuarioshBL.EliminarUsuariosHospitales(en);
            return Content(Convert.ToString(r));
        }

    }
}
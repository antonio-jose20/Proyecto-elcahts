using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmergenciasChats.BL;
using System.Data;


//imagen
using System.IO;


using EmergenciasChats.EL;

namespace EmergenciasChats.APP.Controllers
{
    public class HospitalesController : Controller
    { 
        private HospitalesBL hospBL = new HospitalesBL();
        // GET: Hospitales
        public ActionResult Index()
        {
            ViewBag.Hospitales = hospBL.obtenerHospitales();
            return View();
        }

        // DELETE: Hospitales
        [HttpPost]
        public ActionResult EliminarHospitales(Hospitales en)
        {
            try
            {
                int r = hospBL.eliminarHospitales(en);
                return Content(Convert.ToString(r));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
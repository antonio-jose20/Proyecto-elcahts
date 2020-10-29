using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmergenciasChats.EL;
using EmergenciasChats.BL;


namespace EmergenciasChats.APP.Controllers
{
    public class HospitalController : Controller
    {
        HospitalBL hospitalBL = new HospitalBL();
        // GET: Hospital
        public ActionResult Index()
        {
            ViewBag.Hospitales = hospitalBL.ObtenerTodosLosHospitales();
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AgregarHospital(HospitalEN hospital)
        {
            int r = hospitalBL.AgregarHospital(hospital);
            return Content(Convert.ToString(r));
        }

        [HttpPost]
        public ActionResult EliminarHospital(HospitalEN hospital)
        {
            int r = hospitalBL.EliminarHospital(hospital);
            return Content(Convert.ToString(r));
        }

    }
}
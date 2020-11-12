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


        public ActionResult Create(HttpPostedFileBase Imagen)
        {
            /// este es prueba de imagen
              try
            {
                var path = "";
                if (Imagen.ContentLength > 0)
                {
                    if ((Path.GetExtension(Imagen.FileName).ToLower() == ".jpg") || (Path.GetExtension(Imagen.FileName).ToLower() == ".png"))
                    {
                        path = Path.Combine(Server.MapPath("~/Content/img/perfiles/"), Imagen.FileName);

                    }

                }
               // AgregarUsuarisHospitales(student);
                ModelState.AddModelError(string.Empty, "Added Successfully");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            ////este es prueba de imagen
            return View();
        }
        //modificar
        public ActionResult Modificar(string id)
        {
            return View(usuarioshBL.GetUsuarioById(id));

        }
    


        [HttpPost]
        public ActionResult AgregarUsuarisHospitales(UsuariosHospitalesEL en)
        {
            int r = usuarioshBL.AgregarUsuarisHospitales(en);
            return Content(Convert.ToString(r));
        }


        //Modificar
        //[HttpPost]
        //public ActionResult Modificar(UsuariosHospitalesEL en)
        //{
        //    try
        //    {
        //        int r = usuarioshBL.Modificar(en);
        //        return Content(Convert.ToString(r));
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }

        //}
        // Nvo Metodo de Modificar
        [HttpPost]
        public ActionResult Modificar(UsuariosHospitalesEL en)
        {


          try
            {
                if (en != null)
                {
                    int r = usuarioshBL.Modificar(en);
                    return Content(Convert.ToString(r));
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        //


            // Update records
        //public JsonResult update_record(UsuariosHospitalesEL rs)
        //{
        //    string res = string.Empty;
        //    try
        //    {
        //        usuarioshBL.Modificar(rs);
        //        res = "Updated";
        //    }
        //    catch (Exception)
        //    {
        //        res = "failed";
        //    }
        //    return Json(res, JsonRequestBehavior.AllowGet);

        //}
        ///

        [HttpPost]
        public ActionResult EliminarUsuariosHospitales(UsuariosHospitalesEL en)
        {
            try
            {
                int r = usuarioshBL.EliminarUsuariosHospitales(en);
                return Content(Convert.ToString(r));
            }
            catch (Exception)
            {
                return null;
            }
        }
        ////buscar pr id 


        public ActionResult GetUsuarioById(string id)

        {
            try
            {

                if (id != null)
                {

                    return Content(Convert.ToString(usuarioshBL.GetUsuarioById(id)));

                }
                else
                {
                    return null;
                }
            }
            catch (Exception )
            {
                return null;
            }
            
            //return Content(Convert.ToString(r));
        }
    


    }
}
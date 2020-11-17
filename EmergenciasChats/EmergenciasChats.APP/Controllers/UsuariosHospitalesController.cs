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
      
        UsuariosHospitalesBL usuarioshBL = new UsuariosHospitalesBL();

        //ruta para guardar imagenes
        //static string ruta = @"C:\Users\JC\Desktop\ControlPedidos\ControlPedidos.InterfazMVC\Imagenes";
        static string ruta = @"C:\Users\Antonio\Desktop\ProyectoChats\Proyecto-elcahts\EmergenciasChats\EmergenciasChats.APP\Content\Images";
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
            return View(usuarioshBL.GetUsuarioById(id));

        }
    


        [HttpPost]
        public ActionResult AgregarUsuariosHospitales(UsuariosHospitalesEL en)
        {

            try
            {
                if (en != null)
                {
  
                    int r = usuarioshBL.AgregarUsuariosHospitales(en);
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




        ///agregar PRUEBA

        [HttpPost]
        public ActionResult agregar(UsuariosHospitalesEL en, HttpPostedFileBase Imagen)
        {
            try
            {
                ///
                var path = "";
                if (Imagen.ContentLength > 0)
                {
                    if ((Path.GetExtension(Imagen.FileName).ToLower() == ".jpg") || (Path.GetExtension(Imagen.FileName).ToLower() == ".png"))
                    {
                        // path = Path.Combine(Server.MapPath("~/Content/img/perfiles/"), Imagen.FileName);
                        path = Path.Combine(Server.MapPath("~/Content/Images/"), Imagen.FileName);

                    }

                }
                //

                if (en != null)
                {

                    int r = usuarioshBL.AgregarUsuariosHospitales(en);
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
        public ActionResult Edit(UsuariosHospitalesEL en)
        {
            string res = string.Empty;
            if   (en!= null)
            try
            {
                    //usuarioshBL.Modificar(en);
                    int r = usuarioshBL.Modificar(en);
                    return Content(Convert.ToString(r));

            //      res = "Updated";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);

        }
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
        [HttpGet]

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

        //Accion para dar like 
        [HttpPost]
        public int like(int id)
        {
            int r = 0;
            try
            {
                if (id > 0)
                {
                  return usuarioshBL.like(id);
                }
                return r;
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return -1;
            }
        }

        //Accion para el mensaje 
        [HttpPost]
        public int mensaje(int id)
        {
            int r = 0;
            try
            {
                if (id > 0 )
                {
                    return usuarioshBL.mensaje(id);
                   // return Content(Convert.ToString(usuarioshBL.mensaje(id)));
                }
                return r;
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return -1;
            }
        }

        

    }
}
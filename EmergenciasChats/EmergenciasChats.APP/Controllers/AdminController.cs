using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//cerra sesion
using System.Web.Security;
//
using EmergenciasChats.BL;
using EmergenciasChats.EL;

namespace EmergenciasChats.APP.Controllers
{
    public class AdminController : Controller
    {
        AdminBL bl = new AdminBL();
        // GET: Admin
        public ActionResult Index()
        {    
            ViewBag.Admins = bl.GetAdmiList();
            return View();
        }
        
        //Create
        public ActionResult Create()
        {
            return View();
        }
        //edit
        public ActionResult ActualizarR(string id)
        {
            return View(bl.GetUsuarioById(id));
        }
        public ActionResult Login()
        {
            return View();
        }

        //guardar
        [HttpPost]
        public ActionResult Create(AdminEL en)
        {
         try
            {
                int r = bl.AddAdmin(en);
                return Content(Convert.ToString(r));
            }
            catch (Exception)
            {
                return null;
            }
        }
        //Acualizar
        [HttpPost]
        public ActionResult ActualizarR(AdminEL en)
        {

            string res = "";
            try
            {
                if (en != null)
                {
                    int r = bl.ActualizarR(en);
                    return Content(Convert.ToString(r));
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //eliminar
        [HttpPost]
        public ActionResult EliminarAdmin(AdminEL en)
        {
          try
            {
                int r = bl.EliminarAdmin(en);
                return Content(Convert.ToString(r));
            }
            catch(Exception)
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

                    return Content(Convert.ToString(bl.GetUsuarioById(id)));

                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //BUSCAR 
        /*public JsonResult buscarPorNombre (string nombre)
        {
            try
            {
                if (nombre != null)
                {
                   // return Content(Convert.ToString(bl.(nombre)));
                }
                else
                {
                    return null;
                }

            }
            catch(Exception e)
            {
                throw e;
            }
        }*/




        /*
           //buscar por nombre
        public JsonResult buscarCursoPorNombre(string nombre)
        {
            MatriculaDataContext db = new MatriculaDataContext();
            //variable que devolvera los valores    //Equals compara hailitado //constains devuelve campo especifico
            var busqueda = db.Curso.Where(p => p.BHABILITADO.Equals(1) && p.NOMBRE.Contains(nombre))
                //tolist retorna la lista
                .Select(p => new { p.IIDCURSO, p.NOMBRE, p.DESCRIPCION }).ToList();
            return Json(busqueda, JsonRequestBehavior.AllowGet);

        }*/

        //LOGIN
        [HttpPost]
        public ActionResult Login(AdminEL en)
        {
            try
            {
                int r = bl.Login(en);
                return Content(Convert.ToString(r));
            }
            catch(Exception )
            {
                return null;
            }
            
        }


        //cerrar sesion
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }

    }
}
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
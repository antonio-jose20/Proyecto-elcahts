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
        public ActionResult Login()
        {
            return View();
        }


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
            catch (Exception)
            {
                return null;
            }

            //return Content(Convert.ToString(r));
        }
        ////LOGIN 

        //[HttpPost]
        //public ActionResult Login(AdminEL admin)
        //{
        //   //var val = (admin);
        //   //   if (admin.Email == val.Email && admin.Password == val.Password)
        //    if (string.IsNullOrEmpty(admin.Email) || string.IsNullOrEmpty(admin.Password))
        //    {
        //        ViewBag.Error = "Login o password no pueden estar vacíos";
        //        return View(bl.Login(admin));
        //    }
        //    // Damos de alta el usuario en la BBDD y redireccionamos
        //    return RedirectToAction("UsuariosClientes", "Index");

        //}








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
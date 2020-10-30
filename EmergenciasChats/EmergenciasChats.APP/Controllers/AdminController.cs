using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            ViewBag.Admins = bl.GetAdminList();
            return View();
        }

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
            int r = bl.AddAdmin(en);
            return Content(Convert.ToString(r));
        }
        //eliminar
        [HttpPost]
        public ActionResult EliminarAdmin(AdminEL admin)
        {
            int r = bl.EliminarAdmin(admin);
            return Content(Convert.ToString(r));
        }
        //LOGIN 

        [HttpPost]
        public ActionResult Login(AdminEL admin)
        {
           var val = (admin);
              if (admin.Email == val.Email && admin.Password == val.Password)
            //if (string.IsNullOrEmpty(admin.Email) || string.IsNullOrEmpty(admin.Password))
            {
                ViewBag.Error = "Login o password no pueden estar vacíos";
                return View(bl.Login(admin));
            }
            // Damos de alta el usuario en la BBDD y redireccionamos
            return RedirectToAction("UsuariosClientes", "Index");

        }

    }
}
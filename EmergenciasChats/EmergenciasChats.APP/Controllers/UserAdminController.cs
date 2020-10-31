using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmergenciasChats.EL;
using EmergenciasChats.BL;

namespace EmergenciasChats.APP.Controllers
{
    public class UserAdminController : Controller
    {
        UserAdminBL bl = new UserAdminBL();

        public ActionResult Login()
        {
            return View();
        }

        // GET: UserAdmin
        public ActionResult AgregarUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarUser(UserAdminEN en)
        {
            int r = bl.AgregarUserAdmin(en);
            return Content(Convert.ToString(r));
        }

        [HttpPost]
        public ActionResult Login(UserAdminEN en)
        {
            int r = bl.Login(en);
            return Content(Convert.ToString(r));
        }
    }
}
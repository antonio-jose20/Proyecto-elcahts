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


        [HttpPost]
        public ActionResult Create(AdminEL en)
        {
            int r = bl.AddAdmin(en);
            return Content(Convert.ToString(r));
        }

    }
}
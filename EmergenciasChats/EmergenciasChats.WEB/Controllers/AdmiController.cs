﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
//using  referenia de proyectos
using EmergenciasChats.BL;
using EmergenciasChats.EL;
//using System.Web.Security;
// configurar firebase  
//using FireSharp.Interfaces;
//////using FireSharp.Config;
//////using FireSharp.Interfaces;
//////using FireSharp.Response;


namespace EmergenciasChats.WEB.Controllers
{


public class AdmiController : Controller  
    {

      //  //Intancias para acceder a los metodos de las clases BL Usuarios
      //  private AdminBL administracionBL = new AdminBL();
      //  // GET: Admin 
      //  public ActionResult Index()
      //  {
      //      return View();
      //  }
      //  //Lista de datos
      //  //Crear nuevs datos

      //  public ActionResult Create()
      //  {
      //      return View();
      //  }


      //  //Lista de datos
      //  public ActionResult AdminLista()
      //  {
      //      return View(administracionBL.GetAdminList());
      //  }
      //  //[Authorize]
      //  public JsonResult ListAdministracion()
      //  {
      //      return Json(administracionBL.GetAdminList(), JsonRequestBehavior.AllowGet);
      //  }


      //  //[Authorize]
      //  public JsonResult ListAdmin(string id) 
      //  {
      //      return Json(administracionBL.FindAdmin(id), JsonRequestBehavior.AllowGet);
      //  }
      //  //metodo editar
      //  public ActionResult Edit(string id)
      //  {

      //      return View(administracionBL.FindAdmin((id)));
      //  }

      //  public ActionResult Delete(string id)
      //  {

      //      return View(administracionBL.FindAdmin((id)));
      //  }
      //   //
      //  [Authorize]
      //  public ActionResult Details(string id)
      //  {

      //      return View(administracionBL.FindAdmin((id)));
      //  }
      
      //  // Crear

      //  [HttpPost]
      //  public int Create(AdminEL admin)
      //  {
      //      int r = 0;
      //      try
      //      {
      //          if (admin != null)
      //          {
      //              return administracionBL.AddAdmin(admin);
      //          }
      //          return r;
      //      }
      //      catch (Exception ex)
      //      {
      //          ViewBag.error = ex.Message;
      //          return -1;
      //      }
      //  }



      //  [HttpPost]
      //  public int Edit(AdminEL administrador)
      //  {
      //      if (administrador != null)
      //      {

      //          return administracionBL.Editar(administrador);
      //      }
      //      else
      //      {
      //          return -1;
      //      }
      //  }

      //  [HttpPost]
      //  public int Delete(string id, FormCollection collection)
      //  {
      //      if (id != null)
      //      {

      //          return administracionBL.Delete(id);
      //      }
      //      else
      //      {
      //          return -1;
      //      }
      //  }

      //  //   Configuraion a firebase para  el login 
      //  //IFirebaseConfig config = new FirebaseConfig
      //  //{
      //  //    AuthSecret = "CPT7izztGnLhDZ8RFM3lfSiJxLOxsAf6UnrERsOd",
      //  //     BasePath = "https:// aplicacion-web-de- emergencias.firebaseio.com/"


      ////IFirebaseClient client;     



      //  //[HttpPost]
      //  //public ActionResult Logi(AdminEL administracion)
      //  //{
      //  //    //Looping to get the match data using foreach para obtener datos de firebase
      //  //    client = new FireSharp.FirebaseClient(config);
      //  //    FirebaseResponse response = client.Get("Admin/");
      //  //    Dictionary<string, AdminEL> result = response.ResultAs<Dictionary<string, AdminEL>>();

      //  //    foreach (var get in result)
      //  //    {
      //  //        string userresult = get.Value.Email;
      //  //        string passresult = get.Value.Password;

      //  //        if (administracion.Email == userresult && administracion.Password == passresult)
      //  //        {
      //  //            FormsAuthentication.SetAuthCookie(administracion.Email, false);
      //  //            Session["user"] = administracionBL.ListAdministra();
      //  //            return RedirectToAction("AdminLista", "Admi");
      //  //        }
      //  //        else
      //  //        {
      //  //            return RedirectToAction("Index", "Admi");
      //  //        }
      //  //    }
      //  //    return View();
      //  //}

      //  //LOGIN 

      //  [HttpPost]
      //  public ActionResult Login(AdminEL admin)
      //  {
      //      if (string.IsNullOrEmpty(admin.Email) || string.IsNullOrEmpty(admin.Password))
      //      {
      //          ViewBag.Error = "Login o password no pueden estar vacíos";
      //          //return View(admin);
      //          return View(administracionBL.Login(admin));
      //      }
      //      // Damos de alta el usuario en la BBDD y redireccionamos
      //      return RedirectToAction("Home", "Index");

      //  }
      //  //
      //  [HttpPost]
      //  public ActionResult Index(AdminEL admin)
      //  {
      //      if (string.IsNullOrEmpty(admin.Email) || string.IsNullOrEmpty(admin.Password))
      //      //if (admin != null)
      //      {
      //          ViewBag.Error = "Login o password no pueden estar vacíos";
      //          return View(administracionBL.Login(admin));
      //      }
      //      // Damos de alta el usuario en la BBDD y redireccionamos
      //      return RedirectToAction("Index", "Home");

      //  }
        //FIN DE METODOS
    }
}
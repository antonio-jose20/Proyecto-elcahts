using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
//using  referenia de proyectos
using EmergenciasChats.BL;
using EmergenciasChats.EL;

namespace EmergenciasChats.WEB.Controllers
{


    public class UsuarioHController : Controller
    {
        //instancia de la clase BL
        private UsuarioHBL usuarioHBL = new UsuarioHBL();

        public ActionResult Index()
        {
            return View();
        }
        //Action Agregar
        public ActionResult Create()
        {
            return View();
        }

        //Action Editar
        public ActionResult Edit(string id)
        {

            return View(usuarioHBL.GetUsuarioById((id)));
        }
        //Action Details
        [HttpGet]
        public ActionResult DetailsUser(string id)
        {
            return View(usuarioHBL.DetailsUser((id)));
        }

        //Action Listar
        //[HttpGet]
        //public int UsuarioHLista(UsuarioH id)
        //{
        //            return Json(usuarioHBL.ListaUsuario(id), JsonRequestBehavior.AllowGet);

        //}
        public ActionResult UsuarioHLista()
        {
            return View(usuarioHBL.ListaUsuario());
        }
        //[Authorize]
        public JsonResult ListUsuarioH()
        {
            return Json(usuarioHBL.ListaUsuario(), JsonRequestBehavior.AllowGet);
        }

        //obtener por id
        public JsonResult ListAUsuario(string id)
        {
            return Json(usuarioHBL.GetUsuarioById(id), JsonRequestBehavior.AllowGet);
        }


        // Action Eliminar
        public ActionResult Delete(string id)
        {

            return View(usuarioHBL.GetUsuarioById((id)));
        }
        //Detalles


        //metodo Guardar
        [HttpPost]
        public int Create(UsuarioH usuarioH)
        {
            int r = 0;
            try
            {
                if (usuarioH != null)
                {
                    return usuarioHBL.AddUser(usuarioH);
                }
                return r;
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return -1;
            }
        }

        //Metodo Editar
        [HttpGet]
        public int Edit(UsuarioH usuarioH)
        {
            if (usuarioH != null)
            {

                return usuarioHBL.UpdateUser(usuarioH);
            }
            else
            {
                return -1;
            }
        }
        //////Metodo Detalle
        ////[HttpGet]
        ////public int DetailsUser(UsuarioH usuarioH)
        ////{
        ////    if(usuarioH !=null)
        ////    {
        ////        return usuarioH.DetailsUser(usuarioH);
        ////    }
        ////    else
        ////    {
        ////        return -1;
        ////    }
        ////}

        [HttpGet]
        public int Delete(UsuarioH usuarioh, FormCollection collection)
        {
            if (usuarioh != null)
            {

                return usuarioHBL.DeleteUser(usuarioh);
            }
            else
            {
                return -1;
            }
        }




        [HttpPost]
        public ActionResult Login(UsuarioH usuarioH)
        {

            if (usuarioH != null)
            {
                return View(usuarioHBL.Login(usuarioH));
                // return RedirectToAction("AdminLLista", "Admi");
            }
            else
            {
                return RedirectToAction("login", "UsuarioH");
            }
        }


    }
}
















































        //login
        //public Boolean login(UserAdmin en)
        //{
        //    return _bl.login(en);
        //}
        //login


























        ///primer metodo
        //crear nuevos datos
        //public ActionResult Create()
        //{
        //    return View();
        //}







        ////Lista de datos
        //public ActionResult UsuarioHLista()
        //{
        //    return View(usuarioHBL.ListaUsuario());
        //}
        ////[Authorize]
        //public JsonResult ListUsuarioH()
        //{
        //    return Json(usuarioHBL.ListaUsuario(), JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult ListAUsuario(string id)
        //{
        //    return Json(usuarioHBL.FindUsuarioH(id), JsonRequestBehavior.AllowGet);
        //}



        ////metodo Editar
        //public ActionResult Edit(string id)
        //{

        //    return View(usuarioHBL.FindUsuarioH((id)));
        //}


        ////metodo Guardar
        //[HttpPost]
        //public int Create(UsuarioH usuarioH)
        //{
        //    int r = 0;
        //    try
        //    {
        //        if (usuarioH != null)
        //        {
        //            return usuarioHBL.Guardar(usuarioH);
        //        }
        //        return r;
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.error = ex.Message;
        //        return -1;
        //    }
        //}


        ////Metodo Editar
        //[HttpPost]
        //public int Edit(UsuarioH usuarioH)
        //{
        //    if (usuarioH != null)
        //    {

        //        return usuarioHBL.Editar(usuarioH);
        //    }
        //    else
        //    {
        //        return -1;
        //    }
        //}


        ///priemr metod







//    }

//}
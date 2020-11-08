using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmergenciasChats.BL;
using System.Data;
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
    
        //public JsonResult Get_databyid(int id)
        //{
        //    DataSet ds = dblayer.get_recordbyid(id);
        //    List<register> listrs = new List<register>();
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        listrs.Add(new register
        //        {
        //            Sr_no = Convert.ToInt32(dr["Sr_no"]),
        //            Email = dr["Email"].ToString(),
        //            Password = dr["Password"].ToString(),
        //            Name = dr["Name"].ToString(),
        //            Address = dr["Address"].ToString(),
        //            City = dr["City"].ToString()
        //        });
        //    }
        //    return Json(listrs, JsonRequestBehavior.AllowGet);
        //}




    }
}
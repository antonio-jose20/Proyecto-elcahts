using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencias de proyecto
using EmergenciasChats.EL;
// configurar firebase     
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
  
namespace EmergenciasChats.DAL 
{
    public  class AdminDAL
    {



        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "CPT7izztGnLhDZ8RFM3lfSiJxLOxsAf6UnrERsOd",
            BasePath = "https://aplicacion-web-de-emergencias.firebaseio.com/"
        };


        public List<AdminEL> GetAdminList()
        {
            List<AdminEL> en = new List<AdminEL>();
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response =  client.Get("admin");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
                foreach (var item in data)
                {
                    en.Add(JsonConvert.DeserializeObject<AdminEL>(((JProperty)item).Value.ToString()));
                }
                return en;
            }
            catch (Exception  e)
            {
                throw e;
            }
        }
        //

        public int AddAdmin(AdminEL en)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var data = en;
                PushResponse response = client.Push("admin/", data);
                data.IDAdmin = response.Result.name;
                SetResponse setResponse = client.Set("admin/" + data.IDAdmin, data);
                return 1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

      
        //Modificar
        public int ModificarAdmin(AdminEL en)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var response = client.Update("UsuariosHospitales/" + en.IDAdmin, en);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }


        //Eliminar
        public int EliminarAdmin(AdminEL admin)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var response = client.Delete("admin/" + admin.IDAdmin);
                return 1; 
            }
            catch(Exception)
            {
                return 0;
            }
        }

        //  //Obtener por Id
        public AdminEL GetUsuarioById(string id)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Get("admin/" + id);
                AdminEL data = JsonConvert.DeserializeObject<AdminEL>(response.Body);
                return (data);


            }
            catch (Exception)
            {
                return null;
            }
        }

        //LOGIN
        public int Login(AdminEL pEn)
        {
            List<AdminEL> en = new List<AdminEL>();
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Get("admin");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
                int inc = 0;
                foreach (var item in data)
                {
                    en.Add(JsonConvert.DeserializeObject<AdminEL>(((JProperty)item).Value.ToString()));

                    if (en[inc].Usuario == pEn.Usuario && pEn.Password == en[inc].Password)
                   // if (en[inc].Usuario == pEn.Usuario && pEn.Password == en[inc].Password && en[inc].Email == pEn.Email)
                    {
                        return 1;
                    }
                    inc++;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public int AddAdmin(AdminEL en)
        //{


        //    try
        //    {
        //        en.fecha_registro = (DateTime.Today.ToString("dd-MM-yyyy")).ToString() + (DateTime.Now.ToString("HH:mm:ss")).ToString();
        //        en.IDAdmin = (DateTime.Today.ToString("dd-MM-yyyy")).ToString();
        //        //en.IDAdmin
        //        IFirebaseClient client = new FireSharp.FirebaseClient(config);
        //        var response = client.Set("admin/" + en.IDAdmin, en);
        //        return 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}

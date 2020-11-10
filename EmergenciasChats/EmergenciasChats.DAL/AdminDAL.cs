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
            catch (Exception)
            {
                return en;
            }
        }

        public int AddAdmin(AdminEL en)
        {
            try
            {
                en.IDAdmin = (DateTime.Today.ToString("dd-MM-yyyy")).ToString() + (DateTime.Now.ToString("HH:mm:ss")).ToString();
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var response = client.Set("admin/" + en.IDAdmin, en);
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
                ////pROPIO METODO
                // IFirebaseClient client = new FireSharp.FirebaseClient(config);
                //var res = client.Get("Hospital/" + id);
                //UsuarioH _usuarioH = res.ResultAs<UsuarioH>();
                //return _usuarioH;


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
                    {
                        return 1;
                    }
                    inc++;
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }




        //// instancia de iFirebase 
        //IFirebaseConfig config = new FirebaseConfig
        //{
        //    AuthSecret = "CPT7izztGnLhDZ8RFM3lfSiJxLOxsAf6UnrERsOd", 
        //    BasePath = "https: //aplicacion-web-de-emergencias.firebaseio.com/"


        //};

        //IFirebaseClient client;

        ////validar campo ingresados a firebase  para login

        //////////private readonly string Email;
        //////////private readonly string Password;
        ////Metodo de guardar
        //public int InsertAdmin(AdminEL admin) 
        //{

        //    int r = 1;
        //    if ((admin.Nombres != null) && (admin.Apellidos != null) && (admin.Sexo != null)  && (admin.Rol != null)  && (admin.Telefono > 0) 
        //        && (admin.Direccion != null)  && (admin.NameUser != null ) && (admin.Email != null)  && (admin.Password != null))
        //    {
        //        AddAdminToFirebase(admin);
        //        return r;
        //    }
        //    else
        //    { 
        //        return 0;
        //    }

        //}

        ////metodo get  lista
        //public List<AdminEL> ListAdministra()
        //{

        //    {
        //        client = new FireSharp.FirebaseClient(config);
        //        FirebaseResponse response = client.Get("Admin");
        //        dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);

        //        var list = new List<AdminEL>();
        //        foreach (var item in data)
        //        {
        //            list.Add(JsonConvert.DeserializeObject<AdminEL>(((JProperty)item).Value.ToString()));
        //        }
        //        return (list);
        //    }
        //}


        //public void AddAdminToFirebase(AdminEL administrador)
        //{ 

        //    try 
        //    {
        //        client = new FireSharp.FirebaseClient(config);
        //        var data = administrador;
        //        PushResponse response = client.Push("Admin/", data);
        //        SetResponse setResponse = client.Set("Admin/" + data.IDAdmin, data);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }


        //}

        //// Funcion de Modificar
        //public int Editar(AdminEL administrador)
        //{
        //    int r = 0;
        //    try
        //    {
        //        client = new FireSharp.FirebaseClient(config);
        //        //FirebaseResponse response = client.Set("Admin/" + administrador.IDAdmin, administrador);
        //        FirebaseResponse response = client.Update("Admin/" + administrador.IDAdmin, administrador);
        //        return r;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        ////buscar por id
        //public AdminEL FindAdmin(string id)
        //{
        //    client = new FireSharp.FirebaseClient(config);
        //    FirebaseResponse response = client.Get("Admin/" + id);
        //    AdminEL data = JsonConvert.DeserializeObject<AdminEL>(response.Body);
        //    return (data);
        //}

        ////eliminar
        //public int Delete(string id)
        //{
        //    int r = 0;
        //    try
        //    {
        //        client = new FireSharp.FirebaseClient(config);
        //        FirebaseResponse response = client.Delete("Admin/" + id);
        //        //FirebaseResponse response = client.Delete("Admin/" + id);

        //    }
        //    catch
        //    {
        //        r = -1;
        //    }

        //    return r;

        //}
        ////Metodo Login
        //public int login(AdminEL _admin)
        //{
        //    try
        //    {
        //        IFirebaseClient client = new FireSharp.FirebaseClient(config);
        //        FirebaseResponse response = client.Get("Admin");
        //        dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);

        //        foreach (var item in data)
        //        {
        //            var val = (JsonConvert.DeserializeObject<AdminEL>(((JProperty)item).Value.ToString()));
        //            if (_admin.Email == val.Email && _admin.Password == val.Password)
        //            {
        //                return 1;
        //            }
        //            else
        //            {
        //                return -1;
        //            }

        //        }
        //        return 1;

        //    }
        //    catch (Exception)
        //    {
        //        return -1;
        //    }
        //}



        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//referencias de proyecto EL
using EmergenciasChats.EL;
// configurar firebase     
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//enviar imagen
using System.Web;



namespace EmergenciasChats.DAL
{
   public class UsuarioHDAL
    {
        // Instancia de config de firebase
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "CPT7izztGnLhDZ8RFM3lfSiJxLOxsAf6UnrERsOd",
            BasePath = "https://aplicacion-web-de-emergencias.firebaseio.com/"


        };
        //establecer conexion a firebase message de error and exit
        IFirebaseClient client;
   
        //Metodo de guardar
        public int AddUser(UsuarioH usuarioH)
        {
            try
            {
                 usuarioH.IDHospital = (DateTime.Today.ToString("dd-MM-yyyy")).ToString() + (DateTime.Now.ToString("HH:mm:ss")).ToString();
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var response = client.Set("Hospital/" + usuarioH.IDHospital, usuarioH);
                return 1;

            }
            catch (Exception)
            {
                return 0;
            }

        }

        //metodo modificar 
        public int UpdateUser(UsuarioH usuarioH)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var response = client.Update("Hospital/" + usuarioH.IDHospital, usuarioH);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        //Metodo Detalle 
        public int DetailsUser( string id)
        {
            int r = 0;
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Get("Hospital/" + id);
                UsuarioH data = JsonConvert.DeserializeObject<UsuarioH>(response.Body);
                return r;
            }
            catch(Exception )
            {
                return -1;
            }

        }

        //Metodo de Eliminar
        public int DeleteUser(UsuarioH usuarioH)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var response = client.Delete("Hospital/" + usuarioH.IDHospital);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        //Obtener por Id
        public UsuarioH GetUsuarioById(string id)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                //pROPIO METODO
                //var res = client.Get("Hospital/" + id);
                //UsuarioH _usuarioH = res.ResultAs<UsuarioH>();
                //return _usuarioH;




                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Get("Hospital/" + id);
                UsuarioH data = JsonConvert.DeserializeObject<UsuarioH>(response.Body);
                return (data);


            }
            catch (Exception)
            {
                return null;
            }
        }
   
        //Metodo   listar
        public List<UsuarioH> ListAUsuario()
        {

            {
                 client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Get("Hospital");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);

                var list = new List<UsuarioH>();
                foreach (var item in data)
                {
                    list.Add(JsonConvert.DeserializeObject<UsuarioH>(((JProperty)item).Value.ToString()));
                }
                return (list);


            }
        }

        //Metodo Login
        public Boolean login(UsuarioH _usuarioH)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Get("Hospital");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);

                foreach (var item in data)
                {
                    var val = (JsonConvert.DeserializeObject<UsuarioH>(((JProperty)item).Value.ToString()));
                    if (_usuarioH.Email == val.Email && _usuarioH.Password == val.Password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                return false;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}






















































//METODO EN LA DAL DE GUARADAR

//// usuarioH.IDHospital = (DateTime.Today.ToString("dd-MM-yyyy")).ToString() + (DateTime.Now.ToString("HH:mm:ss")).ToString();
// IFirebaseClient client = new FireSharp.FirebaseClient(config);
// //prueba
// var data = usuarioH;
// //prueba
// var response = client.Push("Hospital/" + usuarioH.IDHospital, usuarioH);
// //
//// PushResponse response = client.Push("Students/", data);
// usuarioH.IDHospital = response.Result.name;
// //
// return 1;






































//////Primer codigo 
////public int Guarda(UsuarioH usuarioH)
////{

////    int r = 1;
////    if ((usuarioH.Nombre != null) && (usuarioH.NombreUsuario != null) && (usuarioH.Rol != null) && (usuarioH.Telefono > 0)
////        && (usuarioH.Direccion != null) && (usuarioH.CodigoH != null) && (usuarioH.Email != null) && (usuarioH.Password != null))
////    {
////        AddUsuarioHToFirebase(usuarioH);
////        return r;
////    }
////    else
////    {
////        return 0;
////    }

////}


//////metodo get  lista
////public List<UsuarioH> ListAUsuario()
////{

////    {
////        client = new FireSharp.FirebaseClient(config);
////        FirebaseResponse response = client.Get("Hospital");
////        dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);

////        var list = new List<UsuarioH>();
////        foreach (var item in data)
////        {
////            list.Add(JsonConvert.DeserializeObject<UsuarioH>(((JProperty)item).Value.ToString()));
////        }
////        return (list);
////    }
////}




//////metodo de guardar 
////public void AddUsuarioHToFirebase(UsuarioH usuarioH)
////{

////    try
////    {
////        client = new FireSharp.FirebaseClient(config);
////        var data = usuarioH;
////        PushResponse response = client.Push("Hospital/", data);
////        // data.HospitalID = response.Result.name;
////        SetResponse setResponse = client.Set("Hospital/" + data.IDHospital, data);
////        //

////    }
////    catch (Exception ex)
////    {
////        throw ex;
////    }


////}



////// Funcion de Modificar
////public int Modificar(UsuarioH usuarioH)
////{
////    int r = 0;
////    try
////    {
////        client = new FireSharp.FirebaseClient(config);
////        FirebaseResponse response = client.Set("Hospital/" + usuarioH.IDHospital, usuarioH);
////        return r;
////    }

////    catch (Exception ex)
////    {
////        throw ex;
////    }
////}


//////buscar por id
////public UsuarioH FindUsuarioH(string id)
////{
////    client = new FireSharp.FirebaseClient(config);
////    FirebaseResponse response = client.Get("Hospital/" + id);
////    UsuarioH data = JsonConvert.DeserializeObject<UsuarioH>(response.Body);
////    return (data);
////}

//////eliminar
////public int Delete(string id)
////{
////    int r = 0;
////    try
////    {
////        client = new FireSharp.FirebaseClient(config);
////        FirebaseResponse response = client.Delete("Hospital/" + id);

////    }
////    catch
////    {
////        r = -1;
////    }

////    return r;

////}

//////prim cod....



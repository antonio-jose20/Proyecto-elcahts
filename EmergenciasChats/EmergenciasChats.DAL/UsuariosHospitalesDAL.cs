using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergenciasChats.EL;
// configurar firebase     
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EmergenciasChats.DAL
{
   public  class UsuariosHospitalesDAL
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "CPT7izztGnLhDZ8RFM3lfSiJxLOxsAf6UnrERsOd",
            BasePath = "https://aplicacion-web-de-emergencias.firebaseio.com/"
        };


        public int AgregarUsuarisHospitales(UsuariosHospitalesEL en)
        {
            try
            {

                en.NombreUsuario = (DateTime.Today.ToString("dd-MM-yyyy")).ToString();
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var response = client.Set("UsuariosHospitales/" + en.NombreUsuario, en);
                return 1;
                //en.NombreUsuario = (DateTime.Today.ToString("dd-MM-yyyy")).ToString() + (DateTime.Now.ToString("HH:mm:ss")).ToString();
               //////////////////////////////////////////////////7 en.NombreUsuario = (DateTime.Today.ToString("dd-MM-yyyy")).ToString();
 


                //IFirebaseClient client = new FireSharp.FirebaseClient(config);
                //var response = client.Set("UsuariosHospitales/" + en.NombreUsuario, en);
                //return 1;


                ///////PROBAR NUEVO ME
               //////////////////////////////////////////////// IFirebaseClient client = new FireSharp.FirebaseClient(config);
                //var data = en;
                /*SetResponse*/
                ////////////////////////////////////////var response = client.Set("UsuariosHospitales/" + en.NombreUsuario, en);
              // data.NombreUsuario = response.Result.name;
               // SetResponse setResponse = client.Set("UsuariosHospitales/" + data.NombreUsuario, data);
         
                ////////////////////////////////////////////////////////////////return 1;
                ////////////Probar new metodo
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //listar
        public List<UsuariosHospitalesEL> ObtenerUsuarisHospitales()
        {
            List<UsuariosHospitalesEL> UsuarisHospitales = new List<UsuariosHospitalesEL>();
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Get("UsuariosHospitales");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
                foreach (var item in data)
                {
                    UsuarisHospitales.Add(JsonConvert.DeserializeObject<UsuariosHospitalesEL>(((JProperty)item).Value.ToString()));
                }
                return UsuarisHospitales;
            }
            catch (Exception)
            {
                return UsuarisHospitales;
            }
        }
        public int Modificar(UsuariosHospitalesEL en)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var response = client.Update("UsuariosHospitales/" + en.NombreUsuario, en);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int EliminarUsuariosHospitales(UsuariosHospitalesEL en)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var response = client.Delete("UsuariosHospitales/" + en.NombreUsuario);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        //  //Obtener por Id
        public UsuariosHospitalesEL GetUsuarioById(string id)
        {
            try
            {
                //pROPIO METODO
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var res = client.Get("UsuariosHospitales/" + id);
                UsuariosHospitalesEL _usuarioH = res.ResultAs<UsuariosHospitalesEL>();
                return _usuarioH;


                //IFirebaseClient client = new FireSharp.FirebaseClient(config);
                //FirebaseResponse response = client.Get("UsuariosHospitales/" + id);
                //UsuariosHospitalesEL data = JsonConvert.DeserializeObject<UsuariosHospitalesEL>(response.Body);
                //return (data);


            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}

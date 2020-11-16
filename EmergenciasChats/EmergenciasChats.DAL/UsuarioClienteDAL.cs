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
   public class UsuarioClienteDAL
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "CPT7izztGnLhDZ8RFM3lfSiJxLOxsAf6UnrERsOd",
            BasePath = "https://aplicacion-web-de-emergencias.firebaseio.com/"
        };
        

        //agrgar

        public int AgregarUsuariosClientes(UsuarioClienteEL usuariosclientes)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                //var response = client.Set("User/UserAdmin/" + en.Username, en);
                var response = client.Set("UsuariosClientes/" + usuariosclientes.Username, usuariosclientes);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }




        //listar
        public List<UsuarioClienteEL> ObtenerUsuariosClientes()
        {
            List<UsuarioClienteEL> usuariosclientes = new List<UsuarioClienteEL>();
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Get("UsuariosClientes");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
                foreach (var item in data)
                {
                    usuariosclientes.Add(JsonConvert.DeserializeObject<UsuarioClienteEL>(((JProperty)item).Value.ToString()));
                }
                return usuariosclientes;
            }
            catch (Exception)
            {
                return usuariosclientes; 
            }
        }
        public int ModificarUsuariosclientes(UsuarioClienteEL usuariosclientes)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var response = client.Update("UsuariosClientes/" + usuariosclientes.Username, usuariosclientes);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int EliminarUsuariosc(UsuarioClienteEL usuariosclientes)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var response = client.Delete("UsuariosClientes/" + usuariosclientes.Username);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //  //Obtener por Id
        public UsuarioClienteEL GetUsuarioById(string id)
        {
            try
            {
                //pROPIO METODO
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var res = client.Get("UsuariosClientes/" + id);
                UsuarioClienteEL _usuarioH = res.ResultAs<UsuarioClienteEL>();
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

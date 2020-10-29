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

     
        public int AgregarUsuariosClientes(UsuarioClienteEL usuariosclientes)
        {
            try
            {
                usuariosclientes.NombreUsuarios = (DateTime.Today.ToString("dd-MM-yyyy")).ToString() + (DateTime.Now.ToString("HH:mm:ss")).ToString();
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var response = client.Set("UsuariosClientes/" + usuariosclientes.NombreUsuarios, usuariosclientes);
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
        public int ModificarUsuariosc(UsuarioClienteEL usuariosclientes)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var response = client.Update("UsuariosClientes/" + usuariosclientes.NombreUsuarios, usuariosclientes);
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
                var response = client.Delete("UsuariosClientes/" + usuariosclientes.NombreUsuarios);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}

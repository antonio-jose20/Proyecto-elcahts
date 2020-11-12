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
    public class UserAdminDAL
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "CPT7izztGnLhDZ8RFM3lfSiJxLOxsAf6UnrERsOd",
            BasePath = "https://aplicacion-web-de-emergencias.firebaseio.com/"
        };


        public int AgregarUserAdmin(UserAdminEN en)
        {
            try
            {              
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                //var response = client.Set("User/UserAdmin/" + en.Username, en);
                var response = client.Set("User/" + en.Username, en);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Login(UserAdminEN pEn)
        {
            List<UserAdminEN> en = new List<UserAdminEN>();
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Get("User");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
                int inc = 0;
                foreach (var item in data)
                {
                    en.Add(JsonConvert.DeserializeObject<UserAdminEN>(((JProperty)item).Value.ToString()));

                    if (en[inc].Username == pEn.Username && pEn.Password == en[inc].Password)
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


        //listar
        public List<UserAdminEN> ObtenerUsuarios()
        {
            List<UserAdminEN> Usuariosad = new List<UserAdminEN>();
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Get("User");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
                foreach (var item in data)
                {
                    Usuariosad.Add(JsonConvert.DeserializeObject<UserAdminEN>(((JProperty)item).Value.ToString()));
                }
                return Usuariosad;
            }
            catch (Exception)
            {
                return Usuariosad;
            }
        }
        public int Modificar(UserAdminEN en)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var response = client.Update("UsuariosHospitales/" + en.Username, en);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }


    }
}

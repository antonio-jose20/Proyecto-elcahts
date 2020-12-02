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
    public class HospitalesDAL
    {
        //conexion a la db
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "CPT7izztGnLhDZ8RFM3lfSiJxLOxsAf6UnrERsOd",
            BasePath = "https://aplicacion-web-de-emergencias.firebaseio.com/"
        };

        //metodo listar
        //listar
        public List<Hospitales> ObtenerHospitales()
        {
            List<Hospitales> Hospitales = new List<Hospitales>();
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Get("hospitales");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
                foreach (var item in data)
                {
                    Hospitales.Add(JsonConvert.DeserializeObject<Hospitales>(((JProperty)item).Value.ToString()));
                }
                return Hospitales;
            }
            catch (Exception)
            {
                return Hospitales;
            }
        }

        //metodo eliminar

        public int EliminarHospitales(Hospitales en)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var response = client.Delete("hospitales/" + en.IDHospit);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

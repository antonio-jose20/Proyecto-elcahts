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
   public  class HospitalDAL
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "CPT7izztGnLhDZ8RFM3lfSiJxLOxsAf6UnrERsOd",
            BasePath = "https://aplicacion-web-de-emergencias.firebaseio.com/"
        };

        public List<HospitalEN> ObtenerTodosLosHospitales()
        {
            List<HospitalEN> en = new List<HospitalEN>();
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Get("Hospitales");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
                foreach (var item in data)
                {
                    en.Add(JsonConvert.DeserializeObject<HospitalEN>(((JProperty)item).Value.ToString()));
                }
                return en;
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int AgregarHospital(HospitalEN hospital)
        {
            try
            {
                hospital.IdHospital = (DateTime.Today.ToString("dd-MM-yyyy")).ToString() + (DateTime.Now.ToString("HH:mm:ss")).ToString();
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var response = client.Set("Hospital/" + hospital.IdHospital, hospital);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int ModificarHospital(HospitalEN hospital)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var response = client.Update("Hospital/" + hospital.IdHospital, hospital);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int EliminarHospital(HospitalEN hospital)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var response = client.Delete("Hospital/" + hospital.IdHospital);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}

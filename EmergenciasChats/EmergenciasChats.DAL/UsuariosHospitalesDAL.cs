﻿using System;
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
    // dbConexion dbconexion = new  dbConexion();
   public  class UsuariosHospitalesDAL
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "CPT7izztGnLhDZ8RFM3lfSiJxLOxsAf6UnrERsOd",
            BasePath = "https://aplicacion-web-de-emergencias.firebaseio.com/"
        };
         
        //agrgar
        public int AgregarUsuariosHospitales(UsuariosHospitalesEL en)
        {  
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var data = en;
                PushResponse response = client.Push("UsuariosHospitales/", data);
                data.UserdhID = response.Result.name;
                SetResponse setResponse = client.Set("UsuariosHospitales/" + data.UserdhID, data);
                return 1;
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
                var response = client.Update("UsuariosHospitales/" + en.UserdhID, en);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        // Funcion de Modificar
        public int Editar(UsuariosHospitalesEL en)
        {
           try
            {
                int r = 1;
                if ((en.NombreCompleto != null) && (en.Telefono != null) && (en.Email != null) && (en.Password != null) && (en.Apellidos != null)
                    && (en.Direccion != null) && (en.Dui != null) && (en.Username != null))
                {
                    IFirebaseClient client = new FireSharp.FirebaseClient(config);
                    FirebaseResponse response = client.Set("UsuariosHospitales/" + en.Username, en);
                    return r;
                }
                else
                {
                    return -1;
                }

            }
            catch(Exception e)
            {
                throw e;
            }
        }
        //EDIT

        public int EliminarUsuariosHospitales(UsuariosHospitalesEL en)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var response = client.Delete("UsuariosHospitales/" + en.UserdhID);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

















        //  //Obtener por Id
       // public UsuariosHospitalesEL GetUsuarioById(string id)
        public UsuariosHospitalesEL GetUsuarioById(string id)
        {
            try { 
            //{
            //    IFirebaseClient client = new FireSharp.FirebaseClient(config);
            //    var res = client.Get("UsuariosHospitales/" + id);
            //    UsuariosHospitalesEL _usuarioH = res.ResultAs<UsuariosHospitalesEL>();
            //    return _usuarioH;

                IFirebaseClient client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("UsuariosHospitales/" + id);
            UsuariosHospitalesEL data = JsonConvert.DeserializeObject<UsuariosHospitalesEL>(response.Body);
            return (data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///obteer cliente por id
        public UsuariosHospitalesEL ObtenerPoId(int id)
        {
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Get("UsuariosHospitales/" + id);
                //UsuariosHospitalesEL data = JsonConvert.DeserializeObject<UsuariosHospitalesEL>(response.Body);
                UsuariosHospitalesEL _usuarioH = response.ResultAs<UsuariosHospitalesEL>();
                return _usuarioH;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Funcion para dar like
        public int like(int id)
        {
            int r = 0;
            try
            {
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var res = client.Get("UsuariosHospitales/" + id);
                UsuariosHospitalesEL _usuarioH = res.ResultAs<UsuariosHospitalesEL>();
                // return _usuarioH;
                _usuarioH.like = (_usuarioH.like + 1);
                r = Modificar(_usuarioH);
            }
            catch (Exception ex)
            {
                throw ex;   
            }
            return r;      
        }

        //Funcion para enviar mensaje
        public int mensaje(int id)
        {
            int r = 0;
            try
            {   
                IFirebaseClient client = new FireSharp.FirebaseClient(config);
                var res = client.Get("UsuariosHospitales/" + id);
                // res = client.Set("UsuariosHospitales/", + id);
                UsuariosHospitalesEL _usuarioH = res.ResultAs<UsuariosHospitalesEL>();
                // return _usuarioH;
                _usuarioH.mensaje = (_usuarioH.mensaje + 1);
                r = Modificar(_usuarioH);  
            }      
            catch (Exception ex)
            {
                throw ex;
            }
           return r;
        }
        

    }
}

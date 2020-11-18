using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using proyect
using EmergenciasChats.DAL;
using EmergenciasChats.EL;

namespace EmergenciasChats.BL
{
    public class UsuarioClieteBL
    { 
        //instancia de la DAL
        private UsuarioClienteDAL usuarioclientesDAL = new UsuarioClienteDAL();

        public int AgregarUsuarioclientes(UsuarioClienteEL usuarioclientes)
        {
            return usuarioclientesDAL.AgregarUsuariosClientes(usuarioclientes);
        }

        public int EliminarUsuarioclientes(UsuarioClienteEL usuarioclientes)
        {
            return usuarioclientesDAL.EliminarUsuariosc(usuarioclientes);
        }
        //modificar
        public int ModificarUsuarioclientes(UsuarioClienteEL usuarioclientes)
        {
            return usuarioclientesDAL.ModificarUsuariosclientes(usuarioclientes);
        }
        public List<UsuarioClienteEL> ObtenerUsuariosHospitales()
        {
            return usuarioclientesDAL.ObtenerUsuariosClientes();
        }

        //Metodo Obtener por ID
        public UsuarioClienteEL GetUsuarioById(string id)
        {
            return usuarioclientesDAL.GetUsuarioById(id);
        }

        //Instancia del metodo de like
        public int like(int id)
        {
            return usuarioclientesDAL.like(id);
        }
        //Instancia el mensaje
        public int mensaje(int id)
        {
            return usuarioclientesDAL.mensaje(id);
        }
    }
}

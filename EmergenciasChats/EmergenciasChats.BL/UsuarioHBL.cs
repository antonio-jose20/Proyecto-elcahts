using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencia de proyectos DAL y EL
using EmergenciasChats.EL;
using EmergenciasChats.DAL;

namespace EmergenciasChats.BL
{
   public  class UsuarioHBL
    {
     
        //instancia de la clase DAL 
        private UsuarioHDAL usuarioHDAL = new UsuarioHDAL();
        //Metodo Eliminar
        public int AddUser(UsuarioH usuarioH)
        {
            return usuarioHDAL.AddUser(usuarioH);
        }
        //Metodo EDITAR
        public int UpdateUser(UsuarioH usuarioH)
        {
            return usuarioHDAL.UpdateUser(usuarioH);
        }
        //Metodo Detalle
        public int DetailsUser(string id)
        {
            return usuarioHDAL.DetailsUser(id);
        }
        //Metodo Obtener por ID
        public UsuarioH GetUsuarioById(string id)
        {
            return usuarioHDAL.GetUsuarioById(id);
        }

        //Metodo Eliminar
        public int DeleteUser(UsuarioH usuarioH)
        {
            return usuarioHDAL.DeleteUser(usuarioH);
        }
        //Metodo Listar
        public List<UsuarioH> ListaUsuario()
        {
            return usuarioHDAL.ListAUsuario();
        }
        //Login 
        public Boolean Login(UsuarioH usuarioH)
        {
            return usuarioHDAL.login(usuarioH);
        }
    }
}

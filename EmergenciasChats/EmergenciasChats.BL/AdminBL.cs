using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//refe
using EmergenciasChats.EL;
using EmergenciasChats.DAL;

namespace EmergenciasChats.BL
{
  public class AdminBL
    {
        //
        private AdminDAL adminDAL = new AdminDAL();
        //Guardar
        public int AddAdmin(AdminEL en)
        {
            return adminDAL.AddAdmin(en);
        }
        //editar
        public int ActualizarR( AdminEL en){
            return adminDAL.ModificarAdmin(en);
            }
        //eliminar
        public int EliminarAdmin (AdminEL admin)
        {
            return adminDAL.EliminarAdmin(admin);
        }       
        //obtener 
        public List<AdminEL> GetAdmiList()
        {
            return adminDAL.GetAdminList();
        }
        
        //obtener por Id
        public AdminEL GetUsuarioById(string id)
        {
            return adminDAL.GetUsuarioById(id);
        }
        //LOGIN
        public int Login(AdminEL pEn)
        {
            return adminDAL.Login(pEn);
        }


    }
}

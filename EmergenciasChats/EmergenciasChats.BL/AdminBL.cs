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

        public List<AdminEL> GetAdminList()
        {
            return adminDAL.GetAdminList();
        }

        public int AddAdmin(AdminEL en)
        {
            return adminDAL.AddAdmin(en);
        }
        //eliminar
        public int EliminarAdmin (AdminEL admin)
        {
            return adminDAL.EliminarAdmin(admin);
        }
 
        //LOGIN
        public int Login(AdminEL pEn)
        {
            return adminDAL.Login(pEn);
        }









         //obtener por Id
        public AdminEL GetUsuarioById(string id)
        {
            return adminDAL.GetUsuarioById(id);
        }

        //public int Delete(string id)
        //{
        //    return adminDAL.Delete(id);
        //}

        //public List<AdminEL> ListAdministra()
        //{
        //    return adminDAL.ListAdministra();
        //}

        //Login 
        //public int Login(AdminEL admin)
        //{
        //    return adminDAL.login(admin);
        //}


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergenciasChats.DAL;
using EmergenciasChats.EL;


namespace EmergenciasChats.BL
{
    public  class UserAdminBL
    {
        UserAdminDAL dal = new UserAdminDAL();
        public int AgregarUserAdmin(UserAdminEN en)
        {
            return dal.AgregarUserAdmin(en);
        }

        public int Login(UserAdminEN pEn)
        {
            return dal.Login(pEn);
        }
    }
}

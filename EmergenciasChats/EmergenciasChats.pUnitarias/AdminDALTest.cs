using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//
using EmergenciasChats.DAL;
using EmergenciasChats.EL;

namespace EmergenciasChats.pUnitarias
{
    [TestClass]
    public class AdminDALTest
    {
        //instancia de la DAL
         AdminDAL adminDAL = new AdminDAL();
        [TestMethod]
        public void TestValidarLogin()
        {
            //instancia de la EL
            AdminEL adminEL = new AdminEL();
            adminEL.Usuario = "antonio";
            adminEL.Password = "prosury2";

            int esperado = 1;
            int actual = adminDAL.Login(adminEL);
            Assert.AreEqual(esperado, actual);
             
        }

      
    }
}

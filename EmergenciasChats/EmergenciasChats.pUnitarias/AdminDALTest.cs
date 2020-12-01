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
        //guardar
        [TestMethod]
        public void TestAgregarCliente()
        {
            AdminEL adminEL = new AdminEL();

            int esperado = 1;
            int actual = adminDAL.AddAdmin(adminEL);

            Assert.AreEqual(esperado, actual);
        }


        //Modificar cliente 
        [TestMethod]
        public void TestModificarCliente()
        {
            AdminEL adminEL = new AdminEL();
           // adminEL = AdminDAL.GetUsuarioById(01 - 12 - 2020);
           // adminEL.IDAdmin = 01-12-2020;
           


            int esperado = 1;
            int actual = adminDAL.ModificarAdmin(adminEL);

            Assert.AreEqual(esperado, actual);
        }


    }
}

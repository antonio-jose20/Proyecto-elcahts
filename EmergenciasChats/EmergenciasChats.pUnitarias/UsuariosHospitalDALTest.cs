using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using
using EmergenciasChats.DAL;
using EmergenciasChats.EL;

namespace EmergenciasChats.pUnitarias
{
    
  
    [TestClass]
    public class UsuariosHospitalDALTest
    {
        //instancia DAL
        UsuariosHospitalesDAL usuarioHDAL = new UsuariosHospitalesDAL();
        //cliente
        UsuarioClienteDAL usuarioCDAL = new UsuarioClienteDAL();

        [TestMethod]
        public void TestAgregarUsuariodHospital()
        {
            UsuariosHospitalesEL usuariohEL = new UsuariosHospitalesEL();
            usuariohEL.NombreCompleto = "Juan";
            usuariohEL.Apellidos = "perez";
            usuariohEL.Email = "jperez2020@gmail.com";
            usuariohEL.Telefono = "7045-6554";
            usuariohEL.Direccion = "Avenida Sur Colonia Miramonte";
            usuariohEL.Dui = "09833653-3";
            usuariohEL.Password = "3214";

            int esperado = 1;
            int actual = usuarioHDAL.AgregarUsuarisHospitales(usuariohEL);

            //procedimiento de agregar 
            Assert.AreEqual(esperado, actual);
        }


        //Modificar cliente 
        [TestMethod]
        public void TestModificarUsuariodHospital()
        {
            UsuariosHospitalesEL usuariohEL = new UsuariosHospitalesEL();
             //usuariohEL = UsuariosHospitalesDAL.GetUsuarioById(01 - 11 - 202017:56:13);
             //usuariohEL.NombreUsuarios = 01 - 11 - 202017:56:13;
            //usuariohEL.NombreUsuarios = "3";
            usuariohEL.NombreCompleto = "Juan Armenta";
            usuariohEL.Apellidos = "Gomez Moran";
            usuariohEL.Email = "armentag20@gmail.com";
            usuariohEL.Telefono = "7873-8754";
            usuariohEL.Direccion = "Avenida Sur Colonia Buenos Aires";
            usuariohEL.Dui = "098336636-2";
            usuariohEL.Password = "54321";


            int esperado = 1;
            int actual = usuarioHDAL.Modificar(usuariohEL);

            Assert.AreEqual(esperado, actual);
        }
        //modificar cliente
        //Modificar cliente 
        //[TestMethod]
        //public void TestModificarUsuarioCliente()
        //{
        //    UsuarioClienteEL usuariohEL = new UsuarioClienteEL();
        //    usuariohEL = UsuarioClienteDAL.Modificar(01 - 11 - 202017:56:13);
        //    usuariohEL.NombreUsuarios = 01 - 11 - 202017:56:13;
        //    //usuariohEL.NombreUsuarios = "3";
        //    usuariohEL.NombreCompleto = "Juan Armenta";
        //    usuariohEL.Apellidos = "Gomez Moran";
        //    usuariohEL.Email = "armentag20@gmail.com";
        //    usuariohEL.Telefono = "7873-8754";
        //    usuariohEL.Direccion = "Avenida Sur Colonia Buenos Aires";
        //    usuariohEL.Dui = "098336636-2";
        //    usuariohEL.Password = "54321";


        //    int esperado = 1;
        //    int actual = usuarioHDAL.Modificar(usuariohEL);

        //    Assert.AreEqual(esperado, actual);
        //}




        //eliminar
        [TestMethod]
        public void TestEliminar()
        {
            UsuariosHospitalesEL usuariohEL = new UsuariosHospitalesEL();
            //usuariohEL.id = 31 - 10 - 202017:29:07;

            int esperado = 1;
            int actual = usuarioHDAL.EliminarUsuariosHospitales(usuariohEL);

            Assert.AreEqual(esperado, actual);
        }

        //obtener 
        [TestMethod]
        public void TestObtener()
        {

            int esperado = 2;
            int actual = usuarioHDAL.ObtenerUsuarisHospitales().Count;
            Assert.AreEqual(esperado, actual);
        }


        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestAgregarUsuariodHospitales()
        {
            //
            // TODO: Agregar aquí la lógica de las pruebas
            //
        }
    }
}

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
            usuariohEL.NombreCompleto = "Ramon";
            usuariohEL.NombreUsuario = "jVillalta";
            usuariohEL.Apellidos = "Villalta";
            usuariohEL.Email = "jperez2020@gmail.com";
            usuariohEL.Telefono = "6545-6554";
            usuariohEL.Direccion = "Avenida el Salmon";
            usuariohEL.Dui = "09833653-3";
            usuariohEL.Password = "6214";
            usuariohEL.Imagen = "Melon.jpg";
            usuariohEL.Estado = true;

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
            //return Content(Convert.ToString(usuarioshBL.GetUsuarioById(2)));
            //un de klas dos
            //usuariohEL = UsuariosHospitalesDAL.GetUsuarioById(nombreusuario);
            //usuariohEL =  Convert.ToString(UsuariosHospitalesDAL.GetUsuarioById(id));
            //usuariohEL.NombreUsuario = 2;
            usuariohEL.NombreCompleto = "Juan Armenta";
           // usuariohEL.NombreUsuario = "jVillalta";
            usuariohEL.Apellidos = "Villalta";
            usuariohEL.Email = "jperez2020@gmail.com";
            usuariohEL.Telefono = "6545-6554";
            usuariohEL.Direccion = "Avenida el Salmon";
            usuariohEL.Dui = "09833653-3";
            usuariohEL.Password = "6214";
            usuariohEL.Imagen = "Sandia.jpg";
            usuariohEL.Estado = true;


            int esperado = 1;
            int actual = usuarioHDAL.Modificar(usuariohEL);

            Assert.AreEqual(esperado, actual);
        }
        ////modificar cliente
        //public void TestModificarCliente()
        //{
        //    ClienteBE cliente = new ClienteBE();
        //    cliente = ClienteDAL.ObtenerClientePorId(3);
        //    cliente.Id = 3;
        //    cliente.Nombre = "Hernan";
        //    cliente.Apellido = "Sibirian";
        //    cliente.Telefono = "6094-6454";
        //    cliente.Email = "MoranSS@gmail.com";
        //    cliente.Nick = "SHernan";
        //    cliente.Pass = "123";


        //    int esperado = 1;
        //    int actual = clienteDAl.ModificarCliente(cliente);

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

            int esperado = 3;
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

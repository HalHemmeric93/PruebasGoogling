using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartidaTenisJMC_Services.Control;
using PartidaTenisJMC_Services.Clases;
using SimpleInjector;

namespace PartidaTenisJMC_Test
{
    [TestClass]
    public class PartidaTenisJMCControl_Test
    {
        
        static public Container container;
        public PartidaTenisJMCControl_Test()
        {
            container = new Container();
            container.Register<IPartidaTenisJMCControl, PartidaTenisJMCControl>();
            container.Verify();
        }

        [TestMethod]
        public void ProbarCreacionUsuario1()
        {
            var control = container.GetInstance<IPartidaTenisJMCControl>();
            control.crearUsuario1("Paco");
        }
        [TestMethod]
        public void ProbarCreacionPartida()
        {
            var control = container.GetInstance<IPartidaTenisJMCControl>();
            control.crearUsuario1("Paco");
            control.crearUsuario2("pepe");
            control.crearPartida(3);
        }
        [TestMethod]
        public void ProbarSeleccionarJugadorPrincipal()
        {
            var control = container.GetInstance<IPartidaTenisJMCControl>();
            control.crearUsuario1("Paco");
            control.crearUsuario2("pepe");
            control.crearPartida(3);
            control.seleccionarJugadorPrincipal();
        }

        [TestMethod]
        public void ProbarnombreJugadorPrincipal()
        {
            var control = container.GetInstance<IPartidaTenisJMCControl>();
            control.crearUsuario1("Paco");
            control.crearUsuario2("pepe");
            control.crearPartida(3);
            var nombre = control.nombreJugadorPrincipal();
            Assert.AreEqual("Paco", nombre);
        }

    }
}

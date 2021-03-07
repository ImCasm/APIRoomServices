using APIRest.Controllers;
using Dominio.EntidadesDelDominio.Abstractas;
using Dominio.EntidadesDelDominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio.ControlRepository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace APIRest.Tests.Controllers
{
    [TestClass]
    public class BuscarAlojamientoTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ControlTomarAlquilerAlojamiento controlAlquiler = new ControlTomarAlquilerAlojamiento();
            int IdAl = 3;
            Alquiler resultado = controlAlquiler.listaAlquiler(IdAl);
            Assert.AreEqual(1234, resultado.NumeroContrato);

        }
        [TestMethod]
        public void TestBuscarAlojamientoFechasEncontrar()
        {
            BuscarAlojamientoController buscarAlojamientoController = new BuscarAlojamientoController();
            DateTime fecha1 = new DateTime(2008,02,01);
            DateTime fecha2 = new DateTime(2020, 12, 30);
            JObject resultado= buscarAlojamientoController.ConsultarInformacionAlojamiento(fecha1,fecha2);
            Console.WriteLine(resultado["error"]);
           // dynamic results = JsonConvert.DeserializeObject<dynamic>(resultado);
            Assert.IsTrue(resultado["error"]!=null);
        }
        [TestMethod]
        public void TestBuscarAlojamientoFechasnoEncontrada()
        {
            BuscarAlojamientoController buscarAlojamientoController = new BuscarAlojamientoController();
            DateTime fecha1 = new DateTime(1900, 02, 01);
            DateTime fecha2 = new DateTime(1900, 12, 30);
            JObject resultado = buscarAlojamientoController.ConsultarInformacionAlojamiento(fecha1, fecha2);
            Console.WriteLine(resultado["error"]);
            // dynamic results = JsonConvert.DeserializeObject<dynamic>(resultado);
            Assert.IsTrue(resultado["error"].Equals("404 no se encontraron resultados"));
        }



    }
}

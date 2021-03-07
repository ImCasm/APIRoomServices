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
        //[TestMethod]
        //public void VerificarEncapsulamientoAlquiTest()
        //{
        //    ControlTomarAlquilerAlojamiento controlAlquiler = new ControlTomarAlquilerAlojamiento();
        //    int IdAl = 3;
        //    Alquiler resultado = controlAlquiler.listaAlquiler(IdAl);
        //    Assert.AreEqual(1234, resultado.NumeroContrato);
        //}


        /// <summary>
        /// Verifica quela en una rango de fecha exista una cantidad EXACTA de alojamientos
        /// </summary>
        [TestMethod]
        public void TestBuscarAlojamientosEspecificas()
        {
            BuscarAlojamientoController buscarAlojamientoController = new BuscarAlojamientoController();
            DateTime fecha1 = new DateTime(2008,02,01);
            DateTime fecha2 = new DateTime(2021, 12, 30);
            JObject resultado= buscarAlojamientoController.ConsultarInformacionAlojamiento(fecha1,fecha2);
            Assert.IsTrue(resultado["cantidad"].ToString() == "1");
        }

        /// <summary>
        /// Verifica que en un rango de fecha NO existan alojamientos
        /// </summary>
        [TestMethod]
        public void TestBuscarAlojamientoFechasNoEncontrada()
        {
            BuscarAlojamientoController buscarAlojamientoController = new BuscarAlojamientoController();
            DateTime fecha1 = new DateTime(1900, 02, 01);
            DateTime fecha2 = new DateTime(1900, 12, 30);
            JObject resultado = buscarAlojamientoController.ConsultarInformacionAlojamiento(fecha1, fecha2);
            Assert.IsTrue(resultado["cantidad"].ToString() == "0");
        }

        /// <summary>
        /// Verifica que en un rango de fecha exista por lo menos UN alojamiento
        /// </summary>
        [TestMethod]
        public void TestBuscarAlojamientoFechas()
        {
            BuscarAlojamientoController buscarAlojamientoController = new BuscarAlojamientoController();
            DateTime fecha1 = new DateTime(2005, 02, 01);
            DateTime fecha2 = new DateTime(2021, 12, 30);
            JObject resultado = buscarAlojamientoController.ConsultarInformacionAlojamiento(fecha1, fecha2);
            Assert.IsTrue(int.Parse(resultado["cantidad"].ToString()) > 0);
        }

    }
}

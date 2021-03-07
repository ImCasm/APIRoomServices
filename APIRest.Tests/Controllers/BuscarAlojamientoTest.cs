using Dominio.EntidadesDelDominio.Abstractas;
using Dominio.EntidadesDelDominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio.ControlRepository;

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
        


    }
}

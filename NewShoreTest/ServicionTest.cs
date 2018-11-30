using System;
using System.Collections.Generic;
using System.Linq;
using Entidades.entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios.Interfaces;
using    Servicios.Implementacion;
namespace NewhoreTest
{
    [TestClass]
    public class ServicioTest
    {
        public ServicioClientes servicioCliente = new ServicioClientes();

        [TestMethod]
        public void TestMetodoValidarListaClientes()
        {
            var valorTestRegistro = new List<Registro>();
            valorTestRegistro.Add(new Registro() { Existe = false, NombreCliente = "hola" });
            valorTestRegistro.Add(new Registro() { Existe = false, NombreCliente = "qase" });
            valorTestRegistro.Add(new Registro() { Existe = false, NombreCliente = "hi" });
            var valorTestContenido = new List<Contenido>();
            valorTestContenido.Add(new Contenido() { Caracter = 'h' });
            valorTestContenido.Add(new Contenido() { Caracter = 'q' });
            valorTestContenido.Add(new Contenido() { Caracter = 'o' });
            valorTestContenido.Add(new Contenido() { Caracter = 's' });
            valorTestContenido.Add(new Contenido() { Caracter = 'a' });
            valorTestContenido.Add(new Contenido() { Caracter = 'e' });
            valorTestContenido.Add(new Contenido() { Caracter = 'l' });
            valorTestContenido.Add(new Contenido() { Caracter = 'h' });
            valorTestContenido.Add(new Contenido() { Caracter = 'i' });
            var valorExperado = new List<Registro>();
            valorExperado.Add(new Registro() { Existe = true, NombreCliente = "hola" });
            valorExperado.Add(new Registro() { Existe = false, NombreCliente = "qase" });
            valorExperado.Add(new Registro() { Existe = true, NombreCliente = "hi" });
            var valorResultado = servicioCliente.ValidarListaClientes(valorTestRegistro, valorTestContenido);

            Assert.AreEqual(valorExperado[0].Existe, valorResultado.ToList()[0].Existe);
            Assert.AreEqual(valorExperado[1].Existe, valorResultado.ToList()[1].Existe);
            Assert.AreEqual(valorExperado[2].Existe, valorResultado.ToList()[2].Existe);

        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;

namespace TestBiblioteca
{
    [TestClass]
    public class TestEntidades
    {
        [TestMethod]
        public void IgualdadSocios_DeberaRetornarTrueSiLosSociosTienenMismoNombreApellidoYDni()
        {
            // Arrange
            Socio s1 = new Socio("Juan", "Carlos", 33444555, Socio.EGenero.NoBinario, new System.DateTime(1999, 10, 1), "juanca@yahoo.com", true);
            Socio s2 = new Socio("Juan", "Carlos", 33444555, Socio.EGenero.Masculino, new System.DateTime(1995, 5, 5), "jcarlos@gmail.com", false);
            bool expected = true;

            // Act
            bool actual = s1 == s2;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EqualsSocio_DeberaRetornarTrueSiTienenMismoNombreApellidoYDni()
        {
            // Arrange
            Socio s1 = new Socio("Juan", "Carlos", 33444555, Socio.EGenero.NoBinario, new System.DateTime(1999, 10, 1), "juanca@yahoo.com", true);
            Socio s2 = new Socio("Juan", "Carlos", 33444555, Socio.EGenero.Masculino, new System.DateTime(1995, 5, 5), "jcarlos@gmail.com", false);
            bool expected = true;

            // Act
            bool actual = s1.Equals(s2);

            // Assert
            Assert.AreEqual(expected, actual);

        }


        [TestMethod]
        public void AgregarSocio_NoDeberaAgregarALaListaSiYaEstaEnLista()
        {
            // Arrange
            Socio s1 = new Socio("Juan", "Carlos", 33444555, Socio.EGenero.NoBinario, new System.DateTime(1999, 10, 1), "juanca@yahoo.com", true);
            Socio s2 = new Socio("Juan", "Carlos", 33444555, Socio.EGenero.Masculino, new System.DateTime(1995, 5, 5), "jcarlos@gmail.com", false);
            int expectedCount = 1;

            // Act
            Biblioteca.AgregarSocio(s1);
            Biblioteca.AgregarSocio(s2);
            int actual = Biblioteca.Socios.Count;

            // Assert
            Assert.AreEqual(expectedCount, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(TicketException))]
        public void ImprimirTicket_DeberaLanzarTicketExceptionSiNoPuedeGuardarArchivo()
        {
            // Arrange
            Prestamo p = new Prestamo();

            // Act
            p.ImprimirTicket("archivo");

            // Assert            
        }

    }
}

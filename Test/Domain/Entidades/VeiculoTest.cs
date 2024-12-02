using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Dominio.Entidades;

namespace Test.Domain.Entidades
{
    [TestClass]
    public class VeiculoTest
    {
        [TestMethod]
        public void TestarGetSetPropriedades()
        {
            // Arrange
            var veiculo = new Veiculo();

            // Act
            veiculo.Id = 1;
            veiculo.Ano = 2000;
            veiculo.Nome = "nomeTeste";
            veiculo.Marca = "marcaTeste";

            // Assert
            Assert.AreEqual(1, veiculo.Id);
            Assert.AreEqual(2000, veiculo.Ano);
            Assert.AreEqual("nomeTeste", veiculo.Nome);
            Assert.AreEqual("marcaTeste", veiculo.Marca);
            
        }
    }
}
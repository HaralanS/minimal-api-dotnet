using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.Db;

namespace Test.Domain.Servicos
{
    [TestClass]
    public class VeiculoServicosTest
    {
        private DbContexto CriarContextoDeTeste()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

            var builder = new ConfigurationBuilder()
                .SetBasePath(path ?? Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DbContexto(configuration);
        }

        [TestMethod]
        public void TestandoSalvarVeiculo()
        {
            // Arrange
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

            var veiculo = new Veiculo();
            // veiculo.Id = 1;
            veiculo.Ano = 2000;
            veiculo.Nome = "nomeTeste";
            veiculo.Marca = "marcaTeste";
            var veiculoServico = new VeiculoServico(context);

            // Act
            veiculoServico.Incluir(veiculo);

            // Assert
            Assert.AreEqual(1, veiculoServico.Todos(1).Count());
        }

                [TestMethod]
        public void TestandoSalvarVeiculoEBuscarPorId()
        {
            // Arrange
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");


            var veiculo = new Veiculo();
            // veiculo.Id = 1;
            veiculo.Ano = 2000;
            veiculo.Nome = "nomeTeste";
            veiculo.Marca = "marcaTeste";
            var veiculoServico = new VeiculoServico(context);

            // Act
            veiculoServico.Incluir(veiculo);
            var veiculoRetorno = veiculoServico.BuscaPorId(veiculo.Id);

            // Assert
            Assert.AreEqual(1, veiculoRetorno.Id);
        }

    }
}
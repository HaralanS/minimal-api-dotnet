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
    public class AdministradorServicosTest
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

            // var connectionString = configuration.GetConnectionString("MySql");
            // var options = new DbContextOptionsBuilder<DbContexto>().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)).Options;

            return new DbContexto(configuration);
        }


        [TestMethod]
        public void TestandoSalvarAdministrador()
        {
            // Arrange
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

            var adm = new Administrador();
            adm.Email = "teste@teste.com";
            adm.Senha = "teste";
            adm.Perfil = "Adm";
            var admServico = new AdministradorServico(context);

            // Act
            admServico.Incluir(adm);

            // Assert
            Assert.AreEqual(1, admServico.Todos(1).Count());
        }
        
        [TestMethod]
        public void TestandoSalvarAdministradorEBuscarPorId()
        {
            // Arrange
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

            var adm = new Administrador();
            adm.Email = "teste@teste.com";
            adm.Senha = "teste";
            adm.Perfil = "Adm";
            var admServico = new AdministradorServico(context);

            // Act
            admServico.Incluir(adm);
            var admRetorno = admServico.BuscarPorId(adm.Id);

            // Assert
            Assert.AreEqual(1, admRetorno.Id);
        }
    }
}
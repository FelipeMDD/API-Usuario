using API.Features.Administradores;
using API.Infrastructure;
using API.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace ApiUnitTest.UnitTests.Administrador
{
    public class AdministradorUnitTest
    {
        [Test]
        public void ListarUsuarios_RetornaOk()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "ListarUsuarios_RetornaOk")
                .Options;

            using (var context = new Context(options))
            {
                var acesso = new Acesso
                {
                    Id = 1,
                    Nome = "Teste",
                    Login = "Teste",
                    Password = "123456",
                    Email = "teste@gmail.com",
                    Role = "administrador"
                };

                context.Acesso.Add(acesso);
                context.SaveChanges();

                var query = new ListarUsuarios.Query { };
                var handler = new ListarUsuarios.QueryHandler(context);

                var result = handler.Handle(query);

                Assert.AreEqual(result.Count, 1);
            }
        }

        [Test]
        public void ListarUsuarios_RetornaErr()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "ListarUsuarios_RetornaErr")
                .Options;

            using (var context = new Context(options))
            {
                var acesso = new Acesso
                {
                    Id = 1,
                    Nome = "Teste",
                    Login = "Teste",
                    Password = "123456",
                    Email = "teste@gmail.com",
                    Role = "administrador"
                };

                var query = new ListarUsuarios.Query { };
                var handler = new ListarUsuarios.QueryHandler(context);

                var result = handler.Handle(query);

                Assert.AreEqual(result.Count, 0);
            }
        }

        [Test]
        public void AdicionarUsuario_RetornaOk()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "AdicionarUsuario_RetornaOk")
                .Options;

            using (var context = new Context(options))
            {
                var acesso = new Acesso
                {
                    Id = 1,
                    Nome = "Teste",
                    Login = "Teste",
                    Password = "123456",
                    Email = "teste@gmail.com",
                    Role = "administrador"
                };

                context.Acesso.Add(acesso);
                context.SaveChanges();

                var query = new AdicionarUsuario.Command {
                    nome = "Teste",
                    login = "Teste",
                    password = "123456",
                    email = "teste@gmail.com",
                    role = "administrador"
                };
                var handler = new AdicionarUsuario.CommandHandler(context);

                var result = handler.Handle(query);

                Assert.IsTrue(result.IsOk);
            }
        }
    }
}

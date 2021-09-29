using API.Features.Shared;
using API.Infrastructure;
using API.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace ApiUnitTest.UnitTests.Shared
{
    public class SharedUnitTest
    {
        [Test]
        public void VerificarCadastro_RetornaOk()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "VerificarCadastro_RetornaOk")
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

                var query = new VerificarCadastro.Query { id = 1  };
                var handler = new VerificarCadastro.QueryHandler(context);

                var result = handler.Handle(query);

                Assert.IsTrue(result.IsSome);
            }
        }

        [Test]
        public void AlterarSenha_RetornaOk()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "AlterarSenha_RetornaOk")
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

                var query = new AlterarSenha.Command { id = 1, password = "1234567" };
                var handler = new AlterarSenha.CommandHandler (context);

                var result = handler.Handle(query);

                Assert.IsTrue(result.IsOk);
                Assert.AreEqual("1234567", context.Acesso.Find(1).Password);
            }
        }

        [Test]
        public void AlterarSenha_RetornaErr()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "AlterarSenha_RetornaErr")
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

                var query = new AlterarSenha.Command { id = 2, password = "123456" };
                var handler = new AlterarSenha.CommandHandler(context);

                var result = handler.Handle(query);

                Assert.IsTrue(result.IsErr);
            }
        }
    }
}

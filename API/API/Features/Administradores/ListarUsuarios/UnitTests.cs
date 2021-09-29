using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using API.Infrastructure;
using API.Models;

namespace API.Features.Administradores
{
    public partial class ListarUsuarios
    {
        [TestFixture]
        public class UnitTests
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

                    var query = new Query { };
                    var handler = new QueryHandler(context);

                    var result = handler.Handle(query);

                    Assert.IsNotEmpty(result);
                }
            }
        }
    }
}

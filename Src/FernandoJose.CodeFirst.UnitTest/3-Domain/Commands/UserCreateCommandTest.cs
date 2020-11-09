using Bogus;
using FernandoJose.CodeFirst.Domain.Commands;
using System;
using System.Linq;
using Xunit;

namespace FernandoJose.CodeFirst.UnitTest._3_Domain.Commands
{
    public class UserCreateCommandTest
    {
        private readonly Faker _faker;

        public UserCreateCommandTest()
        {
            _faker = new Faker();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void Should_Show_Error_When_IdProfile_Invalid(int idProfile)
        {
            ClienteAdicionarCommand userCreateCommand = new ClienteAdicionarCommand(idProfile, Guid.NewGuid().ToString(), _faker.Person.FullName, _faker.Person.Email);

            userCreateCommand.Validar();

            Assert.True(!userCreateCommand.Valido());
            Assert.True(userCreateCommand.Erros?.FirstOrDefault(x => x == "Profile is required") != null);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_Show_Error_When_Name_Null_Or_Empty(string name)
        {
            ClienteAdicionarCommand userCreateCommand = new ClienteAdicionarCommand(1, Guid.NewGuid().ToString(), name, _faker.Person.Email);

            userCreateCommand.Validar();

            Assert.True(!userCreateCommand.Valido());
            Assert.True(userCreateCommand.Erros?.FirstOrDefault(x => x == "Name is required") != null);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_Show_Error_When_Email_Null_Or_Empty(string email)
        {
            ClienteAdicionarCommand userCreateCommand = new ClienteAdicionarCommand(1, Guid.NewGuid().ToString(), _faker.Person.FullName, email);

            userCreateCommand.Validar();

            Assert.True(!userCreateCommand.Valido());
            Assert.True(userCreateCommand.Erros?.FirstOrDefault(x => x == "E-mail is required") != null);
        }
    }
}

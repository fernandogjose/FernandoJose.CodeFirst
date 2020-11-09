using Bogus;
using FernandoJose.CodeFirst.Domain.Commands;
using FernandoJose.CodeFirst.Domain.Handlers;
using FernandoJose.CodeFirst.Domain.Interfaces.SqlServerRepositories;
using FernandoJose.CodeFirst.Domain.Interfaces.Validations;
using FernandoJose.CodeFirst.Domain.Share.Commands;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FernandoJose.CodeFirst.UnitTest._3_Domain.Handlers
{
    public class UserCreateCommandHandlerTest
    {
        private readonly Faker _faker;
        private readonly ClienteAdicionarCommandHandler _userCreateCommandHandler;
        private readonly Mock<IClienteSqlServerRepository> _userSqlServerRepositoryMock;
        private readonly Mock<IClienteValidation> _userValidationMock;

        public UserCreateCommandHandlerTest()
        {
            // Faker
            _faker = new Faker();

            // Mock
            _userValidationMock = new Mock<IClienteValidation>();
            _userSqlServerRepositoryMock = new Mock<IClienteSqlServerRepository>();

            // CommandHandler
            _userCreateCommandHandler = new ClienteAdicionarCommandHandler(_userSqlServerRepositoryMock.Object, _userValidationMock.Object);
        }

        [Fact]
        public async Task Should_Create_User_When_All_Parameters_Success()
        {
            ClienteAdicionarCommand userCreateCommand = new ClienteAdicionarCommand(1, Guid.NewGuid().ToString(), _faker.Person.FullName, _faker.Person.Email);
            _userValidationMock.Setup(r => r.IsDuplicateName(It.IsAny<string>(), It.IsAny<string>())).Returns(Tuple.Create(false, "Name already exist"));
            _userSqlServerRepositoryMock.Setup(r => r.Create(It.IsAny<ClienteAdicionarCommand>())).Returns(_faker.Random.Number(1, 100));

            ResponseCommand response = await _userCreateCommandHandler.Handle(userCreateCommand, CancellationToken.None).ConfigureAwait(true);

            Assert.True(response.Sucesso);
            Assert.True((int)response.Objeto > 0);
        }

        [Fact]
        public async Task Should_Show_Error_When_Some_Parameters_Is_Invalid()
        {
            ClienteAdicionarCommand userCreateCommand = new ClienteAdicionarCommand(1, Guid.NewGuid().ToString(), _faker.Person.FullName, _faker.Person.Email);
            userCreateCommand.AdicionarErro("Meu erro para testar o UnitTest");

            ResponseCommand response = await _userCreateCommandHandler.Handle(userCreateCommand, CancellationToken.None).ConfigureAwait(true);

            Assert.True(!response.Sucesso);
            Assert.True(((List<string>)response.Objeto).Count > 0);
            Assert.True(((List<string>)response.Objeto).Find(x => x == "Meu erro para testar o UnitTest") != null);
        }

        [Fact]
        public async Task Should_Show_Error_When_Duplicate_Name()
        {
            ClienteAdicionarCommand userCreateCommand = new ClienteAdicionarCommand(1, Guid.NewGuid().ToString(), _faker.Person.FullName, _faker.Person.Email);
            _userValidationMock.Setup(r => r.IsDuplicateName(It.IsAny<string>(), It.IsAny<string>())).Returns(Tuple.Create(true, "Name already exist"));

            ResponseCommand response = await _userCreateCommandHandler.Handle(userCreateCommand, CancellationToken.None).ConfigureAwait(true);

            Assert.True(!response.Sucesso);
            Assert.True(((List<string>)response.Objeto).Count > 0);
            Assert.True(((List<string>)response.Objeto).Find(x => x == "Name already exist") != null);
        }
    }
}

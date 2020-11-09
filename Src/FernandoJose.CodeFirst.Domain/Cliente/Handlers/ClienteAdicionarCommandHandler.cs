using FernandoJose.CodeFirst.Domain.Cliente.Commands;
using FernandoJose.CodeFirst.Domain.Cliente.Interfaces.SqlServerRepositories;
using FernandoJose.CodeFirst.Domain.Share.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FernandoJose.CodeFirst.Domain.Cliente.Handlers
{
    public class ClienteAdicionarCommandHandler : IRequestHandler<ClienteAdicionarCommand, ResponseCommand>
    {
        private readonly IClienteSqlServerRepository _clienteSqlServerRepository;

        public ClienteAdicionarCommandHandler(IClienteSqlServerRepository clienteSqlServerRepository)
        {
            _clienteSqlServerRepository = clienteSqlServerRepository;
        }

        public Task<ResponseCommand> Handle(ClienteAdicionarCommand request, CancellationToken cancellationToken)
        {
            // Validações de dados
            if (!request.Valido())
            {
                return Task.FromResult(new ResponseCommand(false, request.Erros));
            }

            // Persistir
            Models.Cliente clienteRequest = new Models.Cliente
            {
                Id = request.Id,
                Nome = request.Nome,
                Idade = request.Idade
            };
            _clienteSqlServerRepository.Adicionar(clienteRequest);

            // Response
            return Task.FromResult(new ResponseCommand(true, clienteRequest));
        }
    }
}
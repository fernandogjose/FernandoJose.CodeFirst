using FernandoJose.CodeFirst.Domain.Cliente.Commands;
using FernandoJose.CodeFirst.Domain.Cliente.Interfaces.SqlServerRepositories;
using FernandoJose.CodeFirst.Domain.Share.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FernandoJose.CodeFirst.Domain.Cliente.Handlers
{
    public class ClienteAtualizarCommandHandler : IRequestHandler<ClienteAtualizarCommand, ResponseCommand>
    {
        private readonly IClienteSqlServerRepository _clienteSqlServerRepository;

        public ClienteAtualizarCommandHandler(IClienteSqlServerRepository clienteSqlServerRepository)
        {
            _clienteSqlServerRepository = clienteSqlServerRepository;
        }

        public Task<ResponseCommand> Handle(ClienteAtualizarCommand request, CancellationToken cancellationToken)
        {
            // Validações de dados
            if (!request.Valido())
            {
                return Task.FromResult(new ResponseCommand(false, request.Erros));
            }

            // Verifica se existe
            Models.Cliente clienteRequest = _clienteSqlServerRepository.Obter(new Models.Cliente { Id = request.Id });
            if (clienteRequest == null)
            {
                return Task.FromResult(new ResponseCommand(false, "Cliente não encontrado"));
            }

            // Persistir
            clienteRequest.Nome = request.Nome;
            clienteRequest.Idade = request.Idade;
            _clienteSqlServerRepository.Atualizar(clienteRequest);

            // Response
            return Task.FromResult(new ResponseCommand(true, clienteRequest));
        }
    }
}
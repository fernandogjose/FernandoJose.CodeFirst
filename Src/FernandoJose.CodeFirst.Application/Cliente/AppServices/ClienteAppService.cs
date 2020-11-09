using FernandoJose.CodeFirst.Application.Cliente.Interfaces;
using FernandoJose.CodeFirst.Application.Cliente.ViewModels;
using FernandoJose.CodeFirst.Application.Share.ViewModels;
using FernandoJose.CodeFirst.Domain.Cliente.Commands;
using FernandoJose.CodeFirst.Domain.Cliente.Interfaces.SqlServerRepositories;
using FernandoJose.CodeFirst.Domain.Share.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FernandoJose.CodeFirst.Application.Cliente.AppServices
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IMediator _mediator;
        private readonly IClienteSqlServerRepository _clienteSqlServerRepository;

        public ClienteAppService(IMediator mediator, IClienteSqlServerRepository clienteSqlServerRepository)
        {
            _mediator = mediator;
            _clienteSqlServerRepository = clienteSqlServerRepository;
        }

        public async Task<ResponseViewModel> AdicionarAsync(ClienteAdicionarRequestViewModel request)
        {
            ClienteAdicionarCommand clienteAdicionarCommand = new ClienteAdicionarCommand(request.Nome, request.Idade);
            ResponseCommand clienteAdicionarResponse = await _mediator.Send(clienteAdicionarCommand, CancellationToken.None).ConfigureAwait(true);
            return new ResponseViewModel(clienteAdicionarResponse.Sucesso, clienteAdicionarResponse.Objeto);
        }

        public async Task<ResponseViewModel> AtualizarAsync(ClienteAtualizarRequestViewModel request)
        {
            ClienteAtualizarCommand clienteAtualizarCommand = new ClienteAtualizarCommand(request.Id, request.Nome, request.Idade);
            ResponseCommand clienteAtualizarResponse = await _mediator.Send(clienteAtualizarCommand, CancellationToken.None).ConfigureAwait(true);
            return new ResponseViewModel(clienteAtualizarResponse.Sucesso, clienteAtualizarResponse.Objeto);
        }

        public async Task<ResponseViewModel> DeletarAsync(Guid id)
        {
            ClienteDeletarCommand clienteDeletarCommand = new ClienteDeletarCommand(id);
            ResponseCommand clienteDeletarResponse = await _mediator.Send(clienteDeletarCommand, CancellationToken.None).ConfigureAwait(true);
            return new ResponseViewModel(clienteDeletarResponse.Sucesso, clienteDeletarResponse.Objeto);
        }

        public ResponseViewModel Obter(Guid id)
        {
            Domain.Models.Cliente clienteObterResponse = _clienteSqlServerRepository.Obter(new Domain.Models.Cliente { Id = id });
            return new ResponseViewModel(true, clienteObterResponse);
        }

        public ResponseViewModel Listar()
        {
            List<Domain.Models.Cliente> clienteListarResponse = _clienteSqlServerRepository.Listar(_ => true);
            return new ResponseViewModel(true, clienteListarResponse);
        }

        public ResponseViewModel ListarPorNome(string nome)
        {
            List<Domain.Models.Cliente> clienteListarResponse = _clienteSqlServerRepository.Listar(x => x.Nome == nome);
            return new ResponseViewModel(true, clienteListarResponse);
        }
    }
}

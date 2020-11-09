using FernandoJose.CodeFirst.Application.Cliente.ViewModels;
using FernandoJose.CodeFirst.Application.Share.ViewModels;
using System;
using System.Threading.Tasks;

namespace FernandoJose.CodeFirst.Application.Cliente.Interfaces
{
    public interface IClienteAppService
    {
        Task<ResponseViewModel> AdicionarAsync(ClienteAdicionarRequestViewModel request);

        Task<ResponseViewModel> AtualizarAsync(ClienteAtualizarRequestViewModel request);

        Task<ResponseViewModel> DeletarAsync(Guid id);

        ResponseViewModel Obter(Guid id);

        ResponseViewModel Listar();

        ResponseViewModel ListarPorNome(string nome);
    }
}

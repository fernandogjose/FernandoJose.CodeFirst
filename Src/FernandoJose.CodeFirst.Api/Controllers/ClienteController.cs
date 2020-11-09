using FernandoJose.CodeFirst.Application.Cliente.Interfaces;
using FernandoJose.CodeFirst.Application.Cliente.ViewModels;
using FernandoJose.CodeFirst.Application.Share.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FernandoJose.CodeFirst.Api.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ClienteAdicionarRequestViewModel request)
        {
            ResponseViewModel response = await _clienteAppService.AdicionarAsync(request).ConfigureAwait(true);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Put([FromBody] ClienteAtualizarRequestViewModel request)
        {
            ResponseViewModel response = await _clienteAppService.AtualizarAsync(request).ConfigureAwait(true);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            ResponseViewModel response = await _clienteAppService.DeletarAsync(id).ConfigureAwait(true);
            return Ok(response);
        }

        [HttpGet("obter-por-id/{id}")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Obter(Guid id)
        {
            ResponseViewModel response = _clienteAppService.Obter(id);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Listar()
        {
            ResponseViewModel response = _clienteAppService.Listar();
            return Ok(response);
        }

        [HttpGet("listar-por-nome/{nome}")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.InternalServerError)]
        public IActionResult ListarPorNome(string nome)
        {
            ResponseViewModel response = _clienteAppService.ListarPorNome(nome);
            return Ok(response);
        }
    }
}
using FernandoJose.CodeFirst.Domain.Share.Commands;
using MediatR;
using System;
using System.Collections.Generic;

namespace FernandoJose.CodeFirst.Domain.Cliente.Commands
{
    public class ClienteDeletarCommand : RequestCommand, IRequest<ResponseCommand>
    {
        public Guid Id { get; }

        public ClienteDeletarCommand(Guid id)
        {
            Id = id;
        }

        public override void Validar()
        {
            Erros = new List<string>(0);

            if (Id == default)
            {
                Erros.Add("Id é obrigatório");
            }
        }
    }
}

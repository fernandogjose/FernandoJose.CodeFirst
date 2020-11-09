using FernandoJose.CodeFirst.Domain.Share.Commands;
using MediatR;
using System;
using System.Collections.Generic;

namespace FernandoJose.CodeFirst.Domain.Cliente.Commands
{
    public class ClienteAtualizarCommand : RequestCommand, IRequest<ResponseCommand>
    {
        public Guid Id { get; }

        public string Nome { get; }

        public int Idade { get; }

        public ClienteAtualizarCommand(Guid id, string nome, int idade)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
        }

        public override void Validar()
        {
            Erros = new List<string>(0);

            if (Id == default)
            {
                Erros.Add("Id é obrigatório");
            }

            if (string.IsNullOrEmpty(Nome))
            {
                Erros.Add("Nome é obrigatório");
            }

            if (Idade <= 0)
            {
                Erros.Add("Idade é obrigatório");
            }
        }
    }
}

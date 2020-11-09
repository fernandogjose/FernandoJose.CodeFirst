using FernandoJose.CodeFirst.Domain.Share.Commands;
using MediatR;
using System;
using System.Collections.Generic;

namespace FernandoJose.CodeFirst.Domain.Cliente.Commands
{
    public class ClienteAdicionarCommand : RequestCommand, IRequest<ResponseCommand>
    {
        public Guid Id { get; private set; }

        public string Nome { get; }

        public int Idade { get; }

        public ClienteAdicionarCommand(string nome, int idade)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Idade = idade;
        }

        public override void Validar()
        {
            Erros = new List<string>(0);

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

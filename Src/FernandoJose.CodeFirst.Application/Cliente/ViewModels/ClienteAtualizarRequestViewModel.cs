using System;

namespace FernandoJose.CodeFirst.Application.Cliente.ViewModels
{
    public class ClienteAtualizarRequestViewModel
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }
    }
}

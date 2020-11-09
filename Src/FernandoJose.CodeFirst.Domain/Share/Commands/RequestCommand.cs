using System.Collections.Generic;

namespace FernandoJose.CodeFirst.Domain.Share.Commands
{
    public abstract class RequestCommand
    {
        public List<string> Erros { get; protected set; }

        public abstract void Validar();

        public bool Valido()
        {
            return Erros == null || Erros.Count == 0;
        }

        public void AdicionarErro(string erro)
        {
            (Erros ??= new List<string>(0)).Add(erro);
        }
    }
}

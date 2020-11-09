namespace FernandoJose.CodeFirst.Domain.Share.Commands
{
    public class ResponseCommand
    {
        public bool Sucesso { get; }

        public object Objeto { get; }

        public ResponseCommand(bool successo, object objeto)
        {
            Sucesso = successo;
            Objeto = objeto;
        }
    }
}

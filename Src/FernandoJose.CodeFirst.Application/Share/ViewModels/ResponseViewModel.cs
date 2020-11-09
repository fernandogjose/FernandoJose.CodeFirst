namespace FernandoJose.CodeFirst.Application.Share.ViewModels
{
    public class ResponseViewModel
    {
        public bool Successo { get; }

        public object Objeto { get; }

        public ResponseViewModel(bool successo, object objeto)
        {
            Successo = successo;
            Objeto = objeto;
        }
    }
}

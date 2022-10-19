using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class PublicarFilaSerapEstudanteAcompanhamentoCommand : IRequest<bool>
    {
        public PublicarFilaSerapEstudanteAcompanhamentoCommand(string fila, object mensagem)
        {
            Fila = fila;
            Mensagem = mensagem;
        }

        public string Fila { get; set; }
        public object Mensagem { get; set; }

    }
}

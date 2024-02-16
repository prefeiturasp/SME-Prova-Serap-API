using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class SalvarCacheCommand : IRequest<bool>
    {
        public SalvarCacheCommand(string nomeChave, object valor, int? minutosParaExpirar = null)
        {
            NomeChave = nomeChave;
            Valor = valor;
            MinutosParaExpirar = minutosParaExpirar;
        }

        public string NomeChave { get; }
        public object Valor { get; }
        public int? MinutosParaExpirar { get; }
    }
}

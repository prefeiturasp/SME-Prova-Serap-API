using MediatR;

namespace SME.SERAp.Prova.Aplicacao
{
    public class SalvarCacheCommand : IRequest<bool>
    {
        public SalvarCacheCommand(string nomeChave, object valor)
        {
            NomeChave = nomeChave;
            Valor = valor;
        }

        public string NomeChave { get; set; }
        public object Valor { get; set; }
    }
}

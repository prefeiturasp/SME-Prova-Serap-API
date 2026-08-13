using MediatR;

namespace SME.SERAp.Prova.Aplicacao.Queries.ExisteProvaPresencaPorNomeEAno
{
    public class ExisteProvaPresencaPorNomeEAnoQuery : IRequest<bool>
    {
        public ExisteProvaPresencaPorNomeEAnoQuery(string nomeProva, int anoProva)
        {
            NomeProva = nomeProva;
            AnoProva = anoProva;
        }

        public string NomeProva { get; set; }
        public int AnoProva { get; set; }
    }
}
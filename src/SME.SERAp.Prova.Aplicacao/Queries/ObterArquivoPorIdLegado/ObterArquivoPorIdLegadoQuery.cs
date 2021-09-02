using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterArquivoPorIdLegadoQuery : IRequest<Arquivo>
    {
        public ObterArquivoPorIdLegadoQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}

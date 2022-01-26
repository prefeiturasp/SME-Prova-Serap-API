using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterArquivoAudioPorIdQuery : IRequest<ArquivoRetornoDto>
    {
        public ObterArquivoAudioPorIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}

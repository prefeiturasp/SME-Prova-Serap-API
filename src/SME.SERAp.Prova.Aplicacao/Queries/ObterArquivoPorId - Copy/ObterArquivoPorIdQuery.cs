using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterArquivoPorIdQuery : IRequest<Arquivo>
    {
        public ObterArquivoPorIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}

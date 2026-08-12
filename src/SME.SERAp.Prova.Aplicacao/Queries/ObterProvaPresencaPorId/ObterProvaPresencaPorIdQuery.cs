using MediatR;
using SME.SERAp.Prova.Infra.Dtos.ProvaPresenca;

namespace SME.SERAp.Prova.Aplicacao.Queries.ObterProvaPresencaPorId
{
    public class ObterProvaPresencaPorIdQuery : IRequest<ListarProvaPresencaDto>
    {
        public ObterProvaPresencaPorIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
using MediatR;
using SME.SERAp.Prova.Infra.Dtos.ProvaPresenca;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao.Queries.ObterListaProvaPresenca
{
    public class ObterListaProvaPresencaQuery : IRequest<IEnumerable<ListarProvaPresencaDto>>
    {
        public ObterListaProvaPresencaQuery()
        {
        }
    }
}
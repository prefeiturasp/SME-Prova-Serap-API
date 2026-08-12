using MediatR;
using SME.SERAp.Prova.Dados.Interfaces;
using SME.SERAp.Prova.Infra.Dtos.ProvaPresenca;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.Queries.ObterListaProvaPresenca
{
    public class ObterListaProvaPresencaQueryHandler : IRequestHandler<ObterListaProvaPresencaQuery, IEnumerable<ListarProvaPresencaDto>>
    {
        private readonly IRepositorioProvaPresenca repositorioProvaPresenca;

        public ObterListaProvaPresencaQueryHandler(IRepositorioProvaPresenca repositorioProvaPresenca)
        {
            this.repositorioProvaPresenca = repositorioProvaPresenca;
        }

        public async Task<IEnumerable<ListarProvaPresencaDto>> Handle(ObterListaProvaPresencaQuery request, CancellationToken cancellationToken)
        {
            var provasPresenca = await repositorioProvaPresenca.ObterTodasAsync();

            return provasPresenca;
        }
    }
}
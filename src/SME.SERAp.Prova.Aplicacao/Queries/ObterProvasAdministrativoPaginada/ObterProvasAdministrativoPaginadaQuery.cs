using MediatR;
using SME.SERAp.Prova.Infra.Dtos;

namespace SME.SERAp.Prova.Aplicacao.Queries.ObterProvasAdministrativoPaginada
{
    public class ObterProvasAdministrativoPaginadaQuery : IRequest<PaginacaoResultadoDto<Dominio.Prova>>
    {
        public ProvaAdmFiltroDto Filtro { get; set; }
        public bool InicioFuturo { get; set; }

        public ObterProvasAdministrativoPaginadaQuery(ProvaAdmFiltroDto paginacao, bool inicioFuturo)
        {
            Filtro = paginacao;
            InicioFuturo = inicioFuturo;
        }
    }
}

using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasAdministrativoPaginadaQueryHandler : IRequestHandler<ObterProvasAdministrativoPaginadaQuery, PaginacaoResultadoDto<ProvaAreaAdministrativoRetornoDto>>
    {
        private readonly IRepositorioProva repositorioProva;

        public ObterProvasAdministrativoPaginadaQueryHandler(IRepositorioProva repositorioProva)
        {
            this.repositorioProva = repositorioProva ?? throw new System.ArgumentNullException(nameof(repositorioProva));
        }

        public async Task<PaginacaoResultadoDto<ProvaAreaAdministrativoRetornoDto>> Handle(ObterProvasAdministrativoPaginadaQuery request, CancellationToken cancellationToken)
        {
            request.Filtro.NumeroPagina = request.Filtro.NumeroPagina <= 0 ? 1 : request.Filtro.NumeroPagina;
            request.Filtro.QuantidadeRegistros = request.Filtro.QuantidadeRegistros <= 0 ? 10 : request.Filtro.QuantidadeRegistros;

            return await repositorioProva.ObterProvasPaginada(request.Filtro, request.InicioFuturo, request.Perfil, request.Login);
        }
    }
}

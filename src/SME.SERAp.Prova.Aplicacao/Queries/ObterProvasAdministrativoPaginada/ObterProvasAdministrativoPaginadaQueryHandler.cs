﻿using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.Queries.ObterProvasAdministrativoPaginada
{
    public class ObterProvasAdministrativoPaginadaQueryHandler : IRequestHandler<ObterProvasAdministrativoPaginadaQuery, PaginacaoResultadoDto<Dominio.Prova>>
    {
        private readonly IRepositorioProva repositoryProva;

        public ObterProvasAdministrativoPaginadaQueryHandler(IRepositorioProva repositorioProva)
        {
            this.repositoryProva = repositorioProva;
        }

        public async Task<PaginacaoResultadoDto<Dominio.Prova>> Handle(ObterProvasAdministrativoPaginadaQuery request, CancellationToken cancellationToken)
        {
            request.Filtro.NumeroPagina = request.Filtro.NumeroPagina <= 0 ? 1 : request.Filtro.NumeroPagina;
            request.Filtro.QuantidadeRegistros = request.Filtro.QuantidadeRegistros <= 0 ? 10 : request.Filtro.QuantidadeRegistros;

            return await repositoryProva.ObterProvasPaginada(request.Filtro, request.InicioFuturo);
        }
    }
}

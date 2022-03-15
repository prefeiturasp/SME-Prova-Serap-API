using MediatR;
using SME.SERAp.Prova.Aplicacao.Queries.ObterProvasAdministrativoPaginada;
using SME.SERAp.Prova.Dominio.Constantes;
using SME.SERAp.Prova.Infra.Dtos;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class ObterProvaAreaAdministrativoUseCase : IObterProvaAreaAdministrativoUseCase
    {
        private readonly IMediator mediator;

        public ObterProvaAreaAdministrativoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<PaginacaoResultadoDto<ProvaAreaAdministrativoRetornoDto>> Executar(ProvaAdmFiltroDto paginacaoFiltroDto)
        {
            var claims = await mediator.Send(new ObterUsuarioLogadoInformacoesPorClaimsQuery("Perfil"));
            var perfil = claims.FirstOrDefault(a => a.Chave == "Perfil")?.Valor;
            var ehGuid = Guid.TryParse(perfil, out var guidPerfil);

            if(!ehGuid) throw new NaoAutorizadoException("Perfil Inválido", 401);

            var provas = await mediator.Send(new ObterProvasAdministrativoPaginadaQuery(paginacaoFiltroDto, Perfis.PERFIL_ADMINISTRADOR == guidPerfil));
            return provas;
        }
    }
}

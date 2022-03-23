using MediatR;
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
            var claims = await mediator.Send(new ObterUsuarioLogadoInformacoesPorClaimsQuery("PERFIL", "LOGIN"));
            var perfil = claims.FirstOrDefault(a => a.Chave == "PERFIL")?.Valor;
            var ehGuid = Guid.TryParse(perfil, out var guidPerfil);

            if(!ehGuid) throw new NaoAutorizadoException("Perfil Inválido", 401);

            var login = claims.FirstOrDefault(a => a.Chave == "LOGIN")?.Valor;

            if(guidPerfil == Perfis.PERFIL_ADMINISTRADOR)
                return await mediator.Send(new ObterProvasAdministrativoPaginadaQuery(paginacaoFiltroDto, true));

            return await mediator.Send(new ObterProvasAdministrativoPaginadaQuery(paginacaoFiltroDto, false, guidPerfil, login));
        }
    }
}

using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Dominio.Constantes;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SME.SERAp.Prova.Infra.Exceptions;

namespace SME.SERAp.Prova.Aplicacao
{
    public class AutenticarUsuarioAdmUseCase : IAutenticarUsuarioAdmUseCase
    {
        private readonly IMediator mediator;
        public IConfiguration Configuration { get; }
        public AutenticarUsuarioAdmUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<UsuarioAutenticacaoDto> Executar(AutenticacaoAdmDto autenticacaoDto)
        {
            VerificaChaveApi(autenticacaoDto.ChaveApi);
            PerfilEhValido(autenticacaoDto.Perfil);
            return await CriaTokenAdm(autenticacaoDto);
        }

        private async Task<UsuarioAutenticacaoDto> CriaTokenAdm(AutenticacaoAdmDto autenticacaoDto)
        {
            var retornoDto = new UsuarioAutenticacaoDto();
            var tokenDtExpiracao =
                await mediator.Send(new ObterTokenJwtAdmQuery(autenticacaoDto.Login, Guid.Parse(autenticacaoDto.Perfil)));
            retornoDto.Token = tokenDtExpiracao.Item1;
            retornoDto.DataHoraExpiracao = tokenDtExpiracao.Item2;
            return retornoDto;
        }

        private void VerificaChaveApi(string chaveApi)
        {
            if (chaveApi != Environment.GetEnvironmentVariable("ChaveSerapProvaApi"))
                throw new NaoAutorizadoException("Não Autorizado", 401);
        }

        private void PerfilEhValido(string perfil)
        {
            var ehGuid = Guid.TryParse(perfil, out var guidPerfil);

            if (!ehGuid || 
               guidPerfil != Perfis.PERFIL_ADMINISTRADOR &&
               guidPerfil != Perfis.PERFIL_ADMINISTRADOR_NTA &&
               guidPerfil != Perfis.PERFIL_PROFESSOR &&
               guidPerfil != Perfis.PERFIL_SERAP_DRE &&
               guidPerfil != Perfis.PERFIL_SERAP_UE)
            {
                throw new NaoAutorizadoException("Perfil Inválido", 402);
            }
        }
    }
}

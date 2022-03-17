using MediatR;
using SME.SERAp.Prova.Dominio.Constantes;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class AutenticarUsuarioAdmUseCase : IAutenticarUsuarioAdmUseCase
    {
        private readonly IMediator mediator;
        public AutenticarUsuarioAdmUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<string> Executar(AutenticacaoAdmDto autenticacaoDto)
        {
            // TODO: Validar login do usuário adm.

            VerificaChaveApi(autenticacaoDto.ChaveApi);
            PerfilEhValido(autenticacaoDto.Perfil);

            return await mediator.Send(new GerarCodigoValidacaoAdmCommand(autenticacaoDto.Login, Guid.Parse(autenticacaoDto.Perfil)));
        }

        private static void VerificaChaveApi(string chaveApi)
        {
            if (chaveApi != Environment.GetEnvironmentVariable("ChaveSerapProvaApi"))
                throw new NaoAutorizadoException("Não Autorizado", 401);
        }

        private static void PerfilEhValido(string perfil)
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

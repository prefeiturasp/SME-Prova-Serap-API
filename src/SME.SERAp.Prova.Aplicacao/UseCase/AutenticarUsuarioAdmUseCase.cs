﻿using MediatR;
using SME.SERAp.Prova.Dominio.Constantes;
using SME.SERAp.Prova.Infra;
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

        public async Task<AutenticacaoValidarAdmDto> Executar(AutenticacaoAdmDto autenticacaoDto)
        {
            var usuario = await mediator.Send(new ObterUsuarioSerapCoreSSOPorLoginQuery(autenticacaoDto.Login));
            if (usuario == null)
                throw new NaoAutorizadoException("Usuário inválido", 401);

            VerificaChaveApi(autenticacaoDto.ChaveApi);
            PerfilEhValido(autenticacaoDto.Perfil);

            return await mediator.Send(new GerarCodigoValidacaoAdmCommand(autenticacaoDto.Login, usuario.Nome, Guid.Parse(autenticacaoDto.Perfil)));
        }

        private void VerificaChaveApi(string chaveApi)
        {
            if (chaveApi != Environment.GetEnvironmentVariable("ChaveSerapProvaApi"))
                throw new NaoAutorizadoException("Chave api inválida", 401);
        }

        private static void PerfilEhValido(string perfil)
        {
            var ehGuid = Guid.TryParse(perfil, out var guidPerfil);

            if (!ehGuid ||
                guidPerfil != Perfis.PERFIL_ADMINISTRADOR &&
                guidPerfil != Perfis.PERFIL_ADMINISTRADOR_SERAP_DRE &&
                guidPerfil != Perfis.PERFIL_ADMINISTRADOR_NTA &&
                guidPerfil != Perfis.PERFIL_ADMINISTRADOR_SERAP_UE &&
                guidPerfil != Perfis.PERFIL_ASSISTENTE_DIRETOR_UE &&
                guidPerfil != Perfis.PERFIL_COORDENADOR_PEDAGOGICO &&
                guidPerfil != Perfis.PERFIL_DIRETOR_ESCOLAR &&
                guidPerfil != Perfis.PERFIL_PROFESSOR &&
                guidPerfil != Perfis.PERFIL_PROFESSOR_OLD &&
                guidPerfil != Perfis.PERFIL_ADM_COPED_LEITURA)
                throw new NaoAutorizadoException("Perfil Inválido", 401);
        }
    }
}

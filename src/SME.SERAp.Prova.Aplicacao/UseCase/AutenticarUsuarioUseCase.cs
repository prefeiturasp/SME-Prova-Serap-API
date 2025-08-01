﻿using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class AutenticarUsuarioUseCase : IAutenticarUsuarioUseCase
    {
        private readonly IMediator mediator;

        public AutenticarUsuarioUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<UsuarioAutenticacaoDto> Executar(AutenticacaoDto autenticacaoDto)
        {
            var retornoDto = new UsuarioAutenticacaoDto();

            var aluno = await mediator.Send(new ObterAlunoAtivoQuery(autenticacaoDto.Login));
            if (aluno != null)
            {
                var podeGerarToken =
                    await mediator.Send(
                        new VerificaAutenticacaoUsuarioQuery(autenticacaoDto.Login, autenticacaoDto.Senha, aluno.DataNascimento));
                if (podeGerarToken)
                {
                    var tokenDtExpiracao =
                        await mediator.Send(new ObterTokenJwtQuery(autenticacaoDto.Login, aluno.Ano, aluno.TipoTurno, (int)aluno.Modalidade, autenticacaoDto.Dispositivo));
                    retornoDto.Token = tokenDtExpiracao.Item1;
                    retornoDto.DataHoraExpiracao = tokenDtExpiracao.Item2;
                }
                else 
                    throw new NaoAutorizadoException("Senha inválida", 412);

                await mediator.Send(new IncluirOuAtualizarUsuarioCommand(autenticacaoDto.Login, ""));
                
                retornoDto.UltimoLogin = DateTime.Now;

                //-> força renovação dos cache.
                await mediator.Send(new RemoverCacheCommand(string.Format(CacheChave.Aluno, aluno.Ra)));
                await mediator.Send(new RemoverCacheCommand(string.Format(CacheChave.MeusDados, aluno.Ra)));
                await mediator.Send(new RemoverCacheCommand(string.Format(CacheChave.AlunoDeficiencia, aluno.Ra)));
                await mediator.Send(new RemoverCacheCommand(string.Format(CacheChave.PreferenciasAluno, aluno.Ra)));
            }
            else throw new NaoAutorizadoException($"Código EOL {autenticacaoDto.Login} inválido", 411);

            await PublicarFilaSalvarUsuarioDispositivoLogin(aluno.Ra, autenticacaoDto.Dispositivo, aluno.TurmaId);
            return retornoDto;
        }

        private async Task PublicarFilaSalvarUsuarioDispositivoLogin(long ra, string dispositivoId, long? turmaId)
        {
            var usuarioDispositivo = new UsuarioDispositivoLoginDto(ra, dispositivoId != null ? dispositivoId : string.Empty, turmaId);
            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.TratarUsuarioDispositivoLogin, usuarioDispositivo));
        }
    }
}

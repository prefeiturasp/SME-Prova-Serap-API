using MediatR;
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

            var aluno = await mediator.Send(new ObterAlunoAtivoEolQuery(autenticacaoDto.Login));
            if (aluno != null)
            {
                var podeGerarToken =
                    await mediator.Send(
                        new VerificaAutenticacaoUsuarioQuery(autenticacaoDto.Login, autenticacaoDto.Senha));
                if (podeGerarToken)
                {
                    var tokenDtExpiracao =
                        await mediator.Send(new ObterTokenJwtQuery(autenticacaoDto.Login, aluno.Ano, aluno.TipoTurno));
                    retornoDto.Token = tokenDtExpiracao.Item1;
                    retornoDto.DataHoraExpiracao = tokenDtExpiracao.Item2;
                }
                else throw new NaoAutorizadoException("Senha inválida", 412);

                if (!string.IsNullOrEmpty(autenticacaoDto.Dispositivo))
                {
                    await mediator.Send(new IncluirUsuarioDispositivoCommand(autenticacaoDto.Login,
                        autenticacaoDto.Dispositivo, aluno.Ano));
                }

                var verificaUsuario = await mediator.Send(new ObterUsuarioPorLoginQuery(aluno.CodigoAluno));

                if (verificaUsuario == null)
                {
                    await mediator.Send(new IncluirAlunoCommand(autenticacaoDto.Login, ""));
                } else
                {
                    verificaUsuario.AtualizaUltimoLogin();
                    await mediator.Send(new AtualizarUsuarioCommand(verificaUsuario));
                    retornoDto.UltimoLogin = verificaUsuario.UltimoLogin;
                }
            }
            else throw new NaoAutorizadoException("Código EOL inválido", 411);

            return retornoDto;
        }
    }
}
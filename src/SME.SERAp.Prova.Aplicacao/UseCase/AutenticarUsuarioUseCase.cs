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

            var aluno = await mediator.Send(new ObterAlunoAtivoQuery(autenticacaoDto.Login));
            if (aluno != null)
            {
                var podeGerarToken =
                    await mediator.Send(
                        new VerificaAutenticacaoUsuarioQuery(autenticacaoDto.Login, autenticacaoDto.Senha));
                if (podeGerarToken)
                {
                    var tokenDtExpiracao =
                        await mediator.Send(new ObterTokenJwtQuery(autenticacaoDto.Login, aluno.Ano, aluno.TipoTurno, (int)aluno.Modalidade));
                    retornoDto.Token = tokenDtExpiracao.Item1;
                    retornoDto.DataHoraExpiracao = tokenDtExpiracao.Item2;
                }
                else throw new NaoAutorizadoException("Senha inválida", 412);
                await mediator.Send(new IncluirOuAtualizarUsuarioCommand(autenticacaoDto.Login, ""));
                retornoDto.UltimoLogin = DateTime.Now;

            }
            else throw new NaoAutorizadoException($"Código EOL {autenticacaoDto.Login} inválido", 411);

            return retornoDto;
        }
    }
}

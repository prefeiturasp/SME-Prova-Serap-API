using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class RevalidaTokenJwtUseCase : IRevalidaTokenJwtUseCase
    {
        private readonly IMediator mediator;

        public RevalidaTokenJwtUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<UsuarioAutenticacaoDto> Executar()
        {
            var alunoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());

            var tokenDataExpiracao = await mediator.Send(new ObterTokenJwtQuery(long.Parse(alunoRa)));

            return new UsuarioAutenticacaoDto(tokenDataExpiracao.Item1, tokenDataExpiracao.Item2);
        }
    }
}

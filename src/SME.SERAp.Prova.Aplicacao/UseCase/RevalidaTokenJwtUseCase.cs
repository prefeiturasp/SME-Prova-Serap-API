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
        public async Task<UsuarioAutenticacaoDto> Executar(RevalidaTokenDto revalidaTokenDto)
        {
            var tokenInformacoes = await mediator.Send(new VerificaERetornaInformacoesPorTokenQuery(revalidaTokenDto.Token));            

            var tokenDataExpiracao = await mediator.Send(new ObterTokenJwtQuery(tokenInformacoes.Ra, tokenInformacoes.Ano));

            return new UsuarioAutenticacaoDto(tokenDataExpiracao.Item1, tokenDataExpiracao.Item2);
        }
    }
}

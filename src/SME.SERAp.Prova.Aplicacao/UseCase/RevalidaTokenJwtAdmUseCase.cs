using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class RevalidaTokenJwtAdmUseCase : IRevalidaTokenJwtAdmUseCase
    {
        private readonly IMediator mediator;

        public RevalidaTokenJwtAdmUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<UsuarioAutenticacaoDto> Executar(RevalidaTokenDto revalidaTokenDto)
        {
            var tokenInformacoes = await mediator.Send(new VerificaERetornaInformacoesPorTokenAdmQuery(revalidaTokenDto.Token));            

            var tokenDataExpiracao = await mediator.Send(new ObterTokenJwtAdmQuery(tokenInformacoes.Login, tokenInformacoes.Nome, tokenInformacoes.Perfil));

            return new UsuarioAutenticacaoDto(tokenDataExpiracao.Item1, tokenDataExpiracao.Item2);
        }
    }
}

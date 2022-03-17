using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class AutenticarUsuarioValidarAdmUseCase : IAutenticarUsuarioValidarAdmUseCase
    {
        private readonly IMediator mediator;
        public AutenticarUsuarioValidarAdmUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<UsuarioAutenticacaoDto> Executar(AutenticacaoValidarAdmDto autenticacaoValidarAdmDto)
        {
            var usuario = await mediator.Send(new ObterCodigoValidacaoAdmQuery(autenticacaoValidarAdmDto.Codigo));

            if(usuario == null)
                throw new NaoAutorizadoException("Código inválido", 401);

            return await CriaTokenAdm(usuario);
        }

        private async Task<UsuarioAutenticacaoDto> CriaTokenAdm(AutenticacaoUsuarioAdmDto autenticacaoDto)
        {
            var retornoDto = new UsuarioAutenticacaoDto();
            var tokenDtExpiracao =
                await mediator.Send(new ObterTokenJwtAdmQuery(autenticacaoDto.Login, autenticacaoDto.Perfil));
            retornoDto.Token = tokenDtExpiracao.Item1;
            retornoDto.DataHoraExpiracao = tokenDtExpiracao.Item2;
            return retornoDto;
        }
    }
}

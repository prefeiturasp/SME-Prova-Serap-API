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

            var usuarioExiste = await mediator.Send(new VerificaUsuarioAtivoQuery(autenticacaoDto.Login));
            if (usuarioExiste)
            {
                var podeGerarToken = await mediator.Send(new VerificaAutenticacaoUsuarioQuery(autenticacaoDto.Login, autenticacaoDto.Senha));
                if (podeGerarToken)
                {
                    retornoDto.Token = await mediator.Send(new ObterTokenJwtQuery(autenticacaoDto.Login));
                }
                else throw new NaoAutorizadoException("Não autorizado");

            } else throw new NaoAutorizadoException("Não autorizado");

            return retornoDto;
        }
    }
}

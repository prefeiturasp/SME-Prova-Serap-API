using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<UsuarioAutenticacaoDto> Executar(AutenticacaoAdmDto autenticacaoDto)
        {
            var retornoDto = new UsuarioAutenticacaoDto();

            // Verifica se perfil é valido
            // Verifica se guid é valido

            var tokenDtExpiracao =
                await mediator.Send(new ObterTokenJwtAdmQuery(autenticacaoDto.Login, Guid.Parse(autenticacaoDto.Perfil)));
            retornoDto.Token = tokenDtExpiracao.Item1;
            retornoDto.DataHoraExpiracao = tokenDtExpiracao.Item2;
              //  else throw new NaoAutorizadoException("Senha inválida", 412);

            return retornoDto;
        }
}
}

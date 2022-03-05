using MediatR;
using SME.SERAp.Prova.Infra.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class ObterProvaResumoAreaAdministrativoUseCase : IObterProvaResumoAreaAdministrativoUseCase
    {
        private readonly IMediator mediator;

        public ObterProvaResumoAreaAdministrativoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<ProvaResumoAdministrativoRetornoDto>> Executar(long provaId, string caderno = null)
        {
            return await mediator.Send(new ObterProvasResumoAdministrativoQuery(provaId, caderno));
        }
    }
}

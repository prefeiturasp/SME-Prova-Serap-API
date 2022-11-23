﻿using MediatR;
using SME.SERAp.Prova.Infra;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class ObterProvaResultadoResumoUseCase : IObterProvaResultadoResumoUseCase
    {

        private readonly IMediator mediator;

        public ObterProvaResultadoResumoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<ProvaResultadoResumoDto>> Executar(long provaId)
        {
            var ra = await mediator.Send(new ObterRAUsuarioLogadoQuery());
            return await mediator.Send(new ObterProvaResultadoResumoQuery(provaId, ra));
        }
    }
}

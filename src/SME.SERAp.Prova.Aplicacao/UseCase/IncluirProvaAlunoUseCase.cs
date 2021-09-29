using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirProvaAlunoUseCase : IIncluirProvaAlunoUseCase
    {
        private readonly IMediator mediator;

        public IncluirProvaAlunoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<bool> Executar(long provaId, int status)
        {
            var alunoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());

            var provaStatus = await mediator.Send(new ObterProvaAlunoPorProvaIdRaQuery(provaId, alunoRa));

            if (provaStatus == null)
            {
                return await mediator.Send(new IncluirProvaAlunoCommand(provaId, alunoRa, (ProvaStatus)status));

            }
            else
            {
                if (provaStatus.Status == Dominio.ProvaStatus.Finalizado)
                    throw new NaoAutorizadoException("Esta prova já foi finalizada", 411);
                
                await mediator.Send(new ExcluirProvaAlunoPorIdCommand(provaStatus));
                return await mediator.Send(new IncluirProvaAlunoCommand(provaId, alunoRa, (ProvaStatus)status));
            }

        }
    }
}

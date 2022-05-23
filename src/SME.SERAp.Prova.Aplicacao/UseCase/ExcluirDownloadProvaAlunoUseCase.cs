using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ExcluirDownloadProvaAlunoUseCase : AbstractUseCase, IExcluirDownloadProvaAlunoUseCase
    {
        public ExcluirDownloadProvaAlunoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(long[] ids)
        {
            var dataAlteracao = DateTime.Now.AddHours(3);
            return await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.ExcluirDownloadProva, new ExcluirDownloadProvaAlunoDto(ids, dataAlteracao)));
        }
    }
}

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

        public async Task<bool> Executar(Guid[] codigos)
        {
            var dataAlteracao = DateTime.Now.AddHours(3);
            var excluirDownloadProvaAluno = new DownloadProvaAlunoExcluirDto(codigos, dataAlteracao);
            return await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.DownloadProvaAlunoTratar, new DownloadProvaAlunoFilaDto(Dominio.DownloadProvaAlunoSituacao.Excluir, null, excluirDownloadProvaAluno)));
        }
    }
}

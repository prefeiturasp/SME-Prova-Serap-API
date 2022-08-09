using MediatR;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class ReabrirProvaAlunoUseCase : AbstractUseCase, IReabrirProvaAlunoUseCase
    {
        public ReabrirProvaAlunoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(long provaId, long[] alunosRA)
        {
            foreach (var aluno in alunosRA)
            {
                await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.ReabrirProvaAluno, new { ProvaId = provaId, AlunoRA = aluno }));
            }

            return true;
        }
    }
}

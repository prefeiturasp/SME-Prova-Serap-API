using MediatR;
using SME.SERAp.Prova.Infra;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirDownloadProvaAlunoUseCase : AbstractUseCase, IIncluirDownloadProvaAlunoUseCase
    {
        public IncluirDownloadProvaAlunoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<bool> Executar(DownloadProvaAlunoDto downloadProvaAlunoDto)
        {
            downloadProvaAlunoDto.AlunoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());
            return await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.IncluirDownloadProva, downloadProvaAlunoDto));
        }
    }
}

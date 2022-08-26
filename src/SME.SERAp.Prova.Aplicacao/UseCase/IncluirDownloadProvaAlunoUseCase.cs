using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirDownloadProvaAlunoUseCase : AbstractUseCase, IIncluirDownloadProvaAlunoUseCase
    {
        public IncluirDownloadProvaAlunoUseCase(IMediator mediator) : base(mediator)
        {
        }

        public async Task<Guid> Executar(DownloadProvaAlunoDto downloadProvaAlunoDto)
        {
            downloadProvaAlunoDto.Codigo = Guid.NewGuid();
            downloadProvaAlunoDto.AlunoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());

            await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.DownloadProvaAlunoTratar, new DownloadProvaAlunoFilaDto(Dominio.DownloadProvaAlunoSituacao.Incluir, downloadProvaAlunoDto, null)));
            await mediator.Send(new PublicarFilaSerapEstudanteAcompanhamentoCommand(RotasRabbit.AcompanhamentoProvaAlunoDownloadTratar, downloadProvaAlunoDto));

            return downloadProvaAlunoDto.Codigo;
        }
    }
}

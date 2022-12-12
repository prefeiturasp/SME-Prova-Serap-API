using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.Aluno;
using SME.SERAp.Prova.Infra.Exceptions;
using SME.SERAp.Prova.Infra.Interfaces;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.UseCase
{
    public class FinalizarProvaTaiUseCase : AbstractUseCase, IFinalizarProvaTaiUseCase
    {

        private readonly IServicoLog servicoLog;
        private DadosAlunoLogadoDto dadosAlunoLogado;

        public FinalizarProvaTaiUseCase(IMediator mediator, IServicoLog servicoLog) : base(mediator)
        {
            this.servicoLog = servicoLog ?? throw new ArgumentNullException(nameof(servicoLog));
        }

        public async Task<bool> Executar(long provaId, ProvaAlunoStatusDto provaAlunoStatusDto)
        {
            try
            {
                await ObterDadosAlunoLogado();
                var provaStatus = await mediator.Send(new ObterProvaAlunoPorProvaIdRaQuery(provaId, dadosAlunoLogado.Ra));
                if (provaStatus == null) throw new NegocioException($"Prova do aluno não encontrada", 411);

                provaStatus.Status = ProvaStatus.Finalizado;
                provaStatus.FinalizadoEm = ObterDatafim(provaAlunoStatusDto.DataFim);
                return await FinalizarProvaAluno(provaStatus);
            }
            catch (Exception ex)
            {
                servicoLog.Registrar($"ProvaId = {provaId} -- Status {provaAlunoStatusDto.Status} -- DataInicio {provaAlunoStatusDto.DataInicio} -- DataFim, {provaAlunoStatusDto.DataFim} " +
                        $"Tipo Dispositivo = {provaAlunoStatusDto.TipoDispositivo} --  ", ex);
                throw;
            }
        }

        private async Task ObterDadosAlunoLogado()
        {
            dadosAlunoLogado = await mediator.Send(new ObterDadosAlunoLogadoQuery());
        }

        private async Task<bool> FinalizarProvaAluno(ProvaAluno provaAluno)
        {
            await mediator.Send(new AtualizarProvaAlunoCommand(provaAluno));
            await PublicarAcompProvaAlunoInicioFimTratar(provaAluno.ProvaId, dadosAlunoLogado.Ra, (int)provaAluno.Status, provaAluno.CriadoEm, provaAluno.FinalizadoEm);
            return true;
        }

        private DateTime ObterDatafim(long? DataFim)
        {
            return (DataFim != null && DataFim > 0) ? new DateTime(DataFim.Value).AddHours(-3) : DateTime.Now.AddHours(-3);
        }

        private async Task PublicarAcompProvaAlunoInicioFimTratar(long provaId, long alunoRa, int status, DateTime? criadoEm, DateTime? finalizadoEm)
        {
            var provaAlunoAcompDto = new ProvaAlunoAcompDto(provaId, alunoRa, status, criadoEm, finalizadoEm);
            await mediator.Send(new PublicarFilaSerapEstudanteAcompanhamentoCommand(RotasRabbit.AcompProvaAlunoInicioFimTratar, provaAlunoAcompDto));
        }
    }
}

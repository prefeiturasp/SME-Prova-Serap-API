using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.Aluno;
using SME.SERAp.Prova.Infra.Exceptions;
using SME.SERAp.Prova.Infra.Interfaces;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirProvaAlunoUseCase : IIncluirProvaAlunoUseCase
    {
        private readonly IMediator mediator;
        private readonly IServicoLog servicoLog;
        private DadosAlunoLogadoDto dadosAlunoLogado;

        public IncluirProvaAlunoUseCase(IMediator mediator, IServicoLog servicoLog)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.servicoLog = servicoLog ?? throw new ArgumentNullException(nameof(servicoLog));
        }

        public async Task<bool> Executar(long provaId, ProvaAlunoStatusDto provaAlunoStatusDto)
        {
            long alunoRa = 0;
            try
            {
                await ObterDadosAlunoLogado();
                var provaStatus = await mediator.Send(new ObterProvaAlunoPorProvaIdRaQuery(provaId, dadosAlunoLogado.Ra));
                var dataInicio = DateTime.Now;

                if (provaAlunoStatusDto.DataInicio != null && provaAlunoStatusDto.DataInicio != 0)
                    dataInicio = (DateTime)provaAlunoStatusDto.DataMenos3Horas(provaAlunoStatusDto.DataInicio);

                if (provaStatus == null)
                {
                    return await IncluirProva(provaId, provaAlunoStatusDto, dataInicio);
                }
                else
                {
                    if (provaStatus.Status == ProvaStatus.Finalizado)
                        throw new NegocioException("Esta prova já foi finalizada", 411);
                    return await AtualizarProva(provaAlunoStatusDto, provaStatus);
                }
            }
            catch (Exception ex)
            {
                servicoLog.Registrar($"ProvaId = {provaId} -- Status {provaAlunoStatusDto.Status} -- DataInicio { provaAlunoStatusDto.DataInicio} -- DataFim, { provaAlunoStatusDto.DataFim} " +
                        $"Tipo Dispositivo = {provaAlunoStatusDto.TipoDispositivo} --  ", ex);
                throw;
            }
        }

        private async Task ObterDadosAlunoLogado()
        {
            dadosAlunoLogado = await mediator.Send(new ObterDadosAlunoLogadoQuery());
        }

        private async Task<bool> AtualizarProva(ProvaAlunoStatusDto provaAlunoStatusDto, ProvaAluno provaStatus)
        {
            provaStatus.TipoDispositivo = provaAlunoStatusDto.TipoDispositivo.HasValue ? (TipoDispositivo)provaAlunoStatusDto.TipoDispositivo : TipoDispositivo.NaoCadastrado;
            provaStatus.Status = (ProvaStatus)provaAlunoStatusDto.Status;
            if ((ProvaStatus)provaAlunoStatusDto.Status == ProvaStatus.Finalizado)
                provaStatus.FinalizadoEm = provaAlunoStatusDto.DataFim != null && provaAlunoStatusDto.DataFim != 0 ? provaAlunoStatusDto.DataMenos3Horas(provaAlunoStatusDto.DataFim) : DateTime.Now;
            provaStatus.TipoDispositivo = (TipoDispositivo)provaAlunoStatusDto.TipoDispositivo;

            provaStatus.DispositivoId = dadosAlunoLogado.DispositivoId;
            await PublicarAcompProvaAlunoInicioFimTratar(provaStatus.ProvaId, provaStatus.AlunoRA, (int)provaStatus.Status, provaStatus.CriadoEm, provaStatus.FinalizadoEm);
            return await mediator.Send(new AtualizarProvaAlunoCommand(provaStatus));
        }

        private async Task<bool> IncluirProva(long provaId, ProvaAlunoStatusDto provaAlunoStatusDto, DateTime dataInicio)
        {
            var dataFim = provaAlunoStatusDto.DataFim != null && provaAlunoStatusDto.DataFim != 0 ? provaAlunoStatusDto.DataMenos3Horas(provaAlunoStatusDto.DataFim) : null;
            await PublicarAcompProvaAlunoInicioFimTratar(provaId, dadosAlunoLogado.Ra, provaAlunoStatusDto.Status, dataInicio, dataFim);
            return await mediator.Send(new IncluirProvaAlunoCommand(provaId,
                                                                    dadosAlunoLogado.Ra,
                                                                    (ProvaStatus)provaAlunoStatusDto.Status,
                                                                    dataInicio,
                                                                    dataFim,
                                                                    provaAlunoStatusDto.TipoDispositivo != null ? (TipoDispositivo)provaAlunoStatusDto.TipoDispositivo : TipoDispositivo.NaoCadastrado,
                                                                    dadosAlunoLogado.DispositivoId));
        }

        private async Task PublicarAcompProvaAlunoInicioFimTratar(long provaId, long alunoRa, int status, DateTime? criadoEm, DateTime? finalizadoEm)
        {
            var provaAlunoAcompDto = new ProvaAlunoAcompDto(provaId, alunoRa, status, criadoEm, finalizadoEm);
            await mediator.Send(new PublicarFilaSerapEstudanteAcompanhamentoCommand(RotasRabbit.AcompProvaAlunoInicioFimTratar, provaAlunoAcompDto));
        }
    }
}

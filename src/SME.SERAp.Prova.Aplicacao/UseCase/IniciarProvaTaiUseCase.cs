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
    public class IniciarProvaTaiUseCase : AbstractUseCase, IIniciarProvaTaiUseCase
    {

        private readonly IServicoLog servicoLog;
        private DadosAlunoLogadoDto dadosAlunoLogado;

        public IniciarProvaTaiUseCase(IMediator mediator, IServicoLog servicoLog) : base(mediator)
        {
            this.servicoLog = servicoLog ?? throw new ArgumentNullException(nameof(servicoLog));
        }

        public async Task<bool> Executar(long provaId, ProvaAlunoStatusDto provaAlunoStatusDto)
        {
            try
            {
                await ObterDadosAlunoLogado();
                var provaStatus = await mediator.Send(new ObterProvaAlunoPorProvaIdRaQuery(provaId, dadosAlunoLogado.Ra));
                var dataInicio = DateTime.Now;

                if (provaAlunoStatusDto.DataInicio != null && provaAlunoStatusDto.DataInicio != 0)
                    dataInicio = (DateTime)provaAlunoStatusDto.DataMenos3Horas(provaAlunoStatusDto.DataInicio);

                if (provaStatus == null)
                {
                    provaAlunoStatusDto.Status = (int)ProvaStatus.Iniciado;
                    return await IncluirProvaAluno(provaId, provaAlunoStatusDto, dataInicio);
                }
                else
                {
                    string status = provaStatus.Status == ProvaStatus.Finalizado ? "finalizada" : "iniciada";
                    throw new NegocioException($"Esta prova já foi {status}", 411);
                }
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
        private async Task<bool> IncluirProvaAluno(long provaId, ProvaAlunoStatusDto provaAlunoStatusDto, DateTime dataInicio)
        {
            var dataFim = provaAlunoStatusDto.DataFim != null && provaAlunoStatusDto.DataFim != 0 ? provaAlunoStatusDto.DataMenos3Horas(provaAlunoStatusDto.DataFim) : null;
            await PublicarAcompProvaAlunoInicioFimTratar(provaId, dadosAlunoLogado.Ra, (int)provaAlunoStatusDto.Status, dataInicio, dataFim);
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

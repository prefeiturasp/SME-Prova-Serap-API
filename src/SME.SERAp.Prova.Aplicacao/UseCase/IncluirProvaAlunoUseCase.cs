using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
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
                alunoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());

                var provaStatus = await mediator.Send(new ObterProvaAlunoPorProvaIdRaQuery(provaId, alunoRa));
                var dataInicio = DateTime.Now;

                if (provaAlunoStatusDto.DataInicio != null && provaAlunoStatusDto.DataInicio != 0)
                    dataInicio = (DateTime)provaAlunoStatusDto.DataMenos3Horas(provaAlunoStatusDto.DataInicio);

                if (provaStatus == null)
                {
                    return await mediator.Send(new IncluirProvaAlunoCommand(provaId, alunoRa, (ProvaStatus)provaAlunoStatusDto.Status,
                       dataInicio, provaAlunoStatusDto.DataFim != null && provaAlunoStatusDto.DataFim != 0 ? provaAlunoStatusDto.DataMenos3Horas(provaAlunoStatusDto.DataFim) : null, provaAlunoStatusDto.TipoDispositivo!=null?(TipoDispositivo)provaAlunoStatusDto.TipoDispositivo:TipoDispositivo.NaoCadastrado)) ;
                }
                else
                {
                    if (provaStatus.Status == Dominio.ProvaStatus.Finalizado)
                        throw new NegocioException("Esta prova já foi finalizada", 411);

                    provaStatus.TipoDispositivo = provaAlunoStatusDto.TipoDispositivo.HasValue ? (TipoDispositivo)provaAlunoStatusDto.TipoDispositivo : TipoDispositivo.NaoCadastrado;
                    provaStatus.Status = (ProvaStatus)provaAlunoStatusDto.Status;
                    if ((ProvaStatus)provaAlunoStatusDto.Status == ProvaStatus.Finalizado)
                        provaStatus.FinalizadoEm = provaAlunoStatusDto.DataFim != null && provaAlunoStatusDto.DataFim != 0 ? provaAlunoStatusDto.DataMenos3Horas(provaAlunoStatusDto.DataFim) : DateTime.Now;
                    provaStatus.TipoDispositivo = (TipoDispositivo)provaAlunoStatusDto.TipoDispositivo;

                    return await mediator.Send(new AtualizarProvaAlunoCommand(provaStatus));
                }
            }

            catch (Exception ex)
            {
                servicoLog.Registrar($"ProvaId = {provaId} -- AlunoRA = {alunoRa} Status {provaAlunoStatusDto.Status} -- DataInicio { provaAlunoStatusDto.DataInicio} -- DataFim, { provaAlunoStatusDto.DataFim} " +
                        $"Tipo Dispositivo = {provaAlunoStatusDto.TipoDispositivo} --  ", ex);
                throw;
            }
        }
    }
}

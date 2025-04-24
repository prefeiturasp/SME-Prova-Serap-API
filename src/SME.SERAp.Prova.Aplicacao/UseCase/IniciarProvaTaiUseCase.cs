using MediatR;
using SME.SERAp.Prova.Aplicacao.Commands;
using SME.SERAp.Prova.Aplicacao.Queries;
using SME.SERAp.Prova.Aplicacao.Queries.VerificaStatusProvaFinalizada;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.Aluno;
using SME.SERAp.Prova.Infra.Exceptions;
using SME.SERAp.Prova.Infra.Interfaces;
using System;
using System.Linq;
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

                var dataMenos3Horas = provaAlunoStatusDto.DataMenos3Horas(provaAlunoStatusDto.DataInicio);
                if (dataMenos3Horas != null)
                    dataInicio = (DateTime)dataMenos3Horas;


                if (provaStatus == null)
                {

                    var alunoDetalhes = await mediator.Send(new ObterAlunoDadosPorRaQuery(dadosAlunoLogado.Ra));

    
                    var existeCadernoAluno = await mediator.Send(new ExisteCadernoAlunoPorProvaIdAlunoIdQuery(provaId, alunoDetalhes.AlunoId));
                    var existeQuestaoAlunoTai = await mediator.Send(new ExisteQuestaoAlunoTaiPorAlunoIdQuery(provaId, alunoDetalhes.AlunoId));

                    if (!existeCadernoAluno)
                    {
                        await mediator.Send(new IncluirCadernoAlunoCommand(alunoDetalhes.AlunoId, provaId, "1"));
                    }

                    if (!existeQuestaoAlunoTai)
                    {
                        await IncluirPrimeiraQuestaoAlunoTai(provaId, alunoDetalhes.AlunoId, "1");

                        //-> Limpar o cache


                        await RemoverCaches(provaId, dadosAlunoLogado.Ra, alunoDetalhes.AlunoId);
                     


                    }



                    provaAlunoStatusDto.Status = (int)ProvaStatus.Iniciado;
                    return await IncluirProvaAluno(provaId, provaAlunoStatusDto, dataInicio);
                }

                var status = await mediator.Send(new VerificaStatusProvaFinalizadoQuery(provaStatus.Status))
                    ? "finalizada"
                    : "iniciada";

                throw new NegocioException($"Esta prova já foi {status}", 411);
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

            await PublicarAcompProvaAlunoInicioFimTratar(provaId, dadosAlunoLogado.Ra, provaAlunoStatusDto.Status, dataInicio, dataFim);

            return await mediator.Send(new IncluirProvaAlunoCommand(provaId,
                dadosAlunoLogado.Ra,
                (ProvaStatus)provaAlunoStatusDto.Status,
                dataInicio,
                dataFim,
                provaAlunoStatusDto.TipoDispositivo != null
                    ? (TipoDispositivo)provaAlunoStatusDto.TipoDispositivo
                    : TipoDispositivo.NaoCadastrado,
                dadosAlunoLogado.DispositivoId));
        }

        private async Task PublicarAcompProvaAlunoInicioFimTratar(long provaId, long alunoRa, int status, DateTime? criadoEm, DateTime? finalizadoEm)
        {
            var provaAlunoAcompDto = new ProvaAlunoAcompDto(provaId, alunoRa, status, criadoEm, finalizadoEm);
            await mediator.Send(new PublicarFilaSerapEstudanteAcompanhamentoCommand(RotasRabbit.AcompProvaAlunoInicioFimTratar, provaAlunoAcompDto));
        }




        private async Task IncluirPrimeiraQuestaoAlunoTai(long provaId, long alunoId, string caderno)
        {
            var idsQuestoes = (await mediator.Send(new ObterIdsQuestoesPorProvaIdCadernoQuery(provaId, caderno))).Distinct().ToList();
            var sortear = new Random();
            var questaoIdSorteada = idsQuestoes[sortear.Next(idsQuestoes.Count)];

            var questaoAlunoTai = new QuestaoAlunoTai(questaoIdSorteada, alunoId, 0);
            var questaoAlunoTaiId = await mediator.Send(new QuestaoAlunoTaiIncluirCommand(questaoAlunoTai));

            if (questaoAlunoTaiId <= 0)
                throw new NegocioException($"As questões TAI do aluno {alunoId} não foram inseridas.");
        }


        private async Task RemoverCaches(long provaId, long alunoRA, long alunoId)
        {
            await mediator.Send(new RemoverCacheCommand($"al-prova-{provaId}-{alunoRA}"));
            await mediator.Send(new RemoverCacheCommand($"al-q-administrado-tai-prova-{alunoId}-{provaId}"));
        }
        
    }
}

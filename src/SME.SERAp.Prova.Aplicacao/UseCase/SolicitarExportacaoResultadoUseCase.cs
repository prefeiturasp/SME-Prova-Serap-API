using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class SolicitarExportacaoResultadoUseCase : ISolicitarExportacaoResultadoUseCase
    {
        private readonly IMediator mediator;
        private ExportacaoResultado exportacaoResultado;

        public SolicitarExportacaoResultadoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(long provaSerapId)
        {            
            try
            {

                exportacaoResultado = await GerarObjExportacao(provaSerapId);

                var provaExtracao = await mediator.Send(new ObterProvaExtracaoPorLegadoIdQuery(provaSerapId));
                if (provaExtracao == null || provaExtracao?.ProvaSerapId == 0)
                    throw new NegocioException($"A prova informada não foi encontrada no serap estudantes, prova: {provaSerapId}.");
                
                await AtualizarStatusExportacao(ExportacaoResultadoStatus.Iniciado);

                provaExtracao.ExtracaoResultadoId = exportacaoResultado.Id;
                provaExtracao.Status = exportacaoResultado.Status;
                return await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.ExcluirDadosConsolidado, provaExtracao));
            }
            catch(Exception)
            {                
                await AtualizarStatusExportacao(ExportacaoResultadoStatus.Erro);
                throw;
            }
        }

        public async Task<ExportacaoResultado> GerarObjExportacao(long provaSerapId)
        {
            try
            {
                ExportacaoResultado exportacaoResultado = new ExportacaoResultado($"{Guid.NewGuid().ToString().ToUpper()}.csv", provaSerapId);
                exportacaoResultado.Id = await mediator.Send(new ExportacaoResultadoIncluirCommand(exportacaoResultado));
                return exportacaoResultado;
            }
            catch (Exception ex)
            {
                throw new NegocioException($"Erro ao gerar a exportação da prova: {provaSerapId}. Erro:{ex.Message}");
            }
        }

        private async Task AtualizarStatusExportacao(ExportacaoResultadoStatus status)
        {
            exportacaoResultado.AtualizarStatus(status);
            await mediator.Send(new ExportacaoResultadoAtualizarCommand(exportacaoResultado));
        }
    }
}

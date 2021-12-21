using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class SolicitarExportacaoResultadoUseCase : ISolicitarExportacaoResultadoUseCase
    {
        private readonly IMediator mediator;
        public SolicitarExportacaoResultadoUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Executar(long provaSerapId)
        {
            ExportacaoResultado exportacaoResultado = await GerarObjExportacao(provaSerapId);
            try
            {
                var checarProvaExiste = await mediator.Send(new VerificaProvaExistePorSerapIdQuery(provaSerapId));

                if (!checarProvaExiste)
                    throw new NegocioException($"A prova informada não foi encontrada no serap estudantes, prova: {provaSerapId}.");
                
                exportacaoResultado.AtualizarStatus(ExportacaoResultadoStatus.Iniciado);
                await mediator.Send(new ExportacaoResultadoAtualizarCommand(exportacaoResultado));

                var msgExtracao = new ProvaExtracaoDto() { ExtracaoResultadoId = exportacaoResultado.Id, ProvaSerapId = provaSerapId };
                return await mediator.Send(new PublicarFilaSerapEstudantesCommand(RotasRabbit.ConsolidarProvaResultado, msgExtracao));

            }
            catch(Exception)
            {
                exportacaoResultado.AtualizarStatus(ExportacaoResultadoStatus.Erro);
                await mediator.Send(new ExportacaoResultadoAtualizarCommand(exportacaoResultado));
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
    }
}

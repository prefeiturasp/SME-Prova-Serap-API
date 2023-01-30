using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class TratarImportacaoResultadoPspUseCase : AbstractUseCase, ITratarImportacaoResultadoPspUseCase
    {
        public TratarImportacaoResultadoPspUseCase(IMediator mediator) : base(mediator)
        {

        }

        public async Task<bool> Executar(long processoId, int tipoResultado)
        {
            try
            {
                if (processoId == 0 || tipoResultado == 0) return false;

                string fila = ObterFilaPorTipoResultadoPsp((TipoResultadoPsp)tipoResultado);
                if (string.IsNullOrEmpty(fila)) return false;

                await mediator.Send(new PublicarFilaSerapEstudantesCommand(fila, processoId));

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string ObterFilaPorTipoResultadoPsp(TipoResultadoPsp tipoResultado)
        {
            switch (tipoResultado)
            {
                case TipoResultadoPsp.ResultadoAluno:
                    return RotasRabbit.ImportarResultadoAlunoPsp;
                case TipoResultadoPsp.ResultadoSme:
                    return RotasRabbit.ImportarResultadoSmePsp;
                case TipoResultadoPsp.ResultadoDre:
                    return RotasRabbit.ImportarResultadoDrePsp;
                default:
                    return string.Empty;
            }
        }
    }
}

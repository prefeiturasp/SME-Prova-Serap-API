using MediatR;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
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
            if (processoId == 0 || tipoResultado == 0) 
                return false;

            var fila = ObterFilaPorTipoResultadoPsp((TipoResultadoPsp)tipoResultado);
            
            if (string.IsNullOrEmpty(fila)) 
                return false;

            await mediator.Send(new PublicarFilaSerapEstudantesCommand(fila, processoId));

            return true;
        }

        private static string ObterFilaPorTipoResultadoPsp(TipoResultadoPsp tipoResultado)
        {
            return tipoResultado switch
            {
                TipoResultadoPsp.ResultadoAluno => RotasRabbit.ImportarResultadoAlunoPsp,
                TipoResultadoPsp.ResultadoSme => RotasRabbit.ImportarResultadoSmePsp,
                TipoResultadoPsp.ResultadoDre => RotasRabbit.ImportarResultadoDrePsp,
                TipoResultadoPsp.ResultadoEscola => RotasRabbit.ImportarResultadoEscolaPsp,
                TipoResultadoPsp.ResultadoTurma => RotasRabbit.ImportarResultadoTurmaPsp,
                TipoResultadoPsp.ResultadoParticipacaoTurma => RotasRabbit.ImportarResultadoParticipacaoTurma,
                TipoResultadoPsp.ParticipacaoTurmaAreaConhecimento => RotasRabbit.ImportarParticipacaoTurmaAreaConhecimento,
                TipoResultadoPsp.ResultadoParticipacaoUe => RotasRabbit.ImportarResultadoParticipacaoUe,
                TipoResultadoPsp.ParticipacaoUeAreaConhecimento => RotasRabbit.ImportarParticipacaoUeAreaConhecimento,
                TipoResultadoPsp.ParticipacaoDre => RotasRabbit.ImportarResultadoParticipacaoDre,
                TipoResultadoPsp.ParticipacaoDreAreaConhecimento => RotasRabbit.ImportarResultadoParticipacaoDreAreaConhecimento,
                TipoResultadoPsp.ParticipacaoSme => RotasRabbit.ImportarResultadoParticipacaoSme,
                TipoResultadoPsp.ParticipacaoSmeAreaConhecimento => RotasRabbit.ImportarResultadoParticipacaoSmeAreaConhecimento,
                TipoResultadoPsp.ResultadoSmeCiclo => RotasRabbit.ImportarResultadoSmeCiclo,
                _ => string.Empty
            };
        }
    }
}

using Hangfire;
using SME.Background.Core;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Dominio;

namespace SME.SGP.Background
{
    public static class RegistraServicosRecorrentes
    {
        public static void Registrar()
        {            
            Cliente.ExecutarPeriodicamente<IIniciarProcessoFinalizarProvasAutomaticamenteUseCase>(c => c.Executar(), Cron.Daily(13));
            Cliente.ExecutarPeriodicamente<IIniciarProcessoFinalizarProvasAutomaticamenteUseCase>(c => c.Executar(), Cron.Daily(19));
            Cliente.ExecutarPeriodicamente<IIniciarProcessoFinalizarProvasAutomaticamenteUseCase>(c => c.Executar(), Cron.Daily(23));
        }
    }
}

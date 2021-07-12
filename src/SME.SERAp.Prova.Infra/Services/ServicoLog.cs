using Microsoft.ApplicationInsights;
using Sentry;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using SME.SERAp.Prova.Infra.Interfaces;
using System;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Infra.Services
{
    public class ServicoLog : IServicoLog
    {
        private readonly LogOptions logOptions;
        private readonly TelemetryClient insightsClient;

        public ServicoLog(LogOptions logOptions, TelemetryClient insightsClient)
        {
            this.logOptions = logOptions ?? throw new ArgumentNullException(nameof(logOptions));
            this.insightsClient = insightsClient ?? throw new ArgumentNullException(nameof(insightsClient));
        }

        public void Registrar(string mensagem)
        {
            using (SentrySdk.Init(logOptions.SentryDSN))
            {
                SentrySdk.CaptureMessage(mensagem);
            }
        }

        public void Registrar(Exception ex)
        {
            using (SentrySdk.Init(logOptions.SentryDSN))
            {
                SentrySdk.CaptureException(ex);
            }
        }

        public void RegistrarAppInsights(string evento, string mensagem)
        {
            insightsClient.TrackEvent(evento,
                new Dictionary<string, string>()
                          {
                             { DateTime.Now.ToLongDateString(), mensagem }
                         });
        }

        public void RegistrarDependenciaAppInsights(string tipoDependencia, string alvo, string mensagem, DateTimeOffset inicio, TimeSpan duracao, bool sucesso)
        {
            insightsClient.TrackDependency(tipoDependencia, alvo, mensagem, inicio, duracao, sucesso);
        }
    }
}

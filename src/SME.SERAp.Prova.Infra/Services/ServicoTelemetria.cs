﻿    using Elastic.Apm;
    using Microsoft.ApplicationInsights;
    using SME.SERAp.Prova.Infra.EnvironmentVariables;
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    namespace SME.SERAp.Prova.Infra
    {
        public class ServicoTelemetria : IServicoTelemetria
        {
            private readonly TelemetryClient insightsClient;
            private readonly TelemetriaOptions telemetriaOptions;

            public ServicoTelemetria(TelemetryClient insightsClient, TelemetriaOptions telemetriaOptions)
            {
                this.insightsClient = insightsClient;
                this.telemetriaOptions = telemetriaOptions ?? throw new ArgumentNullException(nameof(telemetriaOptions));
            }

            public async Task<dynamic> RegistrarComRetornoAsync<T>(Func<Task<object>> acao, string acaoNome, string telemetriaNome, string telemetriaValor)
            {
                DateTime inicioOperacao = default;
                Stopwatch temporizador = default;

                dynamic result = default;

                if (telemetriaOptions.ApplicationInsights)
                {
                    inicioOperacao = DateTime.UtcNow;
                    temporizador = Stopwatch.StartNew();
                }

                if (telemetriaOptions.Apm)
                {
                    Stopwatch temporizadorApm = Stopwatch.StartNew();
                    result = await acao() as dynamic;
                    temporizadorApm.Stop();

                    Agent.Tracer.CurrentTransaction.CaptureSpan(telemetriaNome, acaoNome, async (span) =>
                    {
                        span.SetLabel(telemetriaNome, telemetriaValor);
                        span.Duration = temporizadorApm.Elapsed.TotalMilliseconds;
                    });
                }
                else
                {
                    result = await acao() as dynamic;
                }

                if (telemetriaOptions.ApplicationInsights)
                {
                    temporizador.Stop();

                    insightsClient?.TrackDependency(acaoNome, telemetriaNome, telemetriaValor, inicioOperacao, temporizador.Elapsed, true);
                }

                return result;
            }

            public dynamic RegistrarComRetorno<T>(Func<object> acao, string acaoNome, string telemetriaNome, string telemetriaValor)
            {
                DateTime inicioOperacao = default;
                Stopwatch temporizador = default;

                dynamic result = default;

                if (telemetriaOptions.ApplicationInsights)
                {
                    inicioOperacao = DateTime.UtcNow;
                    temporizador = Stopwatch.StartNew();
                }

                if (telemetriaOptions.Apm)
                {
                    var transactionElk = Agent.Tracer.CurrentTransaction;

                    transactionElk.CaptureSpan(telemetriaNome, acaoNome, (span) =>
                    {
                        span.SetLabel(telemetriaNome, telemetriaValor);
                        result = acao();
                    });
                }
                else
                {
                    result = acao();
                }

                if (telemetriaOptions.ApplicationInsights)
                {
                    temporizador.Stop();

                    insightsClient?.TrackDependency(acaoNome, telemetriaNome, telemetriaValor, inicioOperacao, temporizador.Elapsed, true);
                }

                return result;
            }

            public void Registrar(Action acao, string acaoNome, string telemetriaNome, string telemetriaValor)
            {
                DateTime inicioOperacao = default;
                Stopwatch temporizador = default;

                if (telemetriaOptions.ApplicationInsights)
                {
                    inicioOperacao = DateTime.UtcNow;
                    temporizador = Stopwatch.StartNew();
                }

                if (telemetriaOptions.Apm)
                {
                    var transactionElk = Agent.Tracer.CurrentTransaction;

                    transactionElk.CaptureSpan(telemetriaNome, acaoNome, (span) =>
                    {
                        span.SetLabel(telemetriaNome, telemetriaValor);
                        acao();
                    });
                }
                else
                {
                    acao();
                }

                if (telemetriaOptions.ApplicationInsights)
                {
                    temporizador.Stop();
                    insightsClient?.TrackDependency(acaoNome, telemetriaNome, telemetriaValor, inicioOperacao, temporizador.Elapsed, true);
                }
            }

            public async Task RegistrarAsync(Func<Task> acao, string acaoNome, string telemetriaNome, string telemetriaValor)
            {
                DateTime inicioOperacao = default;
                Stopwatch temporizador = default;

                if (telemetriaOptions.ApplicationInsights)
                {
                    inicioOperacao = DateTime.UtcNow;
                    temporizador = Stopwatch.StartNew();
                }

                if (telemetriaOptions.Apm)
                {
                    var transactionElk = Agent.Tracer.CurrentTransaction;

                    await transactionElk.CaptureSpan(telemetriaNome, acaoNome, async (span) =>
                    {
                        span.SetLabel(telemetriaNome, telemetriaValor);
                        await acao();
                    });
                }
                else
                {
                    await acao();
                }

                if (telemetriaOptions.ApplicationInsights)
                {
                    temporizador.Stop();
                    insightsClient?.TrackDependency(acaoNome, telemetriaNome, telemetriaValor, inicioOperacao, temporizador.Elapsed, true);
                }
            }
        }
    }

using Microsoft.AspNetCore.Mvc.Filters;
using Sentry;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace SME.SERAp.Prova.Api.Middlewares
{
    public class FiltroExcecoesAttribute : ExceptionFilterAttribute
    {
        private readonly SentryOptions sentryOptions;

        public FiltroExcecoesAttribute(SentryOptions sentryOptions)
        {
            this.sentryOptions = sentryOptions ?? throw new ArgumentNullException(nameof(sentryOptions));
        }

        public override void OnException(ExceptionContext context)
        {
            using (SentrySdk.Init(sentryOptions))
            {
                var internalIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList?.Where(c => c.AddressFamily == AddressFamily.InterNetwork).ToString();
                SentrySdk.AddBreadcrumb($"{Environment.MachineName ?? string.Empty} - {internalIP ?? string.Empty }", "Machine Identification");

                SentrySdk.CaptureException(context.Exception);                
            }

            context.Result = context.Exception switch
            {
                NegocioException negocioException => new ResultadoBaseResult(context.Exception.Message, negocioException.StatusCode),
                ValidacaoException validacaoException => new ResultadoBaseResult(new RetornoBaseDto(validacaoException.Erros)),
                NaoAutorizadoException naoAutorizadoException => new ResultadoBaseResult(context.Exception.Message, naoAutorizadoException.StatusCode),
                _ => new ResultadoBaseResult("Ocorreu um erro interno. Favor contatar o suporte.", 500),
            };
            base.OnException(context);
        }
    }
}
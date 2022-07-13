using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using SME.SERAp.Prova.Infra.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Middlewares
{
    public class FiltroExcecoesAttribute : ExceptionFilterAttribute
    {
        private readonly IMediator mediator;
        private readonly IServicoLog servicoLog;
        public FiltroExcecoesAttribute(IMediator mediator, IServicoLog servicoLog)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.servicoLog = servicoLog ?? throw new ArgumentNullException(nameof(servicoLog));

        }

        public override void OnException(ExceptionContext context)
        {
            var internalIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList?.Where(c => c.AddressFamily == AddressFamily.InterNetwork).ToString();

            switch (context.Exception)
            {
                case NegocioException negocioException:
                    servicoLog.Registrar(LogNivel.Negocio, context.Exception.Message, internalIP, context.Exception.StackTrace);
                    context.Result = new ResultadoBaseResult(context.Exception.Message, negocioException.StatusCode);
                    break;
                case ValidacaoException validacaoException:
                    servicoLog.Registrar(LogNivel.Negocio, context.Exception.Message, internalIP, context.Exception.StackTrace);
                    context.Result = new ResultadoBaseResult(new RetornoBaseDto(validacaoException.Erros));
                    break;
                default:
                    servicoLog.Registrar(LogNivel.Critico, context.Exception.Message, internalIP, context.Exception.StackTrace);
                    context.Result = new ResultadoBaseResult("Ocorreu um erro interno. Favor contatar o suporte.", 500);
                    break;
            }

            base.OnException(context);
        }
        public async Task SalvaLogAsync(LogNivel nivel, string erro, string observacoes, string stackTrace)
        {
            await mediator.Send(new SalvarLogViaRabbitCommand(erro, nivel, observacoes, rastreamento: stackTrace));
        }
    }
}
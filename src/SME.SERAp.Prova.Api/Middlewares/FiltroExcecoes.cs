using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Middlewares
{
    public class FiltroExcecoesAttribute : ExceptionFilterAttribute
    {
            private readonly IMediator mediator;

            public FiltroExcecoesAttribute(IMediator mediator)
            {
                this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            }

            public override async void OnException(ExceptionContext context)
            {
                var internalIP = "";

                switch (context.Exception)
                {
                    case NegocioException negocioException:
                        await SalvaLogAsync(LogNivel.Negocio, context.Exception.Message, internalIP, context.Exception.StackTrace);
                        context.Result = new ResultadoBaseResult(context.Exception.Message, negocioException.StatusCode);
                        break;
                    case ValidacaoException validacaoException:
                        await SalvaLogAsync(LogNivel.Negocio, context.Exception.Message, internalIP, context.Exception.StackTrace);
                        context.Result = new ResultadoBaseResult(new RetornoBaseDto(validacaoException.Erros));
                        break;
                    default:
                        await SalvaLogAsync(LogNivel.Critico, context.Exception.Message, internalIP, context.Exception.StackTrace);
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
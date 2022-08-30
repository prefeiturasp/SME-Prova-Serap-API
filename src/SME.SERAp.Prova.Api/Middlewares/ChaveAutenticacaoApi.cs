using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Api.Middlewares
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ChaveAutenticacaoApi : Attribute, IAsyncActionFilter
    {
        private const string ChaveHeader = "chave-api";
        private const string ChaveEnvironmentVariableName = "ChaveSerapProvaApi";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
#if !DEBUG
            string chaveApi = Environment.GetEnvironmentVariable(ChaveEnvironmentVariableName);
            if (!context.HttpContext.Request.Headers.TryGetValue(ChaveHeader, out var chaveRecebida) || !chaveRecebida.Equals(chaveApi))
            {
                context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
                return;
            }
#endif
            await next();
        }
    }
}

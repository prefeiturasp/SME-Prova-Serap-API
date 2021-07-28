using Microsoft.AspNetCore.Mvc;
using SME.SERAp.Prova.Infra;

namespace SME.SERAp.Prova.Api
{
    public class ResultadoBaseResult : ObjectResult
    {
        public ResultadoBaseResult(string mensagem)
            : base(RetornaBaseModel(mensagem))
        {
            StatusCode = 409;
        }

        public ResultadoBaseResult(RetornoBaseDto retornoBaseDto) : base(retornoBaseDto)
        {
            StatusCode = 409;
        }
        public ResultadoBaseResult(string mensagem, int statusCode)
            : base(RetornaBaseModel(mensagem))
        {
            StatusCode = statusCode;
        }

        public static RetornoBaseDto RetornaBaseModel(string mensagem)
        {
            return new RetornoBaseDto(mensagem);
        }
    }
}

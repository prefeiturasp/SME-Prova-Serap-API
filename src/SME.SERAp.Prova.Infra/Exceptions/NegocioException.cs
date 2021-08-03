using System;
using System.Net;

namespace SME.SERAp.Prova.Infra.Exceptions
{
    [Serializable()]
    public class NegocioException : Exception
    {
        public NegocioException(string mensagem, int statusCode = 409) : base(mensagem)
        {
            StatusCode = statusCode;
        }

        public NegocioException(string mensagem, HttpStatusCode statusCode) : base(mensagem)
        {
            StatusCode = (int)statusCode;
        }

        public int StatusCode { get; }
    }
}

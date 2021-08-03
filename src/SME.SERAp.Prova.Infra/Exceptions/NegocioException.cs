using System;
using System.Net;
using System.Runtime.Serialization;

namespace SME.SERAp.Prova.Infra.Exceptions
{
    public class NegocioException : Exception, ISerializable
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

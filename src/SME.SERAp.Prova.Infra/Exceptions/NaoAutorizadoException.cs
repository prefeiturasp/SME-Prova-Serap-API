using System;
using System.Net;
using System.Runtime.Serialization;

namespace SME.SERAp.Prova.Infra.Exceptions
{
    public class NaoAutorizadoException : Exception, ISerializable
    {
        public NaoAutorizadoException(string mensagem, int statusCode = 401) : base(mensagem)
        {
            StatusCode = statusCode;
        }

        public NaoAutorizadoException(string mensagem, HttpStatusCode statusCode) : base(mensagem)
        {
            StatusCode = (int)statusCode;
        }

        public int StatusCode { get; }        
    }
}

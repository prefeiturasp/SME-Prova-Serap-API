using MediatR;
using SME.SERAp.Prova.Infra;
using System;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterCodigoValidacaoAdmQuery : IRequest<AutenticacaoUsuarioAdmDto>
    {
        public ObterCodigoValidacaoAdmQuery(string codigo)
        {
            Codigo = codigo;
        }

        public string Codigo { get; set; }
    }
}

using MediatR;
using System.Globalization;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class VerificaAutenticacaoUsuarioQueryHandler : IRequestHandler<VerificaAutenticacaoUsuarioQuery, bool>
    {
        public Task<bool> Handle(VerificaAutenticacaoUsuarioQuery request, CancellationToken cancellationToken)
        {
            bool estaAutenticado = ValidaRegraSenha(request);

            return Task.FromResult(estaAutenticado);
        }

        private static bool ValidaRegraSenha(VerificaAutenticacaoUsuarioQuery request)
        {
            try
            {
                var raString = request.AlunoRA.ToString();
                var nascimentoSerap = request.DataNascimento.Date;

                DateTime senhaInformada = DateTime.ParseExact(request.Senha, "ddMMyy", CultureInfo.InvariantCulture);
                if (nascimentoSerap == senhaInformada)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

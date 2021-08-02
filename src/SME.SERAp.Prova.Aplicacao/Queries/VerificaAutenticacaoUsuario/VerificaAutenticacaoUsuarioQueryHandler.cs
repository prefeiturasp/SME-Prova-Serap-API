using MediatR;
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
            var raString = request.AlunoRA.ToString();
            var senhaAtual = raString[^4..];

            if (senhaAtual == request.Senha)
                return true;

            return false;
        }
    }
}

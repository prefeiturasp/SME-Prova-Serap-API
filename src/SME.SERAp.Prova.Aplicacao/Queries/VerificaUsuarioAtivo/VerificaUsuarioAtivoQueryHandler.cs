using MediatR;
using SME.SERAp.Prova.Dados;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class VerificaUsuarioAtivoQueryHandler : IRequestHandler<VerificaUsuarioAtivoQuery, bool>
    {
        private readonly IRepositorioAluno repositorioAluno;

        public VerificaUsuarioAtivoQueryHandler(IRepositorioAluno repositorioAluno)
        {
            this.repositorioAluno = repositorioAluno ?? throw new System.ArgumentNullException(nameof(repositorioAluno));
        }
        public async Task<bool> Handle(VerificaUsuarioAtivoQuery request, CancellationToken cancellationToken)
        {
            var aluno = await repositorioAluno.ObterAlunoAtivoAsync(request.AlunoRA);
            
            return (aluno != null && aluno.CodigoAluno > 0);
        }      
    }
}

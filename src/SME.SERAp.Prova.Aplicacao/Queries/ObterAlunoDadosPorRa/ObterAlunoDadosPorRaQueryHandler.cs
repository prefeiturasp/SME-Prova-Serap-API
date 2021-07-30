using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlunoDadosPorRaQueryHandler : IRequestHandler<ObterAlunoDadosPorRaQuery, AlunoEol>
    {
        private readonly IRepositorioAluno repositorioAluno;

        public ObterAlunoDadosPorRaQueryHandler(IRepositorioAluno repositorioAluno)
        {
            this.repositorioAluno = repositorioAluno ?? throw new System.ArgumentNullException(nameof(repositorioAluno));
        }
        public async Task<AlunoEol> Handle(ObterAlunoDadosPorRaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAluno.ObterAlunoDetalhePorRa(request.AlunoRa);
        }
    }
}

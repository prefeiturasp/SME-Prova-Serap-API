using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlunoDadosPorRaQueryHandler : IRequestHandler<ObterAlunoDadosPorRaQuery, AlunoDetalheDto>
    {
        private readonly IRepositorioAluno repositorioAluno;
        public ObterAlunoDadosPorRaQueryHandler(IRepositorioAluno repositorioAluno)
        {
            this.repositorioAluno = repositorioAluno ?? throw new System.ArgumentNullException(nameof(repositorioAluno));
        }

        public async Task<AlunoDetalheDto> Handle(ObterAlunoDadosPorRaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAluno.ObterAlunoDetalhePorRa(request.AlunoRa);
        }
    }
}

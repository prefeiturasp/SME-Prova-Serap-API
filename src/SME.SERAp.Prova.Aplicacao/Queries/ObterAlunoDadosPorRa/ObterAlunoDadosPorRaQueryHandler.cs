using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlunoDadosPorRaQueryHandler : IRequestHandler<ObterAlunoDadosPorRaQuery, AlunoEol>
    {
        private readonly IRepositorioAlunoEol repositorioAlunoEol;

        public ObterAlunoDadosPorRaQueryHandler(IRepositorioAlunoEol repositorioAlunoEol)
        {
            this.repositorioAlunoEol = repositorioAlunoEol ?? throw new System.ArgumentNullException(nameof(repositorioAlunoEol));
        }
        public async Task<AlunoEol> Handle(ObterAlunoDadosPorRaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAlunoEol.ObterAlunoDetalhePorRa(request.AlunoRa);
        }
    }
}

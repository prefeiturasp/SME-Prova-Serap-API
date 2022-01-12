using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterTurmasAlunoPorRaQueryHandler : IRequestHandler<ObterTurmasAlunoPorRaQuery, IEnumerable<Turma>>
    {

        private readonly IRepositorioTurma repositorioTurma;

        public ObterTurmasAlunoPorRaQueryHandler(IRepositorioTurma repositorioTurma)
        {
            this.repositorioTurma = repositorioTurma ?? throw new System.ArgumentNullException(nameof(repositorioTurma));
        }

        public async Task<IEnumerable<Turma>> Handle(ObterTurmasAlunoPorRaQuery request, CancellationToken cancellationToken)
        {
            return await repositorioTurma.ObterTurmasAlunoPorRaAsync(request.AlunoRa);
        }
    }
}

using MediatR;
using SME.SERAp.Prova.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.Queries
{
    public class ExisteQuestaoAlunoTaiPorAlunoIdQueryHandler : IRequestHandler<ExisteQuestaoAlunoTaiPorAlunoIdQuery, bool>
    {
        private readonly IRepositorioQuestaoAlunoTai repositorioQuestaoAlunoTai;

        public ExisteQuestaoAlunoTaiPorAlunoIdQueryHandler(IRepositorioQuestaoAlunoTai repositorioQuestaoAlunoTai)
        {
            this.repositorioQuestaoAlunoTai = repositorioQuestaoAlunoTai ?? throw new ArgumentNullException(nameof(repositorioQuestaoAlunoTai));
        }

        public async Task<bool> Handle(ExisteQuestaoAlunoTaiPorAlunoIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioQuestaoAlunoTai.ExisteQuestaoAlunoTaiPorAlunoId(request.ProvaId, request.AlunoId);
        }
    }
}

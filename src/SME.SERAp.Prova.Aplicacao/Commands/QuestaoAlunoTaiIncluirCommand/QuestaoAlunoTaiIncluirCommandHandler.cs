using MediatR;
using SME.SERAp.Prova.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao.Commands
{

    public class QuestaoAlunoTaiIncluirCommandHandler : IRequestHandler<QuestaoAlunoTaiIncluirCommand, long>
    {
        private readonly IRepositorioQuestaoAlunoTai repositorioQuestaoAlunoTai;

        public QuestaoAlunoTaiIncluirCommandHandler(IRepositorioQuestaoAlunoTai repositorioQuestaoAlunoTai)
        {
            this.repositorioQuestaoAlunoTai = repositorioQuestaoAlunoTai ?? throw new ArgumentNullException(nameof(repositorioQuestaoAlunoTai));
        }

        public async Task<long> Handle(QuestaoAlunoTaiIncluirCommand request, CancellationToken cancellationToken)
        {
            return await repositorioQuestaoAlunoTai.IncluirAsync(request.QuestaoAlunoTai);
        }
    }
}


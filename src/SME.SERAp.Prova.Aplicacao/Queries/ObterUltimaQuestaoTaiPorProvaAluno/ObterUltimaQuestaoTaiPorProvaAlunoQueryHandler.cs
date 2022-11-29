using MediatR;
using SME.SERAp.Prova.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterUltimaQuestaoTaiPorProvaAlunoQueryHander : IRequestHandler<ObterUltimaQuestaoTaiPorProvaAlunoQuery, long>
    {
        private readonly IRepositorioQuestao repositorioQuestao;

        public ObterUltimaQuestaoTaiPorProvaAlunoQueryHander(IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioQuestao = repositorioQuestao ?? throw new ArgumentNullException(nameof(repositorioQuestao));
        }

        public async Task<long> Handle(ObterUltimaQuestaoTaiPorProvaAlunoQuery request, CancellationToken cancellationToken)
        {
            return await repositorioQuestao.ObterUltimaQuestaoTaiPorProvaAlunoRa(request.ProvaId, request.AlunoRa);
        }
    }
}

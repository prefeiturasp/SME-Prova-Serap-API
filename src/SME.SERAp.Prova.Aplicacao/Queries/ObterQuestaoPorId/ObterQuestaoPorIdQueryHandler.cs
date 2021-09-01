using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterQuestaoPorIdQueryHandler : IRequestHandler<ObterQuestaoPorIdQuery, Questao>
    {
        private readonly IRepositorioQuestao repositorioQuestao;

        public ObterQuestaoPorIdQueryHandler(IRepositorioQuestao repositorioQuestao)
        {
            this.repositorioQuestao = repositorioQuestao ?? throw new System.ArgumentNullException(nameof(repositorioQuestao));
        }
        public async Task<Questao> Handle(ObterQuestaoPorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioQuestao.ObterPorIdAsync(request.Id);
        }
    }
}

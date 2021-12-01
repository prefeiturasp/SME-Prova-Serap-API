using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dados.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirQuestaoAlunoRespostaCacheCommandHandler : IRequestHandler<IncluirQuestaoAlunoRespostaCacheCommand, bool>
    {
        private readonly IRepositorioCache repositorioCache;

        public IncluirQuestaoAlunoRespostaCacheCommandHandler(IRepositorioCache repositorioCache)
        {
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
        }
        public async Task<bool> Handle(IncluirQuestaoAlunoRespostaCacheCommand request, CancellationToken cancellationToken)
        {
            await repositorioCache.SalvarRedisAsync($"qar-{request.Dto.AlunoRa}", request.Dto);
            return true;
        }
    }
}

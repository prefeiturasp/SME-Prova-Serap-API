using MediatR;
using SME.SERAp.Prova.Dados;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterArquivosAudiosIdsPorQuestaoIdQueryHandler : IRequestHandler<ObterArquivosAudiosIdsPorQuestaoIdQuery, long[]>
    {
        
        private readonly IRepositorioArquivo repositorioArquivo;

        public ObterArquivosAudiosIdsPorQuestaoIdQueryHandler(IRepositorioArquivo repositorioArquivo)
        {
            this.repositorioArquivo = repositorioArquivo ?? throw new System.ArgumentNullException(nameof(repositorioArquivo));
        }

        public async Task<long[]> Handle(ObterArquivosAudiosIdsPorQuestaoIdQuery request, CancellationToken cancellationToken)
        {
            var arquivos = await repositorioArquivo.ObterArquivosAudioPorQuestaoIdAsync(request.QuestaoId);
            if (arquivos != null)
                return arquivos.Select(a => a.Id).ToArray();
            return default;
        }
    }
}

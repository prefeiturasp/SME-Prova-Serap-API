using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirCadernoAlunoCommandHandler : IRequestHandler<IncluirCadernoAlunoCommand, bool>
    {
        private readonly IRepositorioCadernoAluno repositorioCadernoAluno;
        private readonly IRepositorioCache repositorioCache;

        public IncluirCadernoAlunoCommandHandler(IRepositorioCadernoAluno repositorioCadernoAluno, IRepositorioCache repositorioCache)
        {
            this.repositorioCadernoAluno = repositorioCadernoAluno ?? throw new System.ArgumentNullException(nameof(repositorioCadernoAluno));
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
        }

        public async Task<bool> Handle(IncluirCadernoAlunoCommand request, CancellationToken cancellationToken)
        {
            var id = await repositorioCadernoAluno.IncluirAsync(new Dominio.CadernoAluno(request.AlunoId, request.ProvaId, request.Caderno));

            if(id > 0)
            {
                await repositorioCache.SalvarRedisAsync(string.Format(CacheChave.AlunoCadernoProva, request.ProvaId, request.Ra), request.Caderno);
                return true;
            }

            return false;
        }
    }
}

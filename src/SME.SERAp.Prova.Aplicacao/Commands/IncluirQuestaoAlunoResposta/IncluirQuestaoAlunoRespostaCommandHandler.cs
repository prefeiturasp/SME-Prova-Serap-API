using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class IncluirQuestaoAlunoRespostaCommandHandler : IRequestHandler<IncluirQuestaoAlunoRespostaCommand, bool>
    {
        private readonly IRepositorioQuestaoAlunoResposta repositorioQuestaoAlunoResposta;

        public IncluirQuestaoAlunoRespostaCommandHandler(IRepositorioQuestaoAlunoResposta repositorioQuestaoAlunoResposta)
        {
            this.repositorioQuestaoAlunoResposta = repositorioQuestaoAlunoResposta ?? throw new System.ArgumentNullException(nameof(repositorioQuestaoAlunoResposta));
        }
        public async Task<bool> Handle(IncluirQuestaoAlunoRespostaCommand request, CancellationToken cancellationToken)
        {
            var entidade = new QuestaoAlunoResposta(request.QuestaoId, request.AlunoRa, request.AlternativaId, request.Resposta, request.CriadoEm, request.TempoRespostaAluno, 1);
            
            return await repositorioQuestaoAlunoResposta.SalvarAsync(entidade) > 0;            
        }
    }
}

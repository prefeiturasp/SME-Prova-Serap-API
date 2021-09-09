using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioQuestaoAlunoResposta : RepositorioBase<QuestaoAlunoResposta>, IRepositorioQuestaoAlunoResposta
    {
        public RepositorioQuestaoAlunoResposta(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }
    }
}

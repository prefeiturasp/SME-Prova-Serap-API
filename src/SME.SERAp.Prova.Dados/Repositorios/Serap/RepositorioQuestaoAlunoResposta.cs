using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioQuestaoAlunoResposta : RepositorioBase<QuestaoAlunoResposta>, IRepositorioQuestaoAlunoResposta
    {
        public RepositorioQuestaoAlunoResposta(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }

        public async Task<QuestaoAlunoResposta> ObterPorIdRaAsync(long questaoId, long alunoRa)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"select * from questao_aluno_resposta 
                        where questao_id = @questaoId and 
                        aluno_ra = @alunoRa";

                return await conn.QueryFirstOrDefaultAsync<QuestaoAlunoResposta>(query, new { questaoId, alunoRa });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

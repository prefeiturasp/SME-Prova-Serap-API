using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.Dtos.Questao;
using SME.SERAp.Prova.Infra.EnvironmentVariables;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioQuestaoAlunoTai : RepositorioBase<QuestaoAlunoTai>, IRepositorioQuestaoAlunoTai
    {
        public RepositorioQuestaoAlunoTai(ConnectionStringOptions connectionStrings) : base(connectionStrings)
        {
        }

        public async Task<IEnumerable<QuestaoTaiDto>> ObterQuestoesTaiPorProvaAlunoAsync(long provaId, long alunoId)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                const string query = @"select qat.questao_id as id,
                                            qat.ordem,
                                            qt.discriminacao, 
                                            qt.dificuldade as ProporcaoAcertos, 
                                            qt.acerto_casual as AcertoCasual,
                                            q.eixo_legado_id as EixoId,
                                            q.habilidade_legado_id as HabilidadeId
                                        from questao_aluno_tai qat
                                        join questao q on q.id = qat.questao_id
                                        left join questao_tri qt on qt.questao_id = q.id
                                        where qat.aluno_id = @alunoId 
                                        and q.prova_id = @provaId";

                return await conn.QueryAsync<QuestaoTaiDto>(query, new { alunoId, provaId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<bool> ExisteQuestaoAlunoTaiPorAlunoId(long provaId, long alunoId)
        {
            using var conn = ObterConexao();
            try
            {
                const string query = @"SELECT CASE WHEN EXISTS ( SELECT 1 FROM questao_aluno_tai qat join questao q on qat.questao_id = q.id WHERE aluno_id = @alunoId and q.prova_id = @provaId) THEN 1 ELSE 0 END";

                return await conn.ExecuteScalarAsync<bool>(query, new { alunoId, provaId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
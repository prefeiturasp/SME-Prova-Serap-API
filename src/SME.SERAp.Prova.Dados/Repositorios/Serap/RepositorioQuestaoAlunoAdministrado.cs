using System.Collections.Generic;
using System.Threading.Tasks;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.Dtos.Questao;
using SME.SERAp.Prova.Infra.EnvironmentVariables;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioQuestaoAlunoAdministrado : RepositorioBase<QuestaoAlunoAdministrado>, IRepositorioQuestaoAlunoAdministrado
    {
        public RepositorioQuestaoAlunoAdministrado(ConnectionStringOptions connectionStrings) : base(connectionStrings)
        {
        }

        public async Task<IEnumerable<QuestaoTaiDto>> ObterQuestoesTaiAdministradoPorProvaAlunoAsync(long provaId, long alunoId)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                const string query = @"select qaa.questao_id as id,
                                            qaa.ordem,
                                            qt.discriminacao, 
                                            qt.dificuldade as ProporcaoAcertos, 
                                            qt.acerto_casual as AcertoCasual
                                        from questao_aluno_administrado qaa
                                        join questao q on q.id = qaa.questao_id
                                        left join questao_tri qt on qt.questao_id = q.id
                                        where qaa.aluno_id = @alunoId 
                                        and q.prova_id = @provaId";

                return await conn.QueryAsync<QuestaoTaiDto>(query, new { alunoId, provaId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
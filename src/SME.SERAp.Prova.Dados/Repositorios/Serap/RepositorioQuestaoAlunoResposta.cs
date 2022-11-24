using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Collections.Generic;
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
            using var conn = ObterConexaoLeitura();
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

        public async Task<IEnumerable<QuestaoAlunoResposta>> ObterPorProvaIdERaAsync(long provaId, long alunoRa)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select qar.questao_id, qar.alternativa_id, qar.criado_em
                              from questao_aluno_resposta qar
                              left join questao q on qar.questao_id = q.id
                              where q.prova_id = @provaId 
                                and qar.aluno_ra = @alunoRa";

                return await conn.QueryAsync<QuestaoAlunoResposta>(query, new { provaId, alunoRa });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<QuestaoCompletaResultadoDto> ObterResultadoQuestaoAsync(long alunoRa, long provaId, long questaoLegadoId)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select distinct
                                     a.ordem as OrdemAlternativaCorreta,
                                     a2.ordem as OrdemAlternativaResposta,
                                     qar.resposta as RespostaConstruida
                             from questao q
                             left join alternativa a on a.questao_id = q.id and a.correta
                             left join questao_aluno_resposta qar on qar.questao_id = q.id
                             left join alternativa a2 on a2.id = qar.alternativa_id
                             where q.prova_id = @provaId
                               and q.questao_legado_id = @questaoLegadoId
                               and qar.aluno_ra = @alunoRa";

                return await conn.QueryFirstOrDefaultAsync<QuestaoCompletaResultadoDto>(query, new { alunoRa, provaId, questaoLegadoId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

    }
}

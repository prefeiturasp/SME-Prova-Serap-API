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
                                     a.id as AlternativaCorretaId,
                                     qar.alternativa_id as AlternativaRespostaId,
                                     qar.resposta as RespostaConstruida
                             from questao q
                             left join questao_aluno_resposta qar on qar.questao_id = q.id
                             left join alternativa a on a.questao_id = q.id and a.correta
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

        public async Task<IEnumerable<QuestaoAlternativaAlunoRespostaDto>> QuestaoAlternativaAlunoRespostaTaiAsync(long alunoRa, long provaId)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select q.id as questaoId, 
 	                                 al.id as alternativaCorreta, 
	                                 qar.alternativa_id as alternativaRespondida
                              from questao q
                              left join caderno_aluno ca on ca.prova_id = q.prova_id and ca.caderno = q.caderno 
                              left join aluno a on a.id = ca.aluno_id 
                              left join alternativa al on al.questao_id = q.id and al.correta 
                              left join questao_aluno_resposta qar on qar.questao_id = q.id and qar.aluno_ra = a.ra
                              where q.prova_id = @provaId and a.ra = @alunoRa";

                return await conn.QueryAsync<QuestaoAlternativaAlunoRespostaDto>(query, new { alunoRa, provaId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

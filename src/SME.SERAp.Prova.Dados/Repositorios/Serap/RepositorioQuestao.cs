﻿using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.Questao;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioQuestao : RepositorioBase<Questao>, IRepositorioQuestao
    {
        public RepositorioQuestao(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {
        }

        public async Task<Questao> ObterPorArquivoAudioIdAsync(long arquivoAudioId)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select 
                                    q.id Id,
                                    q.ordem Ordem,
                                    q.texto_base TextoBase,
                                    q.enunciado Enunciado,
                                    q.questao_legado_id QuestaoLegadoId,
                                    q.prova_id ProvaId
                                from questao q
                                inner join questao_audio qa
                                    on q.id = qa.questao_id
                                inner join arquivo a
                                    on qa.arquivo_id = a.id
                                where a.id = @arquivoAudioId;";

                return await conn.QueryFirstOrDefaultAsync<Questao>(query, new { arquivoAudioId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<Questao>> ObterQuestoesPorProvaIdAsync(long provaId)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select id, texto_base, questao_legado_id, enunciado, ordem, prova_id, tipo, caderno, quantidade_alternativas 
                              from questao q where q.prova_id = @provaId";
                return await conn.QueryAsync<Questao>(query, new { provaId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<Questao>> ObterQuestoesPorProvaIdCadernoAsync(long provaId, string caderno)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select id, texto_base, questao_legado_id, enunciado, ordem, prova_id, tipo, caderno, quantidade_alternativas 
                              from questao q where q.prova_id = @provaId and q.caderno = @caderno";
                return await conn.QueryAsync<Questao>(query, new { provaId, caderno });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<QuestaoDetalheResumoDadosDto>> ObterDetalhesResumoPorIdAsync(long provaId, long id)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select
	                            provaid,
	                            questaoId,
	                            alternativaId,
	                            questaoArquivoId,
	                            alternativaArquivoId,
	                            aa.id as audioId,
	                            qv.id as videoId
                            from v_prova_detalhes p	
                            left join questao_audio qa on qa.questao_id = p.questaoId 	
                            left join arquivo aa on aa.id = qa.arquivo_id
                            left join questao_video qv on qv.questao_id = p.questaoId 
                            where p.provaid = @provaId 
	                            and	 p.questaoid = @id";

                return await conn.QueryAsync<QuestaoDetalheResumoDadosDto>(query, new { provaId, id });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<ProvaCadernoDadoDto>> ObterCadernosPorProvaId(long provaId)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select distinct caderno from questao q where q.prova_id = @provaId order by caderno";
                return await conn.QueryAsync<ProvaCadernoDadoDto>(query, new { provaId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<QuestaoResumoProvaDto>> ObterQuestaoResumoPorProvaIdAsync(long provaId)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select q.id as QuestaoId, q.questao_legado_id as QuestaoLegadoId, q.caderno, q.ordem from questao q where q.prova_id = @provaId";
                return await conn.QueryAsync<QuestaoResumoProvaDto>(query, new { provaId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<QuestaoCompleta>> ObterQuestaoCompletaPorIdsAsync(long[] ids)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = new StringBuilder();
                // questão
                query.AppendLine(" select id, json ");
                query.AppendLine(" from questao_completa ");
                query.AppendLine(" where id = ANY(@ids); ");

                return await conn.QueryAsync<QuestaoCompleta>(query.ToString(), new { ids });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<QuestaoCompleta>> ObterQuestaoCompletaPorLegadoIdsAsync(long[] legadoIds)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = new StringBuilder();
                // questão
                query.AppendLine(" select questao_legado_id as id, max(json) as json ");
                query.AppendLine(" from questao_completa ");
                query.AppendLine(" where questao_legado_id = ANY(@legadoIds) ");
                query.AppendLine(" group by questao_legado_id; ");

                return await conn.QueryAsync<QuestaoCompleta>(query.ToString(), new { legadoIds });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<long> ObterUltimaQuestaoTaiPorProvaAlunoRa(long provaId, long alunoRa)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select q.id 
                              from questao q 
                              left join caderno_aluno ca on ca.prova_id = q.prova_id and ca.caderno = q.caderno 
                              left join aluno a on a.id = ca.aluno_id 
                              where q.prova_id = @provaId 
                                and a.ra = @alunoRa 
                                and q.ordem <> 999  
                              order by q.ordem desc limit 1";

                return await conn.QueryFirstOrDefaultAsync<long>(query.ToString(), new { provaId, alunoRa });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<QuestaoTaiDto>> ObterQuestaoTaiPorProvaAlunoRa(long provaId, long alunoRa)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select q.id, 
	                                 q.ordem,
                                     qt.discriminacao, 
                                     qt.dificuldade as ProporcaoAcertos, 
                                     qt.acerto_casual as AcertoCasual
                              from questao q 
                              left join caderno_aluno ca on ca.prova_id = q.prova_id and ca.caderno = q.caderno 
                              left join aluno a on a.id = ca.aluno_id 
                              left join questao_tri qt on qt.questao_id = q.id
                              where q.prova_id = @provaId 
                                and a.ra = @alunoRa 
                              order by q.ordem";

                return await conn.QueryAsync<QuestaoTaiDto>(query, new { provaId, alunoRa });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

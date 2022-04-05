using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.Dtos;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioQuestao : RepositorioBase<Questao>, IRepositorioQuestao
    {
        public RepositorioQuestao(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }

        public async Task<Questao> ObterPorIdLegadoAsync(long id)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select * from questao where questao_legado_id = @id";

                return await conn.QueryFirstOrDefaultAsync<Questao>(query, new { id });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<bool> RemoverPorProvaIdAsync(long provaId)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"delete
                                from
	                                questao
                                where
	                               prova_id = @provaId";

                await conn.ExecuteAsync(query, new { provaId });

                return true;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
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
    }
}

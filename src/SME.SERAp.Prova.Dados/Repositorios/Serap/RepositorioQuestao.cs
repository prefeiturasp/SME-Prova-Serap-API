using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;

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

        public async Task<IEnumerable<Questao>> ObterTodasParaCacheAsync()
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select * from questao q where q.prova_id in (select id from prova)";

                return await conn.QueryAsync<Questao>(query);
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
    }
}

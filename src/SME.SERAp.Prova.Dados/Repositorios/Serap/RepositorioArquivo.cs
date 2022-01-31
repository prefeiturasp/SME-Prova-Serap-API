using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioArquivo : RepositorioBase<Arquivo>, IRepositorioArquivo
    {
        public RepositorioArquivo(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }

        public async Task<bool> RemoverPorIdsAsync(long[] ids)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"delete
                                from
	                                arquivo
                                where
	                               id = any(@ids)";

                await conn.ExecuteAsync(query, new { ids });
                return true;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public async Task<Arquivo> ObterPorIdLegadoAsync(long id)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select * from arquivo 	                            
                            where
	                            legado_id = @id";

                return await conn.QueryFirstOrDefaultAsync<Arquivo>(query, new { id });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<Arquivo>> ObterTodosParaCacheAsync()
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select * from arquivo a where a.id in (select arquivo_id from alternativa_arquivo)
                                union 
                              select * from arquivo a where a.id in (select arquivo_id from questao_arquivo)";

                return await conn.QueryAsync<Arquivo>(query);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<Arquivo>> ObterArquivosAudioPorQuestaoIdAsync(long questaoId)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select 
                                    a.id Id,
                                    a.caminho Caminho,
                                    a.tamanho_bytes TamanhoBytes,
                                    a.legado_id LegadoId
                                from arquivo a
                                inner join questao_audio qa 
                                    on a.id = qa.arquivo_id
                                where qa.questao_id = @questaoId";

                return await conn.QueryAsync<Arquivo>(query, new { questaoId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }        
    }
}

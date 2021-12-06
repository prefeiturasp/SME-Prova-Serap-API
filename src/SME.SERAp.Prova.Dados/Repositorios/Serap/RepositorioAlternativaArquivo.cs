using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioAlternativaArquivo : RepositorioBase<AlternativaArquivo>, IRepositorioAlternativaArquivo
    {
        public RepositorioAlternativaArquivo(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }

        public async Task<IEnumerable<AlternativaArquivo>> ObterArquivosPorProvaIdAsync(long provaId)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"select *
                                from
	                                alternativa_arquivo
                                where
	                               alternativa_id in ( select a.id from alternativa a inner join questao q on a.questao_id = q.id where q.prova_id = @provaId)";

                return await conn.QueryAsync<AlternativaArquivo>(query, new { provaId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<bool> RemoverPorIdsAsync(long[] ids)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"delete
                                from
	                                alternativa_arquivo
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

        public async Task<bool> RemoverPorProvaIdAsync(long provaId)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"delete
                                from
	                                questao_arquivo
                                where
	                               questao_id in ( select q.id from questao q inner join prova p on q.prova_id = p.id where p.id = @provaId) ";

                await conn.ExecuteAsync(query, new { provaId });

                return true;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<AlternativaArquivo> ObterPorArquivoIdAsync(long id)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select * from alternativa_arquivo where arquivo_id = @id";

                return await conn.QueryFirstOrDefaultAsync<AlternativaArquivo>(query, new { id });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

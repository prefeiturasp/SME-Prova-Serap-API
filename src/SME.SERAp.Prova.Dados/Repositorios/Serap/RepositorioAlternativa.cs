using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioAlternativa : RepositorioBase<Alternativa>, IRepositorioAlternativa
    {
        public RepositorioAlternativa(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }

        public async Task<IEnumerable<Alternativa>> ObterTodosParaCacheAsync()
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"select * from alternativa";

                return await conn.QueryAsync<Alternativa>(query);
                
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<bool> RemoverPorProvaId(long provaId)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"delete
                                from
	                                alternativa
                                where
	                                questao_id in (
	                                select
		                                id
	                                from
		                                questao q
	                                where
		                                q.prova_id = @provaId)";

                await conn.ExecuteAsync(query, new { provaId });

                return true;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioContextoProva : RepositorioBase<ContextoProva>, IRepositorioContextoProva
    {
        public RepositorioContextoProva(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }

        public async Task<IEnumerable<ContextoProva>> ObterContextoProvaPorProvaId(long provaId)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select * from contexto_prova cp
                                where cp.prova_id = @provaId";

                return await conn.QueryAsync<ContextoProva>(query, new { provaId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<ContextoResumoProvaDto>> ObterContextoProvaResumoPorProvaIdAsync(long provaId)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select id as ContextoProvaId from contexto_prova cp where cp.prova_id = @provaId";

                return await conn.QueryAsync<ContextoResumoProvaDto>(query, new { provaId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

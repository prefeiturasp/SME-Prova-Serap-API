using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioTelaBoasVindas : RepositorioBase<Dominio.TelaBoasVindas>, IRepositorioTelaBoasVindas
    {
        public RepositorioTelaBoasVindas(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }

        public async Task<IEnumerable<TelaBoasVindas>> ObterAtivosAsync()
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"select * from configuracao_tela_boas_vindas where ativo order by ordem";

                return await conn.QueryAsync<Dominio.TelaBoasVindas>(query);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

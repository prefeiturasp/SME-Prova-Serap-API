using Dapper;
using SME.SERAp.Prova.Dados.Interfaces;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {
        }

        public async Task<Usuario> ObterPorLogin(long login)
        {
            using var conn = ObterConexao();
            try
            {
                const string query = @"select * from usuario where login = @login;";

                return await conn.QueryFirstOrDefaultAsync<Usuario>(query, new {login});
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioUsuarioSerapCoreSSO : RepositorioBase<UsuarioSerapCoreSSO>, IRepositorioUsuarioSerapCoreSSO
    {
        public RepositorioUsuarioSerapCoreSSO(ConnectionStringOptions connectionStrings) : base(connectionStrings)
        {
        }

        public async Task<UsuarioSerapCoreSSO> ObterPorLogin(string login)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                const string query = @"select id, id_coresso, login, nome, criado_em, atualizado_em from usuario_serap_coresso where login = @login;";

                return await conn.QueryFirstOrDefaultAsync<UsuarioSerapCoreSSO>(query, new { login });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

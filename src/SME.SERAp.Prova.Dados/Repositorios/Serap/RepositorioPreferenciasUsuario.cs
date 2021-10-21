using Dapper;
using SME.SERAp.Prova.Dados.Interfaces;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioPreferenciasUsuario : RepositorioBase<PreferenciasUsuario>, IRepositorioPreferenciasUsuario
    {
        public RepositorioPreferenciasUsuario(ConnectionStringOptions connectionStringOptions) : base(
            connectionStringOptions)
        {
        }

        public async Task<PreferenciasUsuario> ObterPorUsuarioId(long usuarioId)
        {
            using var conn = ObterConexao();
            try
            {
                const string query = @"select pu.* from preferencias_usuario pu where pu.usuario_id = @usuarioId;";

                return await conn.QueryFirstOrDefaultAsync<PreferenciasUsuario>(query, new {usuarioId});
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<PreferenciasUsuario> ObterPorLogin(long login)
        {
            using var conn = ObterConexao();
            try
            {
                const string query =
                    @"select pu.* from preferencias_usuario pu inner join usuario u on pu.usuario_id = u.id where login = @login;";

                return await conn.QueryFirstOrDefaultAsync<PreferenciasUsuario>(query, new {login});
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
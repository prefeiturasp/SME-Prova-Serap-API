using Dapper;
using SME.SERAp.Prova.Dados.Interfaces;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioUsuarioDispositivo : RepositorioBase<UsuarioDispositivo>, IRepositorioUsuarioDispositivo
    {
        public RepositorioUsuarioDispositivo(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }

        public async Task<IEnumerable<UsuarioDispositivo>> ObterPorDispositivoRaAsync(string dispositivoId, long ra)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"select * from usuario_dispositivo ud where ud.ra = @ra or ud.dispositivo_id = @dispositivoId ";

                return await conn.QueryAsync<UsuarioDispositivo>(query, new { ra, dispositivoId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public async Task<bool> RemoverPorIds(long[] ids)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"delete from usuario_dispositivo where id = any(@ids) ";

                return await conn.ExecuteAsync(query, new { ids}) > 0;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

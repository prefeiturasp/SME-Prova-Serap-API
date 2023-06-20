using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioExecucaoControle : RepositorioBase<ExecucaoControle>, IRepositorioExecucaoControle
    {
        public RepositorioExecucaoControle(ConnectionStringOptions connectionStrings) : base(connectionStrings)
        {

        }

        public async Task<ExecucaoControle> ObterUltimaExecucaoPorTipoAsync(ExecucaoControleTipo execucaoControleTipo)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"select Id, execucao_tipo as Tipo, ultima_execucao as UltimaExecucao from execucao_controle where execucao_tipo = @execucaoControleTipo";

                return await conn.QueryFirstOrDefaultAsync<ExecucaoControle>(query, new { execucaoControleTipo });
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

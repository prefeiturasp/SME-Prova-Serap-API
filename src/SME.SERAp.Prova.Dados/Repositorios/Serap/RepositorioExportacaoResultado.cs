using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioExportacaoResultado : RepositorioBase<ExportacaoResultado>, IRepositorioExportacaoResultado
    {
        public RepositorioExportacaoResultado(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }

        public async Task<ExportacaoResultado> ObterPorProvaSerapIdAsync(long provaSerapId)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select * from exportacao_resultado where prova_serap_id = @provaSerapId order by atualizado_em desc;";

                return await conn.QueryFirstOrDefaultAsync(query, new { provaSerapId });
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

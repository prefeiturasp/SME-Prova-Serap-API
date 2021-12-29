using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<IEnumerable<ProvaExportacaoResultadoDto>> ObterPorFiltroDataAsync(DateTime? dataInicio, DateTime? dataFim, long? provaSerapId)
        {           
            using var conn = ObterConexaoLeitura();
            try
            {
                var sql = new StringBuilder();

                var query = @"select p.id as  ProvaId, 
                                     p.prova_legado_id as ProvaLegadoId,
                                     p.descricao as Descricao,
                                     p.inicio as NomeProva, 
                                     P.inicio as DataInicio,
                                     p.fim as DataFim
                                     case  when  ex.status is null then 0 else ex.status end Status
                                 from prova p
                                 left join (select id, prova_serap_id, 
                                    			   status
                                            from exportacao_resultado ex
                                            group by  id,  prova_serap_id, status
                                              having  id = (select max(id) 
                                                              from exportacao_resultado
                                                              where prova_serap_id = ex.prova_serap_id )
                                            ) as ex
                                       on p.prova_legado_id = ex.prova_serap_id
                                 where 1 = 1";

                sql.Append(query);

                if (dataInicio != null)
                    sql.AppendLine(" and p.inicio >= @DataInicio");
                if (dataFim != null)
                    sql.AppendLine(" and p.fim <= @DataFim");
                if (provaSerapId != null)
                    sql.AppendLine(" and p.prova_legado_id = @ProvaSerapId");

               
                return await conn.QueryAsync<ProvaExportacaoResultadoDto>(sql.ToString(), new { dataInicio, dataFim, provaSerapId });

            }
            catch (Exception ex)
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

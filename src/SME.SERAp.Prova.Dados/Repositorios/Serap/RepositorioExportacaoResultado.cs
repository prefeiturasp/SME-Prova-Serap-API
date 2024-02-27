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
                var query = @"select id,nome_arquivo,status,criado_em,atualizado_em,prova_serap_id 
                                from exportacao_resultado where prova_serap_id = @provaSerapId order by atualizado_em desc;";
                return await conn.QueryFirstOrDefaultAsync<ExportacaoResultado>(query, new { provaSerapId });
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<PaginacaoResultadoDto<ProvaExportacaoResultadoDto>> ObterPorFiltroDataPaginadaAsync(DateTime? dataInicio,
            DateTime? dataFim, long provaSerapId, string descricaoProva, int quantidadeRegistros, int numeroPagina)
        {           
            const string query = @"select p.id as  ProvaId, 
                                        p.prova_legado_id as ProvaLegadoId,
                                        p.descricao as Descricao,
                                        p.descricao as NomeProva,
                                        P.inicio as DataInicio,
                                        p.fim as DataFim,
                                        case when ex.id is null then 0 else ex.id end ProcessoId,
                                        case when ex.status is null then 1 else ex.status end Status,
                                        ex.criado_em as CriadoEm,
                                        coalesce(ex.atualizado_em, ex.criado_em) as UltimaExportacao
                                    from prova p
                                    inner join (select distinct prova_id 
                                                from prova_aluno
                                                where finalizado_em is not null
                                                  and status in (2,5,6,7)) pf on p.id = pf.prova_id
                                    left join (select id, prova_serap_id, status, ex.criado_em, ex.atualizado_em
                                                from exportacao_resultado ex
                                                group by id, prova_serap_id, status
                                                having id = (select max(id) 
                                                                from exportacao_resultado
                                                                where prova_serap_id = ex.prova_serap_id)) as ex on p.prova_legado_id = ex.prova_serap_id
                                    where 1 = 1";
            
            const string queryCount = @"select count(1)
                                        from prova p
                                        inner join (select distinct prova_id
                                                    from prova_aluno
                                                    where finalizado_em is not null
                                                      and status in(2,5,6,7)) pf on p.id = pf.prova_id
                                        left join (select id, prova_serap_id, status
                                                    from exportacao_resultado ex
                                                    group by id, prova_serap_id, status
                                                    having id = (select max(id) 
                                                                    from exportacao_resultado
                                                                    where prova_serap_id = ex.prova_serap_id)) as ex on p.prova_legado_id = ex.prova_serap_id
                                        where 1 = 1";

            var retorno = new PaginacaoResultadoDto<ProvaExportacaoResultadoDto>();
            
            using var conn = ObterConexaoLeitura();
            try
            {
                var sql = new StringBuilder();
                sql.Append(query);

                if (dataInicio != null)
                    sql.AppendLine(" and p.inicio >= @DataInicio");

                if (dataFim != null)
                    sql.AppendLine(" and p.fim <= @DataFim");

                if (provaSerapId > 0)
                    sql.AppendLine(" and p.prova_legado_id = @ProvaSerapId");

                if (!string.IsNullOrEmpty(descricaoProva))
                    sql.AppendLine($" and lower(p.descricao) like '%{descricaoProva.ToLower()}%'");

                sql.AppendLine(" order by p.inicio desc, p.id ");
                sql.AppendLine(" limit @quantidadeRegistros offset(@numeroPagina - 1) * @quantidadeRegistros; ");

                sql.AppendLine(queryCount);
                
                if (dataInicio != null)
                    sql.AppendLine(" and p.inicio >= @DataInicio");

                if (dataFim != null)
                    sql.AppendLine(" and p.fim <= @DataFim");

                if (provaSerapId > 0)
                    sql.AppendLine(" and p.prova_legado_id = @ProvaSerapId");
                
                if (!string.IsNullOrEmpty(descricaoProva))
                    sql.AppendLine($" and lower(p.descricao) like '%{descricaoProva.ToLower()}%'");                
                
                using (var multi = await conn.QueryMultipleAsync(sql.ToString(), new { dataInicio, dataFim, provaSerapId, quantidadeRegistros, numeroPagina }))
                {
                    retorno.Items = multi.Read<ProvaExportacaoResultadoDto>();
                    retorno.TotalRegistros = multi.ReadFirst<int>();
                }

                retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / quantidadeRegistros);

                return retorno;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

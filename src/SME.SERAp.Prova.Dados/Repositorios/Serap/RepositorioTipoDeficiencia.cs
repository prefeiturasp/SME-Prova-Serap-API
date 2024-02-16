using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioTipoDeficiencia : RepositorioBase<TipoDeficiencia>, IRepositorioTipoDeficiencia
    {
        public RepositorioTipoDeficiencia(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }

        public async Task<TipoDeficiencia> ObterPorLegadoId(Guid legadoId)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"select 
                                id Id,
	                            legado_id LegadoId,
	                            codigo_eol CodigoEol,
	                            nome Nome,
	                            criado_em CriadoEm,
	                            atualizado_em AtualizadoEm 
                              from tipo_deficiencia
                                where legado_id = @legadoId;";

                return await conn.QueryFirstOrDefaultAsync<TipoDeficiencia>(query, new { legadoId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<TipoDeficiencia> ObterPorCodigoEol(int codigoEol)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"select 
	                            id Id,
	                            legado_id LegadoId,
	                            codigo_eol CodigoEol,
	                            nome Nome,
	                            criado_em CriadoEm,
	                            atualizado_em AtualizadoEm 
                             from tipo_deficiencia
                                where codigo_eol = @codigoEol;";

                return await conn.QueryFirstOrDefaultAsync<TipoDeficiencia>(query, new { codigoEol });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<TipoDeficiencia>> ObterPorAlunoRa(long alunoRa)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"select td.id Id,
                                    td.legado_id as LegadoId,
                                    td.codigo_eol as CodigoEol,
                                    td.nome as Nome 
                                from aluno_deficiencia ad 
                                inner join tipo_deficiencia td on td.id = ad.deficiencia_id
                                where ad.aluno_ra = @alunoRa
                                and not td.prova_normal";

                return await conn.QueryAsync<TipoDeficiencia>(query, new { alunoRa });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<TipoDeficienciaProvaDto>> ObterPorProvaIds(long[] provaIds)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"select
                                    td.id DeficienciaId,
                                    p.id ProvaId,
                                    td.codigo_eol DeficienciaCodigoEol
                                from prova p
                                inner join tipo_prova tp 
                                    on p.tipo_prova_id = tp.id
                                    and tp.para_estudante_com_deficiencia
                                inner join tipo_prova_deficiencia tpd 
                                    on tpd.tipo_prova_id = tp.id
                                inner join tipo_deficiencia td 
                                    on td.id = tpd.deficiencia_id
                                    where p.id = any(@provaIds)
                                    and tp.para_estudante_com_deficiencia;";

                return await conn.QueryAsync<TipoDeficienciaProvaDto>(query, new { provaIds });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

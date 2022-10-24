using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioProva : RepositorioBase<Dominio.Prova>, IRepositorioProva
    {
        public RepositorioProva(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }

        public async Task<IEnumerable<Dominio.Prova>> ObterPorAnoData(int ano, System.DateTime dataReferenia)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select distinct p.* from prova p 
                                inner join prova_ano pa 
                                on pa.prova_id = p.id 
                                where @dataReferenia between p.inicio_download and p.fim 
                                and pa.ano = @ano";

                return await conn.QueryAsync<Dominio.Prova>(query, new { ano = ano.ToString(), dataReferenia });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<Dominio.Prova> ObterPorIdLegadoAsync(long id)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select * from prova where prova_legado_id = @id";

                return await conn.QueryFirstOrDefaultAsync<Dominio.Prova>(query, new { id });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<ProvaDetalheResumidoBaseDadosDto>> ObterDetalhesResumoPorIdAsync(long id)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select
	                            questaoId,
	                            alternativaId,
	                            questaoArquivoId,
                                questaoArquivoTamanho,
                                alternativaArquivoId,
                                alternativaArquivoTamanho	
                            from
	                            v_prova_detalhes p
                            where
	                            p.provaId = @id";

                return await conn.QueryAsync<ProvaDetalheResumidoBaseDadosDto>(query, new { id });
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

        public async Task<IEnumerable<ProvaDetalheResumidoBaseDadosDto>> ObterDetalhesResumoBIBPorIdERaAsync(long provaId, long alunoRA)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select
	                            questaoId,
	                            alternativaId,
	                            questaoArquivoId,
                                questaoArquivoTamanho,
                                alternativaArquivoId,
                                alternativaArquivoTamanho
                            from
	                            v_prova_bib_detalhes p
                            where
	                            p.provaId = @provaId and p.alunoRa = @alunoRA;";

                return await conn.QueryAsync<ProvaDetalheResumidoBaseDadosDto>(query, new { provaId, alunoRA });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<Dominio.Prova>> ObterPorAnoDataEModalidade(string ano, System.DateTime dataReferenia, int modalidade)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select distinct p.* from prova p 
                                inner join prova_ano pa 
                                on pa.prova_id = p.id 
                                where @dataReferenia between p.inicio_download and p.fim 
                                and pa.ano = @ano and p.modalidade = @modalidade";

                return await conn.QueryAsync<Dominio.Prova>(query, new { ano, dataReferenia, modalidade });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<ProvaAnoDto>> ObterAnosDatasEModalidadesAsync()
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select
                                p.descricao,
                                p.Id,
                                p.total_Itens totalItens,
                                p.inicio_download as InicioDownload,
                                p.inicio,
                                p.fim,
                                p.Tempo_Execucao TempoExecucao,
                                case when pa.modalidade is not null then pa.modalidade else p.modalidade end Modalidade,
                                p.Senha,
                                p.possui_bib PossuiBIB,
                                pa.ano,
                                pa.etapa_eja EtapaEja,
                                p.qtd_itens_sincronizacao_respostas as  quantidadeRespostaSincronizacao,
                                p.ultima_atualizacao as UltimaAtualizacao,
                                tp.para_estudante_com_deficiencia as deficiente
                            from prova p
                            inner join prova_ano pa on pa.prova_id = p.id
                            inner join tipo_prova tp on tp.id = p.tipo_prova_id 
                            where (p.ocultar_prova = false or ocultar_prova is null)
                               and (aderir_todos or aderir_todos is null)";

                return await conn.QueryAsync<ProvaAnoDto>(query);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<List<ProvaAnoDto>> ObterProvasAdesaoAlunoAsync(long alunoRa, long turmaId)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select distinct
	                            p.descricao,
	                            p.Id,
	                            p.total_Itens totalItens,
	                            p.inicio_download as InicioDownload,
	                            p.inicio,
	                            p.fim,
	                            p.Tempo_Execucao TempoExecucao,
	                            p.Modalidade,
	                            p.Senha,
	                            p.possui_bib PossuiBIB,
                                p.qtd_itens_sincronizacao_respostas as quantidadeRespostaSincronizacao,
                                tp.para_estudante_com_deficiencia as deficiente
                            from prova p
                            inner join prova_ano pa on pa.prova_id = p.id 
                            inner join prova_adesao pd on p.id = pd.prova_id                            
                            inner join tipo_prova tp on tp.id = p.tipo_prova_id
                            where (p.ocultar_prova = false or ocultar_prova is null)
                              and not aderir_todos
                              and pd.aluno_ra = @alunoRa;";

                var retorno = await conn.QueryAsync<ProvaAnoDto>(query, new { alunoRa, turmaId });
                return retorno.ToList();
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<string> ObterCadernoAlunoPorProvaIdRa(long provaId, long alunoRA)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select ca.caderno 	
                              from caderno_aluno ca 
                              left join aluno a on a.id = ca.aluno_id
                            where
	                            ca.prova_id = @provaId and a.ra = @alunoRA ";

                return await conn.QueryFirstOrDefaultAsync<string>(query, new { provaId, alunoRA });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<bool> VerificaSeExistePorProvaSerapId(long provaId)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"select 1 from prova pa where prova_legado_id = @provaId";

                return await conn.QueryFirstOrDefaultAsync<bool>(query, new { provaId });
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

        public async Task<PaginacaoResultadoDto<ProvaAreaAdministrativoRetornoDto>> ObterProvasPaginada(ProvaAdmFiltroDto provaAdmFiltroDto, bool inicioFuturo, Guid? perfil, string login)
        {
            using var conn = ObterConexaoLeitura();
            var retorno = new PaginacaoResultadoDto<ProvaAreaAdministrativoRetornoDto>();
            try
            {
                var where = new StringBuilder(" where (p.ocultar_prova is null or p.ocultar_prova = false)");                

                if (!inicioFuturo)
                    where.AppendLine(" and p.inicio <= now()");

                if (provaAdmFiltroDto.ProvaLegadoId.HasValue)
                    where.AppendLine(" and p.prova_legado_id = @provaLegadoId");

                if (provaAdmFiltroDto.Modalidade.HasValue)
                    where.AppendLine(" and p.modalidade = @modalidade");

                if (!string.IsNullOrWhiteSpace(provaAdmFiltroDto.Ano))
                    where.AppendLine(" and exists(select 1 from prova_ano pa where pa.prova_id = p.id and pa.ano = @ano limit 1)");

                if (!string.IsNullOrWhiteSpace(provaAdmFiltroDto.Descricao))
                {
                    provaAdmFiltroDto.Descricao = $"%{provaAdmFiltroDto.Descricao.ToUpper()}%";
                    where.AppendLine(" and upper(p.descricao) like @descricao");
                }

                if (perfil != null && !string.IsNullOrEmpty(login))
                {
                    //-> Permissões por grupo
                    where.Append(@" and exists(select 1 from prova_grupo_permissao pgp
                                                        inner join grupo_serap_coresso g on pgp.grupo_id = g.id
                                                        where pgp.prova_id = p.id
                                                              and g.id_coresso = @perfil
                                                              and pgp.ocultar_prova = false)");

                    //-> Abrangência
                    where.AppendLine(" and (exists(select 1 ");
                    where.AppendLine("             from prova_ano pa2 ");
                    where.AppendLine("             left join turma t2 on t2.ano = pa2.ano ");
                    where.AppendLine("             left join ue u2 on u2.id = t2.ue_id ");
                    where.AppendLine("             where pa2.prova_id = p.id ");
                    where.AppendLine("               and t2.modalidade_codigo = p.modalidade ");
                    where.AppendLine("               and t2.ano_letivo::double precision = date_part('year'::text, p.inicio) ");
                    where.AppendLine("               and (p.aderir_todos is null or p.aderir_todos) ");

                    where.AppendLine("               and exists(select 1 ");
                    where.AppendLine("                          from v_abrangencia_usuario_grupo vaug2 ");
                    //-> Dre
                    where.AppendLine("                          where vaug2.dre_id = u2.dre_id ");
                    //-> Ue
                    where.AppendLine("                            and (vaug2.ue_id is null or vaug2.ue_id = u2.id) ");
                    //-> Turma
                    where.AppendLine("                            and (vaug2.turma_id is null or (vaug2.turma_id = t2.id and vaug2.inicio <= p.inicio and (vaug2.fim is null or vaug2.fim >= p.inicio))) ");

                    where.AppendLine("                            and vaug2.login = @login ");
                    where.AppendLine("                            and vaug2.id_coresso = @perfil ");
                    where.AppendLine("                         )");
                    where.AppendLine("            )");

                    //-> Adesão
                    where.AppendLine(" or exists(select 1 ");
                    where.AppendLine("           from prova_adesao pa3 ");
                    where.AppendLine("           join aluno a3 on a3.ra = pa3.aluno_ra ");
                    where.AppendLine("           join turma ta3 on ta3.id = a3.turma_id and ta3.ue_id = pa3.ue_id ");
                    where.AppendLine("           join ue u3 on u3.id = ta3.ue_id ");

                    where.AppendLine("           where pa3.prova_id = p.id ");
                    where.AppendLine("             and ta3.modalidade_codigo = p.modalidade ");
                    where.AppendLine("             and ta3.ano_letivo::double precision = date_part('year'::text, p.inicio) ");
                    where.AppendLine("             and p.aderir_todos = false ");

                    where.AppendLine("             and exists(select 1 ");
                    where.AppendLine("                        from v_abrangencia_usuario_grupo vaug3 ");
                    where.AppendLine("                        left join turma t3 on t3.id = vaug3.turma_id ");
                    //-> Dre
                    where.AppendLine("                        where vaug3.dre_id = u3.dre_id ");
                    //-> Ue
                    where.AppendLine("                          and (vaug3.ue_id is null or vaug3.ue_id = u3.id) ");
                    //-> Turma
                    where.AppendLine("                          and (vaug3.turma_id is null or ");
                    where.AppendLine("                              (t3.ue_id = ta3.ue_id and t3.ano = ta3.ano and t3.tipo_turma = ta3.tipo_turma and t3.tipo_turno = ta3.tipo_turno and t3.modalidade_codigo = ta3.modalidade_codigo and t3.nome = ta3.nome and vaug3.inicio <= p.inicio and (vaug3.fim is null or vaug3.fim >= p.inicio))) ");

                    where.AppendLine("                          and vaug3.login = @login ");
                    where.AppendLine("                          and vaug3.id_coresso = @perfil ");
                    where.AppendLine("                        )");
                    where.AppendLine("            )");
                    where.AppendLine("     )");
                }

                var query = new StringBuilder();
                query.AppendLine(" select id, ");
                query.AppendLine("       descricao,");
                query.AppendLine("       inicio as dataInicio,");
                query.AppendLine("       fim as datafim,");
                query.AppendLine("       inicio_download as dataInicioDownload,");
                query.AppendLine("       tempo_execucao as tempoExecucao,");
                query.AppendLine("       possui_bib as possuiBib,");
                query.AppendLine("       total_cadernos as totalCadernos,");
                query.AppendLine("       total_itens as totalItens,");
                query.AppendLine("       exists(select 1 from contexto_prova cp where cp.prova_id = p.id) as possuiContexto,");
                query.AppendLine("       senha");
                query.AppendFormat(" from prova p {0} ", where.ToString());
                query.AppendLine(" order by p.inicio desc, p.descricao asc ");
                query.AppendLine(" limit @quantidadeRegistros offset(@numeroPagina - 1) * @quantidadeRegistros; ");
                query.AppendFormat(" select count(*) from prova p {0}; ", where.ToString());

                var parametros = new
                {
                    provaAdmFiltroDto.QuantidadeRegistros,
                    provaAdmFiltroDto.NumeroPagina,
                    provaAdmFiltroDto.ProvaLegadoId,
                    provaAdmFiltroDto.Modalidade,
                    provaAdmFiltroDto.Descricao,
                    provaAdmFiltroDto.Ano,
                    perfil,
                    login
                };

                using (var multi = await conn.QueryMultipleAsync(query.ToString(), parametros))
                {
                    retorno.Items = multi.Read<ProvaAreaAdministrativoRetornoDto>().ToList();
                    retorno.TotalRegistros = multi.ReadFirst<int>();
                }

                retorno.TotalPaginas = (int)Math.Ceiling((double)retorno.TotalRegistros / provaAdmFiltroDto.QuantidadeRegistros);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return retorno;
        }
    }
}

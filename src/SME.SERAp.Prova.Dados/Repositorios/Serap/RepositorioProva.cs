﻿using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos;
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
            catch(Exception ex )
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
	                            p.Modalidade,
	                            p.Senha,
	                            p.possui_bib PossuiBIB,
	                            pa.ano
                            from
	                            prova p
                            inner join prova_ano pa 
                                on pa.prova_id = p.id
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
	                            p.possui_bib PossuiBIB
                            from
	                            prova p
                            inner join prova_ano pa 
                                on pa.prova_id = p.id
                            inner join prova_adesao pd 
                            	on p.id = pd.prova_id                            
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
                var query = @"select
	                            distinct ca.caderno		
                            from
	                            prova p
                            inner join caderno_aluno ca on 
                                p.id = ca.prova_id
                            inner join aluno a on 
                                ca.aluno_id = a.id
                            inner join questao q on
	                            q.prova_id = p.id and ca.caderno = q.caderno
                            left join alternativa alt on
	                            alt.questao_id = q.id
                            left join questao_arquivo qa on
	                            qa.questao_id = q.id
                            left join arquivo arq on
	                            qa.arquivo_id = arq.id
                            where
	                            p.id = @provaId and a.ra = @alunoRA ";

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

                if(!inicioFuturo)
                    where.Append(" and p.inicio <= now()");

                if (provaAdmFiltroDto.ProvaLegadoId.HasValue)
                    where.Append(" and p.prova_legado_id = @provaLegadoId");

                if (provaAdmFiltroDto.Modalidade.HasValue)
                    where.Append(" and p.modalidade = @modalidade");

                if (!string.IsNullOrWhiteSpace(provaAdmFiltroDto.Ano))
                    where.Append(" and exists(select 1 from prova_ano pa where pa.prova_id = p.id and pa.ano = @ano limit 1)");

                if (!string.IsNullOrWhiteSpace(provaAdmFiltroDto.Descricao))
                {
                    provaAdmFiltroDto.Descricao = $"%{provaAdmFiltroDto.Descricao.ToUpper()}%";
                    where.Append(" and upper(p.descricao) like @descricao");
                }

                if (perfil != null && !string.IsNullOrEmpty(login))
                {
                    //-> Abrangência
                    where.Append(" and (exists(select 1 ");
                    where.Append("              from prova p2 join prova_ano pa2 on pa2.prova_id = p2.id ");
                    where.Append("              join turma t2 on t2.modalidade_codigo = p2.modalidade and t2.ano = pa2.ano and t2.ano_letivo::double precision = date_part('year'::text, p2.inicio) ");
                    where.Append("              join ue u2 on u2.id = t2.ue_id ");
                    where.Append("              where (p2.ocultar_prova is null or p2.ocultar_prova = false)");
                    where.Append("                and (p2.aderir_todos is null or p2.aderir_todos) ");
                    where.Append("                and p2.id = p.id");

                    //-> Dre
                    where.Append("                and (exists(select 1 from v_abrangencia_usuario_grupo where dre_id = u2.dre_id and ue_id is null and turma_id is null and login = @login and id_coresso = @perfil)");

                    //-> Ue
                    where.Append("                or exists(select 1 from v_abrangencia_usuario_grupo where ue_id = u2.id and turma_id is null and login = @login and id_coresso = @perfil)");

                    //-> Turma
                    where.Append("                or exists(select 1 from v_abrangencia_usuario_grupo where turma_id = t2.id and login = @login and id_coresso = @perfil))");
                    where.Append(" )");

                    ////-> Adesão
                    where.Append(" or exists(select 1 ");
                    where.Append("             from prova p3 ");
                    where.Append("             join prova_adesao pa3 on pa3.prova_id = p3.id and pa3.modalidade_codigo = p3.modalidade ");
                    where.Append("             join turma t3 on t3.ue_id = pa3.ue_id and t3.modalidade_codigo = pa3.modalidade_codigo and t3.ano = pa3.ano_turma and t3.tipo_turma = pa3.tipo_turma and t3.tipo_turno = pa3.tipo_turno and t3.ano_letivo::double precision = date_part('year'::text, p3.inicio) ");
                    where.Append("              join ue u3 on u3.id = t3.ue_id ");
                    where.Append("              where (p3.ocultar_prova is null or p3.ocultar_prova = false) and (p3.aderir_todos = false) and p3.id = p.id ");

                    //-> Dre
                    where.Append("                and (exists(select 1 from v_abrangencia_usuario_grupo where dre_id = u3.dre_id and ue_id is null and turma_id is null and login = @login and id_coresso = @perfil)");

                    //-> Ue
                    where.Append("                or exists(select 1 from v_abrangencia_usuario_grupo where ue_id = u3.id and turma_id is null and login = @login and id_coresso = @perfil)");

                    //-> Turma
                    where.Append("                or exists(select 1 from v_abrangencia_usuario_grupo where turma_id = t3.id and login = @login and id_coresso = @perfil)))");
                    where.Append(" )");
                }

                var query = new StringBuilder();
                query.Append(" select id, ");
                query.Append("       descricao,");
                query.Append("       inicio as dataInicio,");
                query.Append("       fim as datafim,");
                query.Append("       inicio_download as dataInicioDownload,");
                query.Append("       tempo_execucao as tempoExecucao,");
                query.Append("       possui_bib as possuiBib,");
                query.Append("       total_cadernos as totalCadernos,");
                query.Append("       total_itens as totalItens,");
                query.Append("       exists(select 1 from contexto_prova cp where cp.prova_id = p.id) as possuiContexto,");
                query.Append("       senha");
                query.AppendFormat(" from prova p {0} ", where.ToString());
                query.Append(" order by p.inicio desc, p.descricao asc ");
                query.Append(" limit @quantidadeRegistros offset(@numeroPagina - 1) * @quantidadeRegistros; ");
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

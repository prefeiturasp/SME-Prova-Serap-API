using Dapper;
using Npgsql;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioPropagacaoCache : IRepositorioPropagacaoCache
    {

        private readonly ConnectionStringOptions connectionStrings;

        public RepositorioPropagacaoCache(ConnectionStringOptions connectionStrings)
        {
            this.connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        private IDbConnection ObterConexaoLeitura()
        {
            var conexao = new NpgsqlConnection(connectionStrings.ApiSerapLeitura);
            conexao.Open();
            return conexao;
        }

        private IDbConnection ObterConexao()
        {
            var conexao = new NpgsqlConnection(connectionStrings.ApiSerap);
            conexao.Open();
            return conexao;
        }

        public async Task<IEnumerable<Dominio.Prova>> ObterProvasLiberadasNoPeriodoParaCacheAsync()
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select * from prova where inicio_download::date <= current_date and fim::date >= current_date";
                return await SqlMapper.QueryAsync<Dominio.Prova>(conn, query);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<QuestaoCompleta>> ObterQuestaoCompletaParaCacheAsync(long[] provaIds)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = new StringBuilder();
                // questão
                query.AppendLine(" select qc.id, qc.json ");
                query.AppendLine(" from questao q ");
                query.AppendLine(" join questao_completa qc on qc.id = q.id ");
                query.AppendLine(" where q.prova_id = ANY(@provaIds); ");

                return await SqlMapper.QueryAsync<QuestaoCompleta>(conn, query.ToString(), new { provaIds });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<QuestaoCompleta>> ObterQuestaoCompletaLegadoParaCacheAsync(long[] provaIds)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = new StringBuilder();
                // questão
                query.AppendLine(" select qc.questao_legado_id as id, max(qc.json) as json ");
                query.AppendLine(" from questao q ");
                query.AppendLine(" join questao_completa qc on qc.id = q.id ");
                query.AppendLine(" where q.prova_id = ANY(@provaIds) ");
                query.AppendLine(" group by qc.questao_legado_id; ");

                return await SqlMapper.QueryAsync<QuestaoCompleta>(conn, query.ToString(), new { provaIds });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<QuestaoResumoProvaDto>> ObterQuestaoResumoParaCacheAsync(long[] provaIds)
        {

            using var conn = ObterConexaoLeitura();
            try
            {
                var query = new StringBuilder();
                query.Append(" select q.prova_id as ProvaId, q.id as QuestaoId, q.questao_legado_id as QuestaoLegadoId, q.caderno, q.ordem from questao q where q.prova_id = ANY(@provaIds);");
                query.Append(" select q.id as QuestaoId, a.id, a.alternativa_legado_id as AlternativaLegadoId, a.ordem from questao q left join alternativa a on a.questao_id = q.id where q.prova_id = ANY(@provaIds);");

                using (var sqlMapper = await SqlMapper.QueryMultipleAsync(conn, query.ToString(), new { provaIds }))
                {
                    var questoes = await sqlMapper.ReadAsync<QuestaoResumoProvaDto>();
                    var alternativas = await sqlMapper.ReadAsync<AlternativaResumoProvaDto>();

                    foreach (var questao in questoes)
                    {
                        questao.Alternativas = alternativas.Where(t => t.QuestaoId == questao.QuestaoId);
                    }

                    return questoes;
                }
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<ParametroSistema>> ObterParametrosParaCacheAsync()
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"SELECT id, ano, tipo, descricao, nome, valor, criado_em
                              FROM public.parametro_sistema;";

                return await SqlMapper.QueryAsync<ParametroSistema>(conn, query);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<ProvaAnoDto>> ObterProvasAnosDatasEModalidadesParaCacheAsync()
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
                                tp.para_estudante_com_deficiencia as deficiente,
                                p.prova_com_proficiencia ProvaComProficiencia,
                                p.apresentar_resultados ApresentarResultados,
                                p.apresentar_resultados_por_item ApresentarResultadosPorItem,
                                p.formato_tai FormatoTai,
                                p.formato_tai_item FormatoTaiItem,
                                p.formato_tai_avancar_sem_responder FormatoTaiAvancarSemResponder,
                                p.formato_tai_voltar_item_anterior FormatoTaiVoltarItemAnterior,
                                p.exibir_video as ExibirVideo,
                                p.exibir_audio as ExibirAudio
                              from prova p
                              inner join prova_ano pa on pa.prova_id = p.id
                              inner join tipo_prova tp on tp.id = p.tipo_prova_id 
                              where (p.ocultar_prova = false or ocultar_prova is null)
                                and (aderir_todos or aderir_todos is null)";

                return await SqlMapper.QueryAsync<ProvaAnoDto>(conn, query);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task InserirTabelaJson(long questaoId, string json)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"insert into questao_completa (id, json) values (@questaoId, @json) on conflict (id) do update set json = @json;";
                await SqlMapper.ExecuteAsync(conn, query, new { questaoId, json });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }


    }
}

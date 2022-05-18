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

        public async Task<IEnumerable<Dominio.Prova>> ObterProvasLiberadasNoPeriodoParaCacheAsync(DateTime dataHoraAtual)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select * from prova where inicio_download <= @dataHoraAtual and fim >= @dataHoraAtual";
                return await SqlMapper.QueryAsync<Dominio.Prova>(conn, query, new { dataHoraAtual });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<QuestaoCompletaDto>> ObterQuestaoCompletaParaCacheAsync(long[] provaIds)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = new StringBuilder();
                // questão
                query.AppendLine(" select q.id, q.texto_base as titulo, q.enunciado as descricao, q.ordem, q.tipo, q.quantidade_alternativas as quantidadeAlternativas ");
                query.AppendLine(" from questao q ");
                query.AppendLine(" where q.prova_id = ANY(@provaIds); ");

                // arquivos
                query.AppendLine(" select distinct ar.id, ar.legado_id as legadoId, q.id as questaoId, ar.caminho, ar.tamanho_bytes as tamanhoBytes");
                query.AppendLine(" from questao q ");
                query.AppendLine(" join questao_arquivo qa on qa.questao_id = q.id ");
                query.AppendLine(" join arquivo ar on ar.id = qa.arquivo_id ");
                query.AppendLine(" where q.prova_id = ANY(@provaIds); ");

                // arquivos audio
                query.AppendLine(" select distinct ar.id, ar.legado_id as legadoId, q.id as questaoId, ar.caminho, ar.tamanho_bytes as tamanhoBytes");
                query.AppendLine(" from questao q ");
                query.AppendLine(" join questao_audio qa on qa.questao_id = q.id ");
                query.AppendLine(" join arquivo ar on ar.id = qa.arquivo_id ");
                query.AppendLine(" where q.prova_id = ANY(@provaIds); ");

                // arquivos video
                query.AppendLine(" select distinct q.id as questaoId, qv.id, ");
                query.AppendLine("     ar.caminho, ar.tamanho_bytes as tamanhoBytes,  ");
                query.AppendLine("     art.caminho as caminhoVideoThumbinail, art.tamanho_bytes as videoThumbinailTamanhoBytes, ");
                query.AppendLine("     arc.caminho as caminhoVideoConvertido, arc.tamanho_bytes as videoConvertidoTamanhoBytes ");
                query.AppendLine(" from questao q ");
                query.AppendLine(" join questao_video qv on qv.questao_id = q.id ");
                query.AppendLine(" join arquivo ar on ar.id = qv.arquivo_video_id ");
                query.AppendLine(" left join arquivo art on art.id = qv.arquivo_thumbnail_id ");
                query.AppendLine(" left join arquivo arc on arc.id = qv.arquivo_video_convertido_id ");
                query.AppendLine(" where q.prova_id = ANY(@provaIds); ");

                // alternativas
                query.AppendLine(" select q.id as questaoId, a.id, a.descricao, a.ordem, a.numeracao ");
                query.AppendLine(" from questao q ");
                query.AppendLine(" join alternativa a on a.questao_id = q.id ");
                query.AppendLine(" where q.prova_id = ANY(@provaIds); ");

                // arquivos alternativas
                query.AppendLine(" select distinct ar.id, ar.legado_id as legadoId, a.questao_id as questaoId, ar.caminho, ar.tamanho_bytes as tamanhoBytes ");
                query.AppendLine(" from questao q ");
                query.AppendLine(" join alternativa a on a.questao_id = q.id ");
                query.AppendLine(" join alternativa_arquivo aa on aa.alternativa_id = a.id ");
                query.AppendLine(" join arquivo ar on ar.id = aa.arquivo_id ");
                query.AppendLine(" where q.prova_id = ANY(@provaIds); ");

                using (var sqlMapper = await SqlMapper.QueryMultipleAsync(conn, query.ToString(), new { provaIds }))
                {
                    var questoesCompletas = sqlMapper.Read<QuestaoCompletaDto>();
                    var arquivos = sqlMapper.Read<ArquivoDto>();
                    var audios = sqlMapper.Read<ArquivoDto>();
                    var videos = sqlMapper.Read<ArquivoVideoDto>();
                    var alternativas = sqlMapper.Read<AlternativaDto>();
                    var arquivosAlternativas = sqlMapper.Read<ArquivoDto>();

                    foreach (var questaoCompleta in questoesCompletas)
                    {
                        questaoCompleta.Arquivos = arquivos.Where(t => t.QuestaoId == questaoCompleta.Id);
                        questaoCompleta.Audios = audios.Where(t => t.QuestaoId == questaoCompleta.Id);
                        questaoCompleta.Videos = videos.Where(t => t.QuestaoId == questaoCompleta.Id);
                        questaoCompleta.Alternativas = alternativas.Where(t => t.QuestaoId == questaoCompleta.Id);

                        var arquivosAlternativasQuestao = arquivosAlternativas.Where(t => t.QuestaoId == questaoCompleta.Id);
                        if (arquivosAlternativasQuestao.Any())
                        {
                            var arquivosQuestao = questaoCompleta.Arquivos.ToList();
                            arquivosQuestao.AddRange(arquivosAlternativasQuestao);
                            questaoCompleta.Arquivos = arquivosQuestao;
                        }
                    }

                    return questoesCompletas;
                }
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
                var query = @"select q.prova_id as ProvaId, q.id as QuestaoId, q.caderno from questao q where q.prova_id = ANY(@provaIds)";
                return await SqlMapper.QueryAsync<QuestaoResumoProvaDto>(conn, query, new { provaIds });
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
                                p.ultima_atualizacao as UltimaAtualizacao
                            from
	                            prova p
                            inner join prova_ano pa 
                                on pa.prova_id = p.id
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
    }
}

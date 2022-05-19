using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioQuestao : RepositorioBase<Questao>, IRepositorioQuestao
    {
        public RepositorioQuestao(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }

        public async Task<Questao> ObterPorIdLegadoAsync(long id)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select * from questao where questao_legado_id = @id";

                return await conn.QueryFirstOrDefaultAsync<Questao>(query, new { id });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<bool> RemoverPorProvaIdAsync(long provaId)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"delete
                                from
	                                questao
                                where
	                               prova_id = @provaId";

                await conn.ExecuteAsync(query, new { provaId });

                return true;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<Questao> ObterPorArquivoAudioIdAsync(long arquivoAudioId)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select 
                                    q.id Id,
                                    q.ordem Ordem,
                                    q.texto_base TextoBase,
                                    q.enunciado Enunciado,
                                    q.questao_legado_id QuestaoLegadoId,
                                    q.prova_id ProvaId
                                from questao q
                                inner join questao_audio qa
                                    on q.id = qa.questao_id
                                inner join arquivo a
                                    on qa.arquivo_id = a.id
                                where a.id = @arquivoAudioId;";

                return await conn.QueryFirstOrDefaultAsync<Questao>(query, new { arquivoAudioId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<Questao>> ObterQuestoesPorProvaIdAsync(long provaId)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select id, texto_base, questao_legado_id, enunciado, ordem, prova_id, tipo, caderno, quantidade_alternativas 
                              from questao q where q.prova_id = @provaId";
                return await conn.QueryAsync<Questao>(query, new { provaId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<Questao>> ObterQuestoesPorProvaIdCadernoAsync(long provaId, string caderno)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select id, texto_base, questao_legado_id, enunciado, ordem, prova_id, tipo, caderno, quantidade_alternativas 
                              from questao q where q.prova_id = @provaId and q.caderno = @caderno";
                return await conn.QueryAsync<Questao>(query, new { provaId, caderno });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<QuestaoDetalheResumoDadosDto>> ObterDetalhesResumoPorIdAsync(long provaId, long id)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select
	                            provaid,
	                            questaoId,
	                            alternativaId,
	                            questaoArquivoId,
	                            alternativaArquivoId,
	                            aa.id as audioId,
	                            qv.id as videoId
                            from v_prova_detalhes p	
                            left join questao_audio qa on qa.questao_id = p.questaoId 	
                            left join arquivo aa on aa.id = qa.arquivo_id
                            left join questao_video qv on qv.questao_id = p.questaoId 
                            where p.provaid = @provaId 
	                            and	 p.questaoid = @id";

                return await conn.QueryAsync<QuestaoDetalheResumoDadosDto>(query, new { provaId, id });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<ProvaCadernoDadoDto>> ObterCadernosPorProvaId(long provaId)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select distinct caderno from questao q where q.prova_id = @provaId order by caderno";
                return await conn.QueryAsync<ProvaCadernoDadoDto>(query, new { provaId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<QuestaoResumoProvaDto>> ObterQuestaoResumoPorProvaIdAsync(long provaId)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select q.id as QuestaoId, q.caderno from questao q where q.prova_id = @provaId";
                return await conn.QueryAsync<QuestaoResumoProvaDto>(query, new { provaId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<QuestaoCompletaDto> ObterQuestaoCompletaPorIdAsync(long id)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = new StringBuilder();
                // questão
                query.AppendLine(" select q.id, q.texto_base as titulo, q.enunciado as descricao, q.ordem, q.tipo, q.quantidade_alternativas as quantidadeAlternativas ");
                query.AppendLine(" from questao q ");
                query.AppendLine(" where q.id = @id; ");

                // arquivos
                query.AppendLine(" select distinct ar.id, ar.legado_id as legadoId, qa.questao_id as questaoId, ar.caminho, ar.tamanho_bytes as tamanhoBytes");
                query.AppendLine(" from questao_arquivo qa ");
                query.AppendLine(" join arquivo ar on ar.id = qa.arquivo_id ");
                query.AppendLine(" where qa.questao_id = @id; ");

                // arquivos audio
                query.AppendLine(" select distinct ar.id, ar.legado_id as legadoId, qa.questao_id as questaoId, ar.caminho, ar.tamanho_bytes as tamanhoBytes");
                query.AppendLine(" from questao_audio qa ");
                query.AppendLine(" join arquivo ar on ar.id = qa.arquivo_id ");
                query.AppendLine(" where qa.questao_id = @id; ");

                // arquivos video
                query.AppendLine(" select distinct qv.id, ");
                query.AppendLine("     ar.caminho, ar.tamanho_bytes as tamanhoBytes,  ");
                query.AppendLine("     art.caminho as caminhoVideoThumbinail, art.tamanho_bytes as videoThumbinailTamanhoBytes, ");
                query.AppendLine("     arc.caminho as caminhoVideoConvertido, arc.tamanho_bytes as videoConvertidoTamanhoBytes ");
                query.AppendLine(" from questao_video qv ");
                query.AppendLine(" join arquivo ar on ar.id = qv.arquivo_video_id ");
                query.AppendLine(" left join arquivo art on art.id = qv.arquivo_thumbnail_id ");
                query.AppendLine(" left join arquivo arc on arc.id = qv.arquivo_video_convertido_id ");
                query.AppendLine(" where qv.questao_id = @id; ");

                // alternativas
                query.AppendLine(" select a.id, a.descricao, a.ordem, a.numeracao ");
                query.AppendLine(" from alternativa a ");
                query.AppendLine(" where a.questao_id = @id; ");

                // arquivos alternativas
                query.AppendLine(" select distinct ar.id, ar.legado_id as legadoId, a.questao_id as questaoId, ar.caminho, ar.tamanho_bytes as tamanhoBytes");
                query.AppendLine(" from alternativa a ");
                query.AppendLine(" join alternativa_arquivo aa on aa.alternativa_id = a.id ");
                query.AppendLine(" join arquivo ar on ar.id = aa.arquivo_id ");
                query.AppendLine(" where a.questao_id = @id; ");

                using (var sqlMapper = await conn.QueryMultipleAsync(query.ToString(), new { id }))
                {
                    var questaoCompletaDto = sqlMapper.ReadFirst<QuestaoCompletaDto>();
                    questaoCompletaDto.Arquivos = sqlMapper.Read<ArquivoDto>();
                    questaoCompletaDto.Audios = sqlMapper.Read<ArquivoDto>();
                    questaoCompletaDto.Videos = sqlMapper.Read<ArquivoVideoDto>();
                    questaoCompletaDto.Alternativas = sqlMapper.Read<AlternativaDto>();

                    var arquivosAlternativas = sqlMapper.Read<ArquivoDto>();
                    if (arquivosAlternativas.Any())
                    {
                        var arquivos = questaoCompletaDto.Arquivos.ToList();
                        arquivos.AddRange(arquivosAlternativas);
                        questaoCompletaDto.Arquivos = arquivos;
                    }

                    return questaoCompletaDto;
                }
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<QuestaoCompleta>> ObterQuestaoCompletaPorIdsAsync(long[] ids)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = new StringBuilder();
                // questão
                query.AppendLine(" select id, json ");
                query.AppendLine(" from questao_completa ");
                query.AppendLine(" where id = ANY(@ids); ");

                return await conn.QueryAsync<QuestaoCompleta>(query.ToString(), new { ids });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioQuestaoVideo : RepositorioBase<QuestaoVideo>, IRepositorioQuestaoVideo
    {
        public RepositorioQuestaoVideo(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }

        public async Task<IEnumerable<QuestaoVideo>> ObterPorQuestaoId(long questaoId)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"select id, questao_id, arquivo_video_id, arquivo_thumbnail_id, 
                                    arquivo_video_convertido_id, criado_em, atualizado_em
                                from questao_video
                                where questao_id = @questaoId;";

                return await conn.QueryAsync<QuestaoVideo>(query, new { questaoId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<QuestaoVideo>> ObterPorProvaId(long provaId)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"select qv.id, qv.questao_id, qv.arquivo_video_id, qv.arquivo_thumbnail_id, 
                                    qv.arquivo_video_convertido_id, qv.criado_em, qv.atualizado_em
                                from questao_video qv
                                    inner join questao q on q.id = qv.questao_id
                                where q.prova_id = @provaId;";

                return await conn.QueryAsync<QuestaoVideo>(query, new { provaId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }        
    }
}

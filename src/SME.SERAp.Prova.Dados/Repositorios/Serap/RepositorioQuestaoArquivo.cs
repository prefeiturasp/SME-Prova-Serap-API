using System.Threading.Tasks;
using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioQuestaoArquivo : RepositorioBase<QuestaoArquivo>, IRepositorioQuestaoArquivo
    {
        public RepositorioQuestaoArquivo(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }

        public async Task<QuestaoArquivo> ObterPorArquivoIdAsync(long id)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"select * from questao_arquivo where arquivo_id = @id";

                return await conn.QueryFirstOrDefaultAsync<QuestaoArquivo>(query, new { id });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

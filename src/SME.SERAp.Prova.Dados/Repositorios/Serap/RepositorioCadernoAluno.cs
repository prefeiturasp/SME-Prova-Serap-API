using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioCadernoAluno : RepositorioBase<CadernoAluno>, IRepositorioCadernoAluno
    {
        public RepositorioCadernoAluno(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }

        public async Task<bool> ExisteCadernoAlunoPorProvaIdAlunoId(long provaId, long alunoId)
        {
            using var conn = ObterConexao();
            try
            {
                var query = "select count(1) from caderno_aluno where prova_id = @provaId and aluno_id = @alunoId limit 1";

                return await conn.ExecuteScalarAsync<bool>(query, new { provaId, alunoId });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

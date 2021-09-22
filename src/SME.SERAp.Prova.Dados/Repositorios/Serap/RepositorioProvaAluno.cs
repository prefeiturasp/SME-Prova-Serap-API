using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioProvaAluno : RepositorioBase<Dominio.ProvaAluno>, IRepositorioProvaAluno
    {
        public RepositorioProvaAluno(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }

        public async Task<ProvaAluno> ObterPorProvaIdRaAsync(long provaId, long alunoRa)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"select distinct pa.* from prova_aluno pa where pa.prova_id = @provaId and pa.aluno_ra = @alunoRa";

                return await conn.QueryFirstOrDefaultAsync<ProvaAluno>(query, new { provaId, alunoRa });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

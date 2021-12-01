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
            using var conn = ObterConexaoLeitura();
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

        public async Task<ProvaAluno> ObterPorQuestaoIdRaAsync(long questaoId, long alunoRa)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select distinct pa.* from prova_aluno pa 
                                inner join questao q on pa.prova_id = q.prova_id 
                                where q.id = @questaoId and pa.aluno_ra = @alunoRa";

                return await conn.QueryFirstOrDefaultAsync<ProvaAluno>(query, new { questaoId, alunoRa });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<ProvaAluno> ObterPorProvaIdRaStatusAsync(long provaId, long alunoRa, int status)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select distinct pa.* from prova_aluno pa where pa.prova_id = @provaId and pa.aluno_ra = @alunoRa and pa.status = @status";

                return await conn.QueryFirstOrDefaultAsync<ProvaAluno>(query, new { provaId, alunoRa, status });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

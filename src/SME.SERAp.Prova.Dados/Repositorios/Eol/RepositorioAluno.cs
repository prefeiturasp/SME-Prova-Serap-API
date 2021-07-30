using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados.Repositorios.Eol
{
    public class RepositorioAluno : IRepositorioAluno
    {
        private readonly ConnectionStringOptions connectionStringOptions;

        public RepositorioAluno(ConnectionStringOptions connectionStringOptions)
        {
            this.connectionStringOptions = connectionStringOptions ?? throw new ArgumentNullException(nameof(connectionStringOptions));
        }
        public async Task<ObterAlunoAtivoRetornoDto> ObterAlunoAtivoAsync(long alunoRA)
        {

            var query = @"SELECT top 1
	                            aluno.cd_aluno CodigoAluno
                            FROM
	                            v_matricula_cotic matricula
                            INNER JOIN v_aluno_cotic aluno ON
	                            matricula.cd_aluno = aluno.cd_aluno
                            INNER JOIN matricula_turma_escola matrTurma ON
	                            matricula.cd_matricula = matrTurma.cd_matricula
                            INNER JOIN turma_escola turesc ON
	                            matrTurma.cd_turma_escola = turesc.cd_turma_escola
                            INNER JOIN escola e ON
	                            turesc.cd_escola = e.cd_escola
                            WHERE
	                            aluno.cd_aluno = @alunoRA
	                            AND matrTurma.cd_situacao_aluno IN (1, 6, 10, 13)
	                            AND e.tp_escola IN (1, 3, 4, 16)";

            using var conn = new SqlConnection(connectionStringOptions.Eol);
            return await conn.QueryFirstOrDefaultAsync<ObterAlunoAtivoRetornoDto>(query, new { alunoRA });

        }
        public async Task<AlunoEol> ObterAlunoDetalhePorRa(long alunoRA)
        {

            var query = @"select al.nm_aluno as nome, al.nm_social_aluno as nomeSocial 
                            from aluno al 
			                    where al.cd_aluno = @alunoRA";

            using var conn = new SqlConnection(connectionStringOptions.Eol);
            return await conn.QueryFirstOrDefaultAsync<AlunoEol>(query, new { alunoRA });

        }
    }
}

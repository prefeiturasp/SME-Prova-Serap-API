using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados.Repositorios.Eol
{
    public class RepositorioAlunoEol : IRepositorioAlunoEol
    {
        private readonly ConnectionStringOptions connectionStringOptions;

        public RepositorioAlunoEol(ConnectionStringOptions connectionStringOptions)
        {
            this.connectionStringOptions = connectionStringOptions ?? throw new ArgumentNullException(nameof(connectionStringOptions));
        }
        public async Task<ObterAlunoAtivoEolRetornoDto> ObterAlunoAtivoAsync(long alunoRA)
        {

            var query = @"SELECT top 1
	                            aluno.cd_aluno CodigoAluno,
	                            se.sg_resumida_serie as Ano,
                                turesc.cd_tipo_turno as TipoTurno,
                                CASE
									WHEN se.cd_etapa_ensino IN (1,10) 
										or (turesc.cd_tipo_turma <> 1 AND e.tp_escola IN (10,11,12,14,15,18,26)) 
										or (turesc.cd_tipo_turma <> 1 AND e.tp_escola IN (2,17,28,30,31)) THEN --Infantil
				                    1
				                    WHEN se.cd_etapa_ensino IN ( 2, 3, 7, 11 ) THEN --eja
				                    3 
				                    WHEN se.cd_etapa_ensino IN ( 4, 5, 12, 13 ) THEN --fundamental
				                    5 
				                    WHEN se.cd_etapa_ensino IN ( 6, 7, 8, 17, 14 ) THEN --médio
				                    6
									else 0
				                END AS Modalidade
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
                            INNER JOIN serie_turma_escola ste ON
								ste.cd_turma_escola = turesc.cd_turma_escola
							INNER JOIN serie_ensino se ON 
								se.cd_serie_ensino = ste.cd_serie_ensino
                            WHERE
	                            aluno.cd_aluno = @alunoRA
	                            AND matrTurma.cd_situacao_aluno IN (1, 6, 10, 13)
	                            AND e.tp_escola IN (1, 3, 4, 16)";

            using var conn = new SqlConnection(connectionStringOptions.Eol);
            return await conn.QueryFirstOrDefaultAsync<ObterAlunoAtivoEolRetornoDto>(query, new { alunoRA });

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

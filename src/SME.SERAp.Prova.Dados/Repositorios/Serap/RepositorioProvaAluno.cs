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
        public async Task<IEnumerable<ProvaAluno>> ObterPorProvaIdsRaAsync(long[] provaIds, long alunoRa)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select distinct pa.* from v_provas_alunos pa where pa.prova_id = ANY(@provaIds) and pa.aluno_ra = @alunoRa";

                return await conn.QueryAsync<ProvaAluno>(query, new { provaIds, alunoRa });
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

        public async Task<IEnumerable<ProvaAlunoAnoDto>> ObterProvasAnterioresAlunoPorRaAsync(long ra)
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
                                    p.Modalidade,
                                    p.Senha,
                                    p.possui_bib PossuiBIB,
                                    pa.ano,
                                    palu.status,
                                    palu.criado_em DataInicioProvaAluno,
                                    palu.finalizado_em DataFimProvaAluno
                                from
                                prova p
                                inner join prova_ano pa
                                    on pa.prova_id = p.id
                                inner join prova_aluno palu 
                                    on p.id = palu.prova_id and palu.status in(2,5)
                                where palu.aluno_ra = @ra";

                return await conn.QueryAsync<ProvaAlunoAnoDto>(query, new { ra });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

    }
}

using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioAluno : RepositorioBase<Aluno>, IRepositorioAluno
    {
        public RepositorioAluno(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {
        }

        public async Task<Aluno> ObterPorRA(long ra)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                const string query = @"select * from aluno where ra = @ra;";

                return await conn.QueryFirstOrDefaultAsync<Aluno>(query, new { ra });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<AlunoDetalheDto> ObterAlunoDetalhePorRa(long ra)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select d.abreviacao as dreabreviacao, 
                                  u.nome as escola, 
                                  t.nome as turma, 
                                  al.nome, 
                                  al.nome_social as nomesocial
                              from aluno as al 
                              left join turma as t on t.id = al.turma_id 
                              left join ue as u on u.id = t.ue_id
                              left join dre as d on d.id = u.dre_id  
                              where al.ra = @ra"; 

                return await conn.QueryFirstOrDefaultAsync<AlunoDetalheDto>(query, new { ra });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<ObterAlunoAtivoRetornoDto> ObterAlunoAtivoPorRa(long ra)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select a.ra, t.ano, t.tipo_turno as tipoTurno, t.modalidade_codigo as modalidade, t.id as TurmaId 
                            from aluno a
                            left join turma t on t.id = a.turma_id 
                            where a.ra = @ra and t.ano_letivo = @anoLetivo
                            and a.situacao in(1,6,10,13,5)";

                return await conn.QueryFirstOrDefaultAsync<ObterAlunoAtivoRetornoDto>(query, new { ra, anoLetivo = DateTime.Now.Year });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
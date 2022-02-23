using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.Dtos.Aluno;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
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
    }
}
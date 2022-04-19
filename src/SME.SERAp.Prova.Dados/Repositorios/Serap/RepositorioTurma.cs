using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioTurma : RepositorioBase<Turma>, IRepositorioTurma
    {
        public RepositorioTurma(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }

        public async Task<IEnumerable<Turma>> ObterTurmasAlunoPorRaAsync(long alunoRa)
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select t.id Id, 
                                     t.ano Ano, 
                                     t.ano_letivo AnoLetivo, 
                                     t.tipo_turma TipoTurma, 
                                     t.modalidade_codigo Modalidade, 
                                     t.tipo_turno TipoTurno,
                                     t.semestre Semestre,
                                     t.serie_ensino SerieEnsino,
                                     t.etapa_eja EtapaEja
                                from turma t 
                                inner join aluno a on t.id = a.turma_id
                                where a.ra = @alunoRa";

                return await conn.QueryAsync<Turma>(query, new { alunoRa });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

    }
}

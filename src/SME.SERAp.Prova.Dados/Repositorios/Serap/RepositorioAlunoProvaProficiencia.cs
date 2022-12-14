﻿using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioAlunoProvaProficiencia : RepositorioBase<AlunoProvaProficiencia>, IRepositorioAlunoProvaProficiencia
    {
        public RepositorioAlunoProvaProficiencia(ConnectionStringOptions connectionStrings) : base(connectionStrings)
        {
        }

        public async Task<decimal> ObterProficienciaFinalAlunoPorProvaIdAsync(long provaId, long alunoId)
        {
            using var conn = ObterConexao();
            try
            {
                var tipo = (int)AlunoProvaProficienciaTipo.Final;

                var query = @"select proficiencia  
                              from aluno_prova_proficiencia app
                              where app.tipo = @tipo 
                                and app.aluno_id = @alunoId 
                                and app.proficiencia > 0 
                                and app.prova_id = @provaId";

                return await conn.QueryFirstOrDefaultAsync<decimal>(query, new { provaId, alunoId, tipo });

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
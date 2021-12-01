using Dapper;
using SME.SERAp.Prova.Dados.Interfaces;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Collections.Generic;
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

                return await conn.QueryFirstOrDefaultAsync<Aluno>(query, new {ra = ra.ToString()});
            }           
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
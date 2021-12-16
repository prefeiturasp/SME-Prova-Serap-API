using Dapper;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioDownloadProvaAluno : RepositorioBase<DownloadProvaAluno>, IRepositorioDownloadProvaAluno
    {
        public RepositorioDownloadProvaAluno(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {
          
        }

        public async Task<bool> ExcluirDownloadProvaAluno(int[] ids, DateTime? dataAlteracao)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"update downloads_prova_aluno set situacao = 3, alterado_em = @dataAlteracao  where id = any(@ids)";

                return await conn.ExecuteAsync(query, new { ids, dataAlteracao } ) > 0;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

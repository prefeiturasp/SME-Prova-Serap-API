using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SME.SERAp.Prova.Dados
{
    public abstract class RepositorioSerapLegadoBase
    {
        private readonly ConnectionStringOptions _connectionStrings;

        public RepositorioSerapLegadoBase(ConnectionStringOptions connectionStrings)
        {
            _connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        protected IDbConnection ObterConexao()
        {
            var conexao = new SqlConnection(_connectionStrings.ApiSerapExterna);
            conexao.Open();
            return conexao;
        }
    }
}
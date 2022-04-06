using Dapper;
using Npgsql;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioPropagacaoCache : IRepositorioPropagacaoCache
    {

        private readonly ConnectionStringOptions connectionStrings;

        public RepositorioPropagacaoCache(ConnectionStringOptions connectionStrings)
        {
            this.connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        private IDbConnection ObterConexaoLeitura()
        {
            var conexao = new NpgsqlConnection(connectionStrings.ApiSerapLeitura);
            conexao.Open();
            return conexao;
        }

        public async Task<IEnumerable<Dominio.Prova>> ObterTodasProvasParaCacheAsync()
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select * from prova";
                return await SqlMapper.QueryAsync<Dominio.Prova>(conn, query);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<Questao>> ObterTodasQuestoesParaCacheAsync()
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select * from questao q where q.prova_id in (select id from prova)";

                return await SqlMapper.QueryAsync<Questao>(conn, query);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<Alternativa>> ObterTodasAlternativasParaCacheAsync()
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select * from alternativa a where a.questao_id in (select id from questao)";

                return await SqlMapper.QueryAsync<Alternativa>(conn, query);

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public async Task<IEnumerable<Arquivo>> ObterTodosArquivosParaCacheAsync()
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select * from arquivo a where a.id in (select arquivo_id from alternativa_arquivo)
                                union 
                              select * from arquivo a where a.id in (select arquivo_id from questao_arquivo)";

                return await SqlMapper.QueryAsync<Arquivo>(conn, query);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

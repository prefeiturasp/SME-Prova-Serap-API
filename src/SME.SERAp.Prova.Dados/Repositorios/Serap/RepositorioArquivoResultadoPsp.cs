using SME.SERAp.Prova.Dados.Interfaces;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioArquivoResultadoPsp : RepositorioSerapLegadoBase, IRepositorioArquivoResultadoPsp
    {
        public RepositorioArquivoResultadoPsp(ConnectionStringOptions connectionStrings) : base(connectionStrings)
        {
        }

        public async Task<ArquivoResultadoPspDto> ObterArquivoResultadoPspPorId(long id)
        {
            using var conn = ObterConexao();
            try
            {
                var query = @"
	                     SELECT  Id
                                ,CodigoTipoResultado
                                ,NomeArquivo
                                ,NomeOriginalArquivo
                                ,CreateDate
                                ,UpdateDate
                                ,State
                          FROM  ArquivoResultadoPsp
                         WHERE Id = @id";

                return await conn.QueryFirstOrDefaultAsync<ArquivoResultadoPspDto>(query, new { id });
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

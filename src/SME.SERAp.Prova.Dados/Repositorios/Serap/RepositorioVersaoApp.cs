using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados.Repositorios.Serap
{
    public class RepositorioVersaoApp : RepositorioBase<VersaoApp>, IRepositorioVersaoApp
    {
        public RepositorioVersaoApp(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {

        }

        public async Task<VersaoApp> ObterUltimaVersao()
        {
            using var conn = ObterConexaoLeitura();
            try
            {
                var query = @"select id, 
                                     codigo_versao, 
                                     descricao_versao, 
                                     mensagem, 
                                     suporte_minimo, 
                                     url 
                                     from public.versao_app
                                     order by id desc 
                                     limit 1";

                return await conn.QueryFirstOrDefaultAsync<VersaoApp>(query);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

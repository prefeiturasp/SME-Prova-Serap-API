using Dapper.FluentMap.Dommel.Mapping;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Dados
{
    public class AlternativaArquivoMap : DommelEntityMap<AlternativaArquivo>
    {
        public AlternativaArquivoMap()
        {
            ToTable("alternativa_arquivo");
            
            Map(c => c.Id).ToColumn("id").IsKey();
            
            Map(c => c.ArquivoId).ToColumn("arquivo_id");
            Map(c => c.AlternativaId).ToColumn("alternativa_id");
            
        }
    }
}

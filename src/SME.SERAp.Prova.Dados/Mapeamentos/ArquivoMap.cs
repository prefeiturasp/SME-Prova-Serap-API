using Dapper.FluentMap.Dommel.Mapping;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Dados
{
    public class ArquivoMap : DommelEntityMap<Arquivo>
    {
        public ArquivoMap()
        {
            ToTable("arquivo");
            
            Map(c => c.Id).ToColumn("id").IsKey();
            
            Map(c => c.LegadoId).ToColumn("legado_id");
            Map(c => c.Caminho).ToColumn("caminho");
            Map(c => c.TamanhoBytes).ToColumn("tamanho_bytes");
        }
    }
}

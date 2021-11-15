using Dapper.FluentMap.Dommel.Mapping;

namespace SME.SERAp.Prova.Dados
{
    public class ContextoProvaMap : DommelEntityMap<Dominio.ContextoProva>
    {
        public ContextoProvaMap()
        {
            ToTable("contexto_prova");

            Map(c => c.Id).ToColumn("id").IsKey();

            Map(c => c.ProvaId).ToColumn("prova_id");
            Map(c => c.Imagem).ToColumn("imagem");
            Map(c => c.Ordem).ToColumn("ordem");
            Map(c => c.Posicionamento).ToColumn("posicionamento");
            Map(c => c.Texto).ToColumn("texto");
            Map(c => c.Titulo).ToColumn("titulo");
        }
    }
}

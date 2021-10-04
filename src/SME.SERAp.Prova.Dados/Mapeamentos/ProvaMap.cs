using Dapper.FluentMap.Dommel.Mapping;

namespace SME.SERAp.Prova.Dados
{
    public class ProvaMap : DommelEntityMap<Dominio.Prova>
    {
        public ProvaMap()
        {
            ToTable("prova");
            
            Map(c => c.Id).ToColumn("id").IsKey();
            
            Map(c => c.LegadoId).ToColumn("prova_legado_id");
            Map(c => c.Descricao).ToColumn("descricao");
            Map(c => c.Inicio).ToColumn("inicio");
            Map(c => c.Fim).ToColumn("fim");
            Map(c => c.Inclusao).ToColumn("inclusao");
            Map(c => c.TotalItens).ToColumn("total_itens");
            Map(c => c.TempoExecucao).ToColumn("tempo_execucao");
        }
    }
}

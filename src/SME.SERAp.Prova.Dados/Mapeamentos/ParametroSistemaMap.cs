using Dapper.FluentMap.Dommel.Mapping;

namespace SME.SERAp.Prova.Dados
{
    public class ParametroSistemaMap : DommelEntityMap<Dominio.ParametroSistema>
    {
        public ParametroSistemaMap()
        {
            ToTable("parametro_sistema");
            
            Map(c => c.Id).ToColumn("id").IsKey();
            Map(c => c.Ano).ToColumn("ano");
            Map(c => c.Descricao).ToColumn("descricao");
            Map(c => c.Ativo).ToColumn("ativo");
            Map(c => c.Nome).ToColumn("nome");
            Map(c => c.Tipo).ToColumn("tipo");
            Map(c => c.Valor).ToColumn("valor");
        }
    }
}

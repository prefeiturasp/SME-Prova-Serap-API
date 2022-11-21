using Dapper.FluentMap.Dommel.Mapping;

namespace SME.SERAp.Prova.Dados
{
    public class AlternativasMap : DommelEntityMap<Dominio.Alternativa>
    {
        public AlternativasMap()
        {
            ToTable("alternativa");
            
            Map(c => c.Id).ToColumn("id").IsKey();
            
            Map(c => c.Descricao).ToColumn("descricao");
            Map(c => c.Ordem).ToColumn("ordem");
            Map(c => c.Numeracao).ToColumn("numeracao");
            Map(c => c.QuestaoId).ToColumn("questao_id");
            Map(c => c.Correta).ToColumn("correta");
        }
    }
}

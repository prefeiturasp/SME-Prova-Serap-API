using Dapper.FluentMap.Dommel.Mapping;

namespace SME.SERAp.Prova.Dados
{
    public class QuestaoMap : DommelEntityMap<Dominio.Questao>
    {
        public QuestaoMap()
        {
            ToTable("questao");
            
            Map(c => c.Id).ToColumn("id").IsKey();
            
            Map(c => c.Titulo).ToColumn("titulo");
            Map(c => c.QuestaoLegadoId).ToColumn("questao_legado_id");
            Map(c => c.Descricao).ToColumn("descricao");
            Map(c => c.Ordem).ToColumn("ordem");
            Map(c => c.ProvaId).ToColumn("prova_id");
            Map(c => c.Caderno).ToColumn("caderno");
            Map(c => c.QuantidadeAlternativas).ToColumn("quantidade_alternativas");
        }
    }
}

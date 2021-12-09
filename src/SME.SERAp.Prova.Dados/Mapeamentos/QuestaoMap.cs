using Dapper.FluentMap.Dommel.Mapping;

namespace SME.SERAp.Prova.Dados
{
    public class QuestaoMap : DommelEntityMap<Dominio.Questao>
    {
        public QuestaoMap()
        {
            ToTable("questao");
            
            Map(c => c.Id).ToColumn("id").IsKey();
            
            Map(c => c.TextoBase).ToColumn("texto_base");
            Map(c => c.QuestaoLegadoId).ToColumn("questao_legado_id");
            Map(c => c.Enunciado).ToColumn("enunciado");
            Map(c => c.Ordem).ToColumn("ordem");
            Map(c => c.ProvaId).ToColumn("prova_id");
            Map(c => c.Caderno).ToColumn("caderno");
            Map(c => c.QuantidadeAlternativas).ToColumn("quantidade_alternativas");
        }
    }
}

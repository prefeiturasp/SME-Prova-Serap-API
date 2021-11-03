using Dapper.FluentMap.Dommel.Mapping;

namespace SME.SERAp.Prova.Dados
{
    public class QuestaoArquivoMap : DommelEntityMap<Dominio.QuestaoArquivo>
    {
        public QuestaoArquivoMap()
        {
            ToTable("questao_arquivo");
            
            Map(c => c.Id).ToColumn("id").IsKey();
            
            Map(c => c.QuestaoId).ToColumn("questao_id");
            Map(c => c.ArquivoId).ToColumn("arquivo_id");
        }
    }
}

using Dapper.FluentMap.Dommel.Mapping;

namespace SME.SERAp.Prova.Dados
{
    public class QuestaoVideoMap : DommelEntityMap<Dominio.QuestaoVideo>
    {
        public QuestaoVideoMap()
        {
            ToTable("questao_video");

            Map(c => c.Id).ToColumn("id").IsKey();

            Map(c => c.QuestaoId).ToColumn("questao_id");
            Map(c => c.ArquivoVideoId).ToColumn("arquivo_video_id");
            Map(c => c.ArquivoThumbnailId).ToColumn("arquivo_thumbnail_id");
            Map(c => c.ArquivoVideoConvertidoId).ToColumn("arquivo_video_convertido_id");
            Map(c => c.CriadoEm).ToColumn("criado_em");
            Map(c => c.AtualizadoEm).ToColumn("atualizado_em");
        }
    }
}

using Dapper.FluentMap.Dommel.Mapping;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Dados
{
    public class ExportacaoResultadoMap : DommelEntityMap<ExportacaoResultado>
    {
        public ExportacaoResultadoMap()
        {
            ToTable("exportacao_resultado");
            
            Map(c => c.Id).ToColumn("id").IsKey();
            
            Map(c => c.AtualizadoEm).ToColumn("atualizado_em");
            Map(c => c.CriadoEm).ToColumn("criado_em");
            Map(c => c.NomeArquivo).ToColumn("nome_arquivo");
            Map(c => c.Status).ToColumn("status");
            Map(c => c.ProvaSerapId).ToColumn("prova_serap_id");
        }
    }
}

using Dapper.FluentMap.Dommel.Mapping;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Dados
{
    public class TipoDeficienciaMap : DommelEntityMap<TipoDeficiencia>
    {
        public TipoDeficienciaMap()
        {
            ToTable("tipo_deficiencia");

            Map(c => c.Id).ToColumn("id").IsKey();

            Map(c => c.LegadoId).ToColumn("legado_id");
            Map(c => c.CodigoEol).ToColumn("codigo_eol");
            Map(c => c.Nome).ToColumn("nome");
            Map(c => c.CriadoEm).ToColumn("criado_em");
            Map(c => c.AtualizadoEm).ToColumn("atualizado_em");
        }
    }
}

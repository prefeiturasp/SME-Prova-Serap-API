using Dapper.FluentMap.Dommel.Mapping;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Dados
{
    public class TurmaMap : DommelEntityMap<Turma>
    {
        public TurmaMap()
        {
            ToTable("turma");

            Map(c => c.Id).ToColumn("id").IsKey();

            Map(c => c.Ano).ToColumn("ano");
            Map(c => c.AnoLetivo).ToColumn("ano_letivo");
            Map(c => c.TipoTurma).ToColumn("tipo_turma");
            Map(c => c.Modalidade).ToColumn("modalidade_codigo");
            Map(c => c.TipoTurno).ToColumn("tipo_turno");
        }
    }
}

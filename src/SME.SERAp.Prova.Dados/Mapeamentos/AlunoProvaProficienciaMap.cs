using Dapper.FluentMap.Dommel.Mapping;

namespace SME.SERAp.Prova.Dados
{
    public class AlunoProvaProficienciaMap : DommelEntityMap<Dominio.AlunoProvaProficiencia>
    {
        public AlunoProvaProficienciaMap()
        {
            ToTable("aluno_prova_proficiencia");

            Map(c => c.Id).ToColumn("id").IsKey();

            Map(c => c.AlunoId).ToColumn("aluno_id");
            Map(c => c.Ra).ToColumn("ra");
            Map(c => c.ProvaId).ToColumn("prova_id");
            Map(c => c.DisciplinaId).ToColumn("disciplina_id");
            Map(c => c.Proficiencia).ToColumn("proficiencia");
            Map(c => c.Tipo).ToColumn("tipo");
            Map(c => c.Origem).ToColumn("origem");
            Map(c => c.UltimaAtualizacao).ToColumn("ultima_atualizacao");
        }
    }
}

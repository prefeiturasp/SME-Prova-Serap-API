using Dapper.FluentMap.Dommel.Mapping;

namespace SME.SERAp.Prova.Dados
{
    public class CadernoAlunoMap : DommelEntityMap<Dominio.CadernoAluno>
    {
        public CadernoAlunoMap()
        {
            ToTable("caderno_aluno");

            Map(c => c.Id).ToColumn("id").IsKey();

            Map(c => c.ProvaId).ToColumn("prova_id");
            Map(c => c.AlunoId).ToColumn("aluno_id");
            Map(c => c.Caderno).ToColumn("caderno");
        }
    }
}

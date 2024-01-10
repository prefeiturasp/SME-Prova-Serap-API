using Dapper.FluentMap.Dommel.Mapping;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Dados
{
    public class QuestaoAlunoTaiMap : DommelEntityMap<QuestaoAlunoTai>
    {
        public QuestaoAlunoTaiMap()
        {
            ToTable("questao_aluno_tai");
            Map(c => c.Id).ToColumn("id").IsKey();
            Map(c => c.QuestaoId).ToColumn("questao_id");
            Map(c => c.AlunoId).ToColumn("aluno_id");
            Map(c => c.Ordem).ToColumn("ordem");
            Map(c => c.CriadoEm).ToColumn("criado_em");            
        }
    }
}
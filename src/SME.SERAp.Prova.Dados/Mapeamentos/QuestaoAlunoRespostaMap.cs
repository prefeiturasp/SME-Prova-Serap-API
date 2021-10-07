using Dapper.FluentMap.Dommel.Mapping;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Dados
{
    public class QuestaoAlunoRespostaMap : DommelEntityMap<QuestaoAlunoResposta>
    {
        public QuestaoAlunoRespostaMap()
        {
            ToTable("questao_aluno_resposta");

            Map(c => c.Id).ToColumn("id").IsKey();

            Map(c => c.Resposta).ToColumn("resposta");
            Map(c => c.AlunoRa).ToColumn("aluno_ra");
            Map(c => c.QuestaoId).ToColumn("questao_id");
            Map(c => c.AlternativaId).ToColumn("alternativa_id");
            Map(c => c.CriadoEm).ToColumn("criado_em");
            Map(c => c.TempoRespostaAluno).ToColumn("tempo_resposta_aluno");
            Map(c => c.Tentativas).ToColumn("tentativas");
        }
    }
}

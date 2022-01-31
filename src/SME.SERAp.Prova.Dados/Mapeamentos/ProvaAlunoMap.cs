using Dapper.FluentMap.Dommel.Mapping;

namespace SME.SERAp.Prova.Dados
{
    public class ProvaAlunoMap : DommelEntityMap<Dominio.ProvaAluno>
    {
        public ProvaAlunoMap()
        {
            ToTable("prova_aluno");
            
            Map(c => c.Id).ToColumn("id").IsKey();
            Map(c => c.ProvaId).ToColumn("prova_id");
            Map(c => c.AlunoRA).ToColumn("aluno_ra");
            Map(c => c.Status).ToColumn("status");
            Map(c => c.CriadoEm).ToColumn("criado_em");
            Map(c => c.Frequencia).ToColumn("frequencia");
            Map(c => c.TipoDispositivo).ToColumn("tipo_dispositivo");
            Map(c => c.FinalizadoEm).ToColumn("finalizado_em");
        }
    }
}

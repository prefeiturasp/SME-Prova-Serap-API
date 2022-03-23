using Dapper.FluentMap.Dommel.Mapping;

namespace SME.SERAp.Prova.Dados
{
    public class UsuarioSerapCoreSSOMap : DommelEntityMap<Dominio.UsuarioSerapCoreSSO>
    {
        public UsuarioSerapCoreSSOMap()
        {
            ToTable("usuario_serap_coresso");
            Map(c => c.Id).ToColumn("id").IsKey();
            Map(c => c.IdCoreSSO).ToColumn("id_coresso").IsKey();
            Map(c => c.Login).ToColumn("login");
            Map(c => c.Nome).ToColumn("nome");
            Map(c => c.CriadoEm).ToColumn("criado_em");
            Map(c => c.AtualizadoEm).ToColumn("atualizado_em");
        }
    }
}

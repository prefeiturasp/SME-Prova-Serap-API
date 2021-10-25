using Dapper.FluentMap.Dommel.Mapping;

namespace SME.SERAp.Prova.Dados
{
    public class UsuarioMap : DommelEntityMap<Dominio.Usuario>
    {
        public UsuarioMap()
        {
            ToTable("usuario");            
            Map(c => c.Id).ToColumn("id").IsKey();
            Map(c => c.Nome).ToColumn("nome");
            Map(c => c.Login).ToColumn("login");
            Map(c => c.UltimoLogin).ToColumn("ultimo_login");
            Map(c => c.CriadoEm).ToColumn("criado_em");
        }
    }
}

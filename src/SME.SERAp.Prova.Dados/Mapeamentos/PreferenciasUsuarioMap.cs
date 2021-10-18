using Dapper.FluentMap.Dommel.Mapping;

namespace SME.SERAp.Prova.Dados
{
    public class PreferenciasUsuarioMap : DommelEntityMap<Dominio.PreferenciasUsuario>
    {
        public PreferenciasUsuarioMap()
        {
            ToTable("preferencias_usuario");            
            Map(c => c.Id).ToColumn("id").IsKey();
            Map(c => c.UsuarioId).ToColumn("usuario_id");
            Map(c => c.TamanhoFonte).ToColumn("tamanho_fonte");
        }
    }
}

using Dapper.FluentMap.Dommel.Mapping;

namespace SME.SERAp.Prova.Dados
{
    public class UsuarioDispositivoMap : DommelEntityMap<Dominio.UsuarioDispositivo>
    {
        public UsuarioDispositivoMap()
        {
            ToTable("usuario_dispositivo");
            
            Map(c => c.Id).ToColumn("id").IsKey();
            
            Map(c => c.Ra).ToColumn("ra");
            Map(c => c.DispositivoId).ToColumn("dispositivo_id");
            Map(c => c.Ano).ToColumn("ano");
            Map(c => c.CriadoEm).ToColumn("criado_em");

        }
    }
}

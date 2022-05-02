using Dapper.FluentMap.Dommel.Mapping;

namespace SME.SERAp.Prova.Dados
{
    public  class VersaoAppDispositivoMap : DommelEntityMap<Dominio.VersaoAppDispositivo>
    {
        public VersaoAppDispositivoMap()
        {
            ToTable("versao_app_dispositivo");
            Map(c => c.Id).ToColumn("id").IsKey();
            Map(c => c.VersaoCodigo).ToColumn("codigo_versao");
            Map(c => c.VersaoDescricao).ToColumn("descricao_versao");
            Map(c => c.DispositivoImei).ToColumn("dispositivo_imei");
            Map(c => c.AtualizadoEm).ToColumn("atualizado_em");
            Map(c => c.CriadoEm).ToColumn("criado_em");
        }
    }
}

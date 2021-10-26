using Dapper.FluentMap.Dommel.Mapping;

namespace SME.SERAp.Prova.Dados
{
    public class TelaBoasVindasMap : DommelEntityMap<Dominio.TelaBoasVindas>
    {
        public TelaBoasVindasMap()
        {
            ToTable("configuracao_tela_boas_vindas");

            Map(c => c.Id).ToColumn("id").IsKey();

            Map(c => c.Titulo).ToColumn("titulo");
            Map(c => c.Descricao).ToColumn("descricao");
            Map(c => c.Imagem).ToColumn("imagem");
            Map(c => c.Ordem).ToColumn("ordem");
            Map(c => c.Ativo).ToColumn("ativo");
        }
    }
}

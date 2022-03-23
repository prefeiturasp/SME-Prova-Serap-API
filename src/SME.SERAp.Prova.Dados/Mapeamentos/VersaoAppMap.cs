using Dapper.FluentMap.Dommel.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
  public  class VersaoAppMap : DommelEntityMap<Dominio.VersaoApp>
    {
        public VersaoAppMap()
        {
            ToTable("versao_app");
            Map(c => c.Id).ToColumn("id").IsKey();
            Map(c => c.Codigo).ToColumn("codigo_versao");
            Map(c => c.Descricao).ToColumn("descricao_versao");
            Map(c => c.Mensagem).ToColumn("mensagem");
            Map(c => c.CriadoEm).ToColumn("criado_em");
            Map(c => c.AlteradoEm).ToColumn("alterado_em");
            Map(c => c.SuporteMinimo).ToColumn("suporte_minimo");
            Map(c => c.Url).ToColumn("url");
          
        }
    }
}

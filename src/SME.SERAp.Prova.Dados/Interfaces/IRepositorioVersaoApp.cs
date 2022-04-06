
using SME.SERAp.Prova.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
   public interface IRepositorioVersaoApp : IRepositorioBase<VersaoApp>
    {
         Task<VersaoApp> ObterUltimaVersao();
    }
}

using SME.SERAp.Prova.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
   public interface IRepositorioDownloadProvaAluno :IRepositorioBase<DownloadProvaAluno>
    {
        public  Task<bool> ExcluirDownloadProvaAluno(int[] ids, DateTime? dataAlteracao);
    }
}

using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public interface IIncluirDownloadProvaAlunoUseCase 
    {
        Task<bool> Executar(long provaId, DownloadProvaAlunoDto downloadProvaAlunoDto);
    }
}

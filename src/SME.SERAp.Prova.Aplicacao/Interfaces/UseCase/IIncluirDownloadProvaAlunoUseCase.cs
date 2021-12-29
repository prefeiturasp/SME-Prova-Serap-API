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
        Task<long> Executar(DownloadProvaAlunoDto downloadProvaAlunoDto);
    }
}

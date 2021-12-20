using SME.SERAp.Prova.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Infra.Utils
{
    public static class UtilAluno
    {
        public static string AjustarAnoAluno(string modalidade, string ano)
        {
            if (ano.ToUpper() == "S" || String.IsNullOrEmpty(ano))
                return ano;

            var modalidadeAluno = (Modalidade)int.Parse(modalidade);
            if ((modalidadeAluno == Modalidade.EJA && ano != "2") || modalidadeAluno == Modalidade.CIEJA)
                return (int.Parse(ano) * 2).ToString();
            return ano;
        }
    }
}

using MediatR;
using SME.SERAp.Prova.Dominio;
using System.Collections.Generic;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterParametroSistemaPorTiposEAnoQuery : IRequest<IEnumerable<ParametroSistema>>
    {
        public ObterParametroSistemaPorTiposEAnoQuery(int[] tipos, int ano)
        {
            Tipos = tipos;
            Ano = ano;
        }

        public int[] Tipos { get; set; }
        public int Ano { get; set; }
    }
}

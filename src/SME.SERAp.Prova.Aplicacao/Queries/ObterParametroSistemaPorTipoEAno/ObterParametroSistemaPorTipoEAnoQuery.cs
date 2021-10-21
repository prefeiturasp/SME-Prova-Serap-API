using MediatR;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterParametroSistemaPorTipoEAnoQuery : IRequest<ParametroSistema>
    {
        public ObterParametroSistemaPorTipoEAnoQuery(TipoParametroSistema tipo, int ano)
        {
            Tipo = tipo;
            Ano = ano;
        }

        public TipoParametroSistema Tipo { get; set; }
        public int Ano { get; set; }
    }
}

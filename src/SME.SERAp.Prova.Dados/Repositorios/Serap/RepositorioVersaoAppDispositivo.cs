using SME.SERAp.Prova.Dados.Interfaces;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioVersaoAppDispositivo : RepositorioBase<VersaoAppDispositivo>, IRepositorioVersaoAppDispositivo
    {
        public RepositorioVersaoAppDispositivo(ConnectionStringOptions connectionStrings) : base(connectionStrings)
        {
        }
    }
}

using Dapper;
using SME.SERAp.Prova.Dados.Interfaces;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados
{
    public class RepositorioPreferenciasUsuario : RepositorioBase<PreferenciasUsuario>, IRepositorioPreferenciasUsuario
    {
        public RepositorioPreferenciasUsuario(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {
        }
    }
}
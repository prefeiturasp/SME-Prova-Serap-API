using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.EnvironmentVariables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Dados.Repositorios.Serap
{
    public class RepositorioDownloadProvaAluno : RepositorioBase<DownloadProvaAluno>, IRepositorioDownloadProvaAluno
    {
        public RepositorioDownloadProvaAluno(ConnectionStringOptions connectionStringOptions) : base(connectionStringOptions)
        {
            
        }
    }
}

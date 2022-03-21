using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterUltimaVersaoAppQueryHandler : IRequestHandler<ObterUltimaVersaoAppQuery, VersaoApp>
    {
        private readonly IRepositorioVersaoApp repositorioVersaoApp;

        public ObterUltimaVersaoAppQueryHandler(IRepositorioVersaoApp repositorioVersaoApp)
        {
            this.repositorioVersaoApp = repositorioVersaoApp ?? throw new System.ArgumentNullException(nameof(repositorioVersaoApp));
        }
        public Task<VersaoApp> Handle(ObterUltimaVersaoAppQuery request, CancellationToken cancellationToken)
        {
            return repositorioVersaoApp.ObterUltimaVersao();
        }
    }
}

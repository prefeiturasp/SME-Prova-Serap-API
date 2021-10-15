using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterConfiguracaoTelasBoasVindasQueryHandler : IRequestHandler<ObterConfiguracaoTelasBoasVindasQuery, IEnumerable<TelaBoasVindas>>
    {
        private readonly IRepositorioTelaBoasVindas repositorioTelaBoasVindas;

        public ObterConfiguracaoTelasBoasVindasQueryHandler(IRepositorioTelaBoasVindas repositorioTelaBoasVindas)
        {
            this.repositorioTelaBoasVindas = repositorioTelaBoasVindas ?? throw new System.ArgumentNullException(nameof(repositorioTelaBoasVindas));
        }
        public async Task<IEnumerable<TelaBoasVindas>> Handle(ObterConfiguracaoTelasBoasVindasQuery request, CancellationToken cancellationToken)
            => await repositorioTelaBoasVindas.ObterAtivosAsync();
    }
}

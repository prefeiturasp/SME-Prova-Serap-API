using MediatR;
using SME.SERAp.Prova.Dados;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class VerificaProvaExistePorSerapIdQueryHandler : IRequestHandler<VerificaProvaExistePorSerapIdQuery, bool>
    {
        private readonly IRepositorioProva repositorioProva;

        public VerificaProvaExistePorSerapIdQueryHandler(IRepositorioProva repositorioProva)
        {
            this.repositorioProva = repositorioProva ?? throw new ArgumentNullException(nameof(repositorioProva));
        }
        public async Task<bool> Handle(VerificaProvaExistePorSerapIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProva.VerificaSeExistePorProvaSerapId(request.ProvaId);
        }
    }
}

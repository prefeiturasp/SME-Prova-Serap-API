using MediatR;
using SME.SERAp.Prova.Dados.Interfaces;
using SME.SERAp.Prova.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    internal class ObterArquivoResultadoPspPorIdQueryHandler : IRequestHandler<ObterArquivoResultadoPspPorIdQuery, ArquivoResultadoPspDto>
    {

        private readonly IRepositorioArquivoResultadoPsp repositorioArquivoResultadoPsp;

        public ObterArquivoResultadoPspPorIdQueryHandler(IRepositorioArquivoResultadoPsp repositorioArquivoResultadoPsp)
        {
            this.repositorioArquivoResultadoPsp = repositorioArquivoResultadoPsp ?? throw new System.ArgumentNullException(nameof(repositorioArquivoResultadoPsp));
        }

        public async Task<ArquivoResultadoPspDto> Handle(ObterArquivoResultadoPspPorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioArquivoResultadoPsp.ObterArquivoResultadoPspPorId(request.Id);
        }
    }
}
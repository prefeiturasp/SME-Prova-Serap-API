using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterAlunoAtivoEolQueryHandler : IRequestHandler<ObterAlunoAtivoEolQuery, ObterAlunoAtivoEolRetornoDto>
    {
        private readonly IRepositorioAlunoEol repositorioAlunoEol;

        public ObterAlunoAtivoEolQueryHandler(IRepositorioAlunoEol repositorioAlunoEol)
        {
            this.repositorioAlunoEol = repositorioAlunoEol ?? throw new System.ArgumentNullException(nameof(repositorioAlunoEol));
        }
        public async Task<ObterAlunoAtivoEolRetornoDto> Handle(ObterAlunoAtivoEolQuery request, CancellationToken cancellationToken)
        {
            return await repositorioAlunoEol.ObterAlunoAtivoAsync(request.AlunoRA);
        }
    }
}

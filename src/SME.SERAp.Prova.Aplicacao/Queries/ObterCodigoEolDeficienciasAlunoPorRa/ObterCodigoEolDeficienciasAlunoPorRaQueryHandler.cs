using MediatR;
using SME.SERAp.Prova.Dados;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterCodigoEolDeficienciasAlunoPorRaQueryHandler : IRequestHandler<ObterCodigoEolDeficienciasAlunoPorRaQuery, List<int>>
    {

        private readonly IRepositorioTipoDeficiencia repositorioTipoDeficiencia;

        public ObterCodigoEolDeficienciasAlunoPorRaQueryHandler(IRepositorioTipoDeficiencia repositorioTipoDeficiencia)
        {
            this.repositorioTipoDeficiencia = repositorioTipoDeficiencia ?? throw new System.ArgumentNullException(nameof(repositorioTipoDeficiencia));
        }

        public async Task<List<int>> Handle(ObterCodigoEolDeficienciasAlunoPorRaQuery request, CancellationToken cancellationToken)
        {
            var deficienciasAluno = await repositorioTipoDeficiencia.ObterPorAlunoRa(request.AlunoRa);
            return deficienciasAluno.Select(d => d.CodigoEol).ToList();
        }
    }
}

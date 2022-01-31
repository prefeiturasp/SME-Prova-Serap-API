using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class VerificaAlunoProvaComAudioPorRaQueryHandler : IRequestHandler<VerificaAlunoProvaComAudioPorRaQuery, bool>
    {
        
        private readonly IRepositorioTipoDeficiencia repositorioTipoDeficiencia;

        public VerificaAlunoProvaComAudioPorRaQueryHandler(IRepositorioTipoDeficiencia repositorioTipoDeficiencia)
        {
            this.repositorioTipoDeficiencia = repositorioTipoDeficiencia ?? throw new System.ArgumentNullException(nameof(repositorioTipoDeficiencia));
        }

        public async Task<bool> Handle(VerificaAlunoProvaComAudioPorRaQuery request, CancellationToken cancellationToken)
        {
            var deficienciasAluno = await repositorioTipoDeficiencia.ObterPorAlunoRa(request.AlunoRa);
            return deficienciasAluno.Any(a => a.CodigoEol == (int)DeficienciaTipo.BAIXA_VISAO_OU_SUBNORMAL || a.CodigoEol == (int)DeficienciaTipo.CEGUEIRA);
        }
    }
}

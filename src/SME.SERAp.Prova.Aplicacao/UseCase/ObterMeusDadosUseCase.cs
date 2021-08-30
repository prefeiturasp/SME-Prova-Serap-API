using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterMeusDadosUseCase : IObterMeusDadosUseCase
    {
        private readonly IMediator mediator;

        public ObterMeusDadosUseCase(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<MeusDadosRetornoDto> Executar()
        {
            var usuarioLogadoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());
            var alunoDetalhes = await mediator.Send(new ObterAlunoDadosPorRaQuery(long.Parse(usuarioLogadoRa)));

            if (alunoDetalhes != null)
            {
                var anoUsuarioLogado = await mediator.Send(new ObterUsuarioLogadoInformacaoPorClaimQuery("ANO"));

                return new MeusDadosRetornoDto(alunoDetalhes.NomeFinal(), anoUsuarioLogado);
            }
            else throw new NegocioException($"Não foi possível localizar os dados do aluno {usuarioLogadoRa}");
        }
    }
}

using MediatR;
using SME.SERAp.Prova.Dados;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterDetalhesAlunoCacheQueryHandler : IRequestHandler<ObterDetalhesAlunoCacheQuery, MeusDadosRetornoDto>
    {
        private readonly IRepositorioCache repositorioCache;
        private readonly IMediator mediator;

        public ObterDetalhesAlunoCacheQueryHandler(IRepositorioCache repositorioCache, IMediator mediator)
        {
            this.repositorioCache = repositorioCache ?? throw new System.ArgumentNullException(nameof(repositorioCache));
            this.mediator = mediator ?? throw new System.ArgumentNullException(nameof(mediator));
        }
        public async Task<MeusDadosRetornoDto> Handle(ObterDetalhesAlunoCacheQuery request, CancellationToken cancellationToken)
        {
            return await repositorioCache.ObterRedisAsync($"ra-{request.AlunoRA}", async () => await ObterDetalhesAsync(request.AlunoRA));
        }

        private async Task<MeusDadosRetornoDto> ObterDetalhesAsync(long usuarioLogadoRa)
        {
            var alunoDetalhes = await mediator.Send(new ObterAlunoDadosPorRaQuery(usuarioLogadoRa));
            if (alunoDetalhes != null)
            {
                var anoUsuarioLogado = await mediator.Send(new ObterUsuarioLogadoInformacaoPorClaimQuery("ANO"));
                var turnoUsuarioLogado =
                    await mediator.Send(new ObterUsuarioLogadoInformacaoPorClaimQuery("TIPOTURNO"));

                var modalidadeUsuarioLogado =
                    await mediator.Send(new ObterUsuarioLogadoInformacaoPorClaimQuery("MODALIDADE"));

                var preferenciasUsuario =
                    await mediator.Send(new ObterPreferenciasUsuarioPorLoginQuery(usuarioLogadoRa));

                var turnoInicio = await mediator.Send(new ObterParametroSistemaPorTipoEAnoQuery(TipoParametroSistemaExtension.ObterParametroTurnoInicio(turnoUsuarioLogado), DateTime.Now.Year));
                var turnoFim = await mediator.Send(new ObterParametroSistemaPorTipoEAnoQuery(TipoParametroSistemaExtension.ObterParametroTurnoFim(turnoUsuarioLogado), DateTime.Now.Year));

                var deficienciasAluno = await mediator.Send(new ObterCodigoEolDeficienciasAlunoPorRaQuery(usuarioLogadoRa));

                return new MeusDadosRetornoDto(alunoDetalhes.NomeFinal(), anoUsuarioLogado, turnoUsuarioLogado,
                    preferenciasUsuario?.TamanhoFonte ?? 16,
                    preferenciasUsuario != null
                        ? (int)preferenciasUsuario.FamiliaFonte
                        : (int)FamiliaFonte.Poppins, 
                    (Modalidade)Enum.Parse(typeof(Modalidade), modalidadeUsuarioLogado),
                    turnoInicio != null ? int.Parse(turnoInicio.Valor) : 0,
                    turnoFim != null ? int.Parse(turnoFim.Valor) : 0,
                    deficienciasAluno != null ? deficienciasAluno.ToArray() : Array.Empty<int>());
            }
            else return null;
        }
    }
}

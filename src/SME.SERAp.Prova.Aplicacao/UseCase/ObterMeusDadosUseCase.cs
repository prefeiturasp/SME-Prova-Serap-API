using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System.Threading.Tasks;
using SME.SERAp.Prova.Dominio;
using System;

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

                return new MeusDadosRetornoDto(alunoDetalhes.NomeFinal(), anoUsuarioLogado, turnoUsuarioLogado,
                    preferenciasUsuario?.TamanhoFonte ?? 16,
                    preferenciasUsuario != null
                        ? (int) preferenciasUsuario.FamiliaFonte
                        : (int) FamiliaFonte.Poppins, (Modalidade)Enum.Parse(typeof(Modalidade), modalidadeUsuarioLogado), int.Parse(turnoInicio.Valor), int.Parse(turnoFim.Valor));
            }
            else throw new NegocioException($"Não foi possível localizar os dados do aluno {usuarioLogadoRa}");
        }
    }
}
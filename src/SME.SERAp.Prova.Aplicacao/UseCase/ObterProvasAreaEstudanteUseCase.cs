using MediatR;
using Sentry;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasAreaEstudanteUseCase : IObterProvasAreaEstudanteUseCase
    {
        private readonly IMediator mediator;

        public ObterProvasAreaEstudanteUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<IEnumerable<ObterProvasRetornoDto>> Executar()
        {
            var alunoLogadoAno = await mediator.Send(new ObterUsuarioLogadoInformacaoPorClaimQuery("ANO"));
            if (string.IsNullOrEmpty(alunoLogadoAno))
                throw new NegocioException("Ano do aluno logado não localizado");

            var alunoLogadoTurno = await mediator.Send(new ObterUsuarioLogadoInformacaoPorClaimQuery("TIPOTURNO"));
            if (string.IsNullOrEmpty(alunoLogadoTurno))
                throw new NegocioException("Turno do aluno logado não localizado");

            var provas = await mediator.Send(new ObterProvasPorAnoQuery(int.Parse(alunoLogadoAno), DateTime.Today));
            if (provas.Any())
            {
                var alunoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());

                var provasParaRetornar = new List<ObterProvasRetornoDto>();

                foreach (var prova in provas)
                {
                    var provaAluno = await mediator.Send(new ObterProvaAlunoPorProvaIdRaQuery(prova.Id, alunoRa));

                    if (provaAluno != null && provaAluno.Status == ProvaStatus.Finalizado)
                        continue;

                    ProvaStatus status = ProvaStatus.NaoIniciado;
                    if (provaAluno != null)
                        status = provaAluno.Status;

                    provasParaRetornar.Add(new ObterProvasRetornoDto(prova.Descricao, prova.TotalItens, (int)status, prova.Inicio, prova.Fim, prova.Id, prova.TempoExecucao));
                }

                return provasParaRetornar;
            }
            else return default;
        }
    }
}

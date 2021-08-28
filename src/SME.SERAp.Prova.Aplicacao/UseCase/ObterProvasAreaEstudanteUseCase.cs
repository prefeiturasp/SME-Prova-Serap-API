using MediatR;
using Sentry;
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
                        
            var provas = await mediator.Send(new ObterProvasPorAnoQuery(1, DateTime.Today));
            if (provas.Any())
            {
                var provasParaRetornar = new List<ObterProvasRetornoDto>();

                foreach (var prova in provas)
                {
                    provasParaRetornar.Add(new ObterProvasRetornoDto(prova.Descricao, prova.TotalItens, prova.Inicio, prova.Fim, prova.Id));
                }

                return provasParaRetornar;
            }
            else return default;
        }
    }
}

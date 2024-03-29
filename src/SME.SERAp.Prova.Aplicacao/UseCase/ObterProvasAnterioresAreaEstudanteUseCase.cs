﻿using MediatR;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterProvasAnterioresAreaEstudanteUseCase : IObterProvasAnterioresAreaEstudanteUseCase
    {
        private readonly IMediator mediator;
        public ObterProvasAnterioresAreaEstudanteUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<IEnumerable<ObterProvasAnterioresRetornoDto>> Executar()
        {
            var alunoRa = await mediator.Send(new ObterRAUsuarioLogadoQuery());
            if (alunoRa == 0)
                throw new NegocioException("Não foi possível obter o RA do usuário logado.");

            var provas = await mediator.Send(new ObterProvasAnterioresAlunoPorRaQuery(alunoRa));

            if (provas != null)
            {
                return MapearParaDto(provas);
            }

            return default;
        }

        private static IEnumerable<ObterProvasAnterioresRetornoDto> MapearParaDto(IEnumerable<ProvaAlunoAnoDto> provasAluno)
        {
            return provasAluno.Select(a => new ObterProvasAnterioresRetornoDto
            {
                Id = a.Id,
                Descricao = a.Descricao,
                ItensQuantidade = a.TotalItens,
                TempoTotal = 0,
                Status = a.Status,
                DataInicio = a.Inicio,
                DataFim = a.Fim,
                DataInicioProvaAluno = a.DataInicioProvaAluno,
                DataFimProvaAluno = a.DataFimProvaAluno,
            });
        }
    }
}

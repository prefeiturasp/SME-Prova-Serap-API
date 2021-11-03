﻿using MediatR;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading.Tasks;

namespace SME.SERAp.Prova.Aplicacao
{
    public class ObterArquivoPorIdUseCase : IObterArquivoPorIdUseCase
    {
        private readonly IMediator mediator;

        public ObterArquivoPorIdUseCase(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<ArquivoRetornoDto> Executar(long id)
        {
            var arquivo = await mediator.Send(new ObterArquivoPorIdQuery(id));

            if (arquivo == null)
                throw new NegocioException("O Arquivo não foi encontrado");

            var questaoArquivo = await mediator.Send(new ObterQuestaoArquivoPorArquivoIdQuery(arquivo.Id));

            if (questaoArquivo == null)
                throw new NegocioException("O Arquivo da Questão não foi encontrado");

            return new ArquivoRetornoDto(arquivo.Id, arquivo.Caminho, questaoArquivo.QuestaoId);
        }

    }
}

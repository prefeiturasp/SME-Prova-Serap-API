using MediatR;
using Moq;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.Questao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.SERAp.Aplicacao.Test.UseCase
{
    public class ObterProvaTaiResultadoResumoUseCaseTeste
    {
        [Fact]
        public void Construtor_Deve_Lancar_Argument_Null_Exception_Quando_Mediator_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => new ObterProvaTaiResultadoResumoUseCase(null));
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Resumo_Ordenado_Por_Ordem_Administrada()
        {
            var contexto = CriarContextoPadrao();

            var resultado = (await contexto.UseCase.Executar(contexto.ProvaId)).ToList();

            Assert.Equal(2, resultado.Count);
            Assert.Equal("Q2", resultado[0].DescricaoQuestao);
            Assert.Equal(1, resultado[0].OrdemQuestao);
            Assert.Equal("B", resultado[0].AlternativaAluno);

            Assert.Equal("Q1", resultado[1].DescricaoQuestao);
            Assert.Equal(2, resultado[1].OrdemQuestao);
            Assert.Equal("A", resultado[1].AlternativaAluno);
        }

        [Fact]
        public async Task Executar_Deve_Desconsiderar_Resposta_Sem_AlternativaResposta()
        {
            var contexto = CriarContextoPadrao();
            contexto.AlunoRespostas[0].AlternativaResposta = null;

            var resultado = (await contexto.UseCase.Executar(contexto.ProvaId)).ToList();

            Assert.Single(resultado);
            Assert.Equal("Q2", resultado[0].DescricaoQuestao);
            contexto.MediatorMock.Verify(m => m.Send(It.IsAny<ObterAlternativaPorIdQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Desconsiderar_Quando_Questao_Nao_Esta_No_Administrado()
        {
            var contexto = CriarContextoPadrao();
            contexto.QuestoesAdministrado.RemoveAll(q => q.Id == 10);

            var resultado = (await contexto.UseCase.Executar(contexto.ProvaId)).ToList();

            Assert.Single(resultado);
            Assert.Equal("Q2", resultado[0].DescricaoQuestao);
        }

        private static TesteContexto CriarContextoPadrao()
        {
            const long provaId = 1;
            const long ra = 123;
            const long alunoId = 456;

            var questoesAluno = new List<QuestaoTaiDto>
            {
                new() { Id = 10, Ordem = 0 },
                new() { Id = 20, Ordem = 0 }
            };

            var alunoRespostas = new List<QuestaoAlternativaAlunoRespostaDto>
            {
                new() { QuestaoId = 10, AlternativaResposta = 1001 },
                new() { QuestaoId = 20, AlternativaResposta = 2001 }
            };

            var dados = new MeusDadosRetornoDto(alunoId, "DRE", "Escola", "Turma", "Nome", "5", "M", 12, Modalidade.Fundamental, 1, 7, 12, Array.Empty<int>());

            var questoesAdministrado = new List<QuestaoTaiDto>
            {
                new() { Id = 20, Ordem = 0 },
                new() { Id = 10, Ordem = 1 }
            };

            var jsonQ1 = JsonSerializer.Serialize(new QuestaoCompletaDto { Id = 10, Descricao = "Q1" });
            var jsonQ2 = JsonSerializer.Serialize(new QuestaoCompletaDto { Id = 20, Descricao = "Q2" });

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(ra);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestaoTaiPorProvaAlunoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(questoesAluno);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterAlternativaAlunoRespostaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(alunoRespostas);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterDetalhesAlunoCacheQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(dados);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestoesTaiAdministradoPorProvaAlunoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(questoesAdministrado);
            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterQuestaoCompletaPorIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ObterQuestaoCompletaPorIdQuery query, CancellationToken _) =>
                {
                    var jsonPorId = new Dictionary<long, string>
                    {
                        { 10, jsonQ1 },
                        { 20, jsonQ2 }
                    };

                    return query.QuestoesIds
                        .Where(id => jsonPorId.ContainsKey(id))
                        .Select(id => jsonPorId[id])
                        .ToList();
                });

            mediatorMock.Setup(m => m.Send(It.Is<ObterAlternativaPorIdQuery>(q => q.Id == 1001), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Alternativa { Numeracao = "A" });
            mediatorMock.Setup(m => m.Send(It.Is<ObterAlternativaPorIdQuery>(q => q.Id == 2001), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Alternativa { Numeracao = "B" });

            var useCase = new ObterProvaTaiResultadoResumoUseCase(mediatorMock.Object);

            return new TesteContexto
            {
                UseCase = useCase,
                MediatorMock = mediatorMock,
                ProvaId = provaId,
                AlunoRespostas = alunoRespostas,
                QuestoesAdministrado = questoesAdministrado
            };
        }

        private sealed class TesteContexto
        {
            public ObterProvaTaiResultadoResumoUseCase UseCase { get; init; }
            public Mock<IMediator> MediatorMock { get; init; }
            public long ProvaId { get; init; }
            public List<QuestaoAlternativaAlunoRespostaDto> AlunoRespostas { get; init; }
            public List<QuestaoTaiDto> QuestoesAdministrado { get; init; }
        }
    }
}

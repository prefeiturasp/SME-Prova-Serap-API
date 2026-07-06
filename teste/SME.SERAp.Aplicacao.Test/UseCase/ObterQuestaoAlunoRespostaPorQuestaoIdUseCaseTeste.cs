using MediatR;
using Moq;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Dominio;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.SERAp.Aplicacao.Test.UseCase
{
    public class ObterQuestaoAlunoRespostaPorQuestaoIdUseCaseTeste
    {
        [Fact]
        public void Construtor_Deve_Lancar_Argument_Null_Exception_Quando_Mediator_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => new ObterQuestaoAlunoRespostaPorQuestaoIdUseCase(null));
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Dto_Quando_Resposta_Encontrada()
        {
            const long questaoId = 10;
            const long alunoRa = 123;
            var criadoEm = new DateTime(2024, 01, 10, 10, 0, 0);

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(alunoRa);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestaoAlunoRespostaPorIdRaQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new QuestaoAlunoResposta
                {
                    QuestaoId = questaoId,
                    AlunoRa = alunoRa,
                    AlternativaId = 1000,
                    Resposta = "Resposta",
                    CriadoEm = criadoEm
                });

            var useCase = new ObterQuestaoAlunoRespostaPorQuestaoIdUseCase(mediatorMock.Object);

            var resultado = await useCase.Executar(questaoId);

            Assert.NotNull(resultado);
            Assert.Equal(1000, resultado.AlternativaId);
            Assert.Equal("Resposta", resultado.Resposta);
            Assert.Equal(criadoEm, resultado.DataHoraResposta);

            mediatorMock.Verify(m => m.Send(It.Is<ObterQuestaoAlunoRespostaPorIdRaQuery>(q =>
                q.QuestaoId == questaoId && q.AlunoRa == alunoRa), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Null_Quando_Resposta_Nao_Encontrada()
        {
            const long questaoId = 10;
            const long alunoRa = 123;

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(alunoRa);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestaoAlunoRespostaPorIdRaQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((QuestaoAlunoResposta)null);

            var useCase = new ObterQuestaoAlunoRespostaPorQuestaoIdUseCase(mediatorMock.Object);

            var resultado = await useCase.Executar(questaoId);

            Assert.Null(resultado);
        }
    }
}

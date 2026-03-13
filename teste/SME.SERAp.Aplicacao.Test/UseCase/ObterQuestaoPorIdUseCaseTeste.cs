using MediatR;
using Moq;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.SERAp.Aplicacao.Test.UseCase
{
    public class ObterQuestaoPorIdUseCaseTeste
    {
        [Fact]
        public void Construtor_Deve_Lancar_Argument_Null_Exception_Quando_Mediator_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => new ObterQuestaoPorIdUseCase(null));
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Questao_Nao_Encontrada()
        {
            const long questaoId = 10;
            var mediatorMock = new Mock<IMediator>();
            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterQuestaoPorIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Questao)null);

            var useCase = new ObterQuestaoPorIdUseCase(mediatorMock.Object);

            var exception = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(questaoId));

            Assert.Equal("Questão não encontrada", exception.Message);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Questao_Detalhe_Quando_Encontrada()
        {
            const long questaoId = 10;
            var mediatorMock = new Mock<IMediator>();
            mediatorMock
                .Setup(m => m.Send(It.IsAny<ObterQuestaoPorIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Questao
                {
                    Id = questaoId,
                    TextoBase = null,
                    Enunciado = null,
                    Ordem = 3,
                    Tipo = QuestaoTipo.MultiplaEscolha,
                    QuantidadeAlternativas = 4
                });

            var useCase = new ObterQuestaoPorIdUseCase(mediatorMock.Object);

            var resultado = await useCase.Executar(questaoId);

            Assert.NotNull(resultado);
            Assert.Equal(questaoId, resultado.Id);
            Assert.Equal(string.Empty, resultado.Titulo);
            Assert.Equal(string.Empty, resultado.Descricao);
            Assert.Equal(3, resultado.Ordem);
            Assert.Equal((int)QuestaoTipo.MultiplaEscolha, resultado.Tipo);
            Assert.Equal(4, resultado.QuantidadeAlternativas);

            mediatorMock.Verify(m => m.Send(It.Is<ObterQuestaoPorIdQuery>(q => q.Id == questaoId), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}

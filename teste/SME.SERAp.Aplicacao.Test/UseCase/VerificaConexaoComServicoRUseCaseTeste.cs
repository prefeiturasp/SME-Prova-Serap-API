using MediatR;
using Moq;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Aplicacao.UseCase;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.SERAp.Aplicacao.Test.UseCase
{
    public class VerificaConexaoComServicoRUseCaseTeste
    {
        [Fact]
        public void Construtor_Deve_Lancar_Argument_Null_Exception_Quando_Mediator_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => new VerificaConexaoComServicoRUseCase(null));
        }

        [Fact]
        public async Task Executar_Deve_Retornar_True_Quando_ServicoR_Responder_True()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock
                .Setup(m => m.Send(It.IsAny<TesteConexaoApiRQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var useCase = new VerificaConexaoComServicoRUseCase(mediatorMock.Object);

            var resultado = await useCase.Executar();

            Assert.True(resultado);
            mediatorMock.Verify(m => m.Send(It.IsAny<TesteConexaoApiRQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_False_Quando_ServicoR_Responder_False()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock
                .Setup(m => m.Send(It.IsAny<TesteConexaoApiRQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var useCase = new VerificaConexaoComServicoRUseCase(mediatorMock.Object);

            var resultado = await useCase.Executar();

            Assert.False(resultado);
            mediatorMock.Verify(m => m.Send(It.IsAny<TesteConexaoApiRQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}

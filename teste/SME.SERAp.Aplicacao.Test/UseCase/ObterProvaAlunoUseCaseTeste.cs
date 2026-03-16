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
    public class ObterProvaAlunoUseCaseTeste
    {
        [Fact]
        public void Construtor_Deve_Lancar_Argument_Null_Exception_Quando_Mediator_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => new ObterProvaAlunoUseCase(null));
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Null_Quando_Nao_Ha_ProvaAluno()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(123L);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvaAlunoPorProvaIdRaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((ProvaAluno)null);

            var useCase = new ObterProvaAlunoUseCase(mediatorMock.Object);

            var resultado = await useCase.Executar(1);

            Assert.Null(resultado);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Dto_Quando_ProvaAluno_Existir()
        {
            var mediatorMock = new Mock<IMediator>();
            var ra = 123L;
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(ra);

            var provaAluno = new ProvaAluno { Id = 55, ProvaId = 1, AlunoRA = ra, Status = ProvaStatus.Iniciado };
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvaAlunoPorProvaIdRaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(provaAluno);

            var useCase = new ObterProvaAlunoUseCase(mediatorMock.Object);

            var resultado = await useCase.Executar(1);

            Assert.NotNull(resultado);
            Assert.Equal(provaAluno.Id, resultado.ProvaId);
            Assert.Equal((int)provaAluno.Status, resultado.Status);
        }
    }
}

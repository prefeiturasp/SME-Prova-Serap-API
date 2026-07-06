using MediatR;
using Moq;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Aplicacao.UseCase;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.SERAp.Aplicacao.Test.UseCase
{
    public class ReabrirProvaAlunoUseCaseTeste
    {
        [Fact]
        public void Construtor_Deve_Lancar_Argument_Null_Exception_Quando_Mediator_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => new ReabrirProvaAlunoUseCase(null));
        }

        [Fact]
        public async Task Executar_Deve_Publicar_Reabrir_Por_Cada_Aluno_E_Retornar_True()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock
                .Setup(m => m.Send(It.IsAny<PublicarFilaSerapEstudantesCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var useCase = new ReabrirProvaAlunoUseCase(mediatorMock.Object);

            var provaId = 10L;
            var alunos = new long[] { 1001L, 1002L, 1003L };

            var resultado = await useCase.Executar(provaId, alunos);

            Assert.True(resultado);

            foreach (var aluno in alunos)
            {
                mediatorMock.Verify(m => m.Send(It.Is<PublicarFilaSerapEstudantesCommand>(c =>
                    c.Fila == RotasRabbit.ReabrirProvaAluno
                    && Convert.ToInt64(c.Mensagem.GetType().GetProperty("ProvaId").GetValue(c.Mensagem)) == provaId
                    && Convert.ToInt64(c.Mensagem.GetType().GetProperty("AlunoRA").GetValue(c.Mensagem)) == aluno
                ), It.IsAny<CancellationToken>()), Times.Once);
            }

            mediatorMock.Verify(m => m.Send(It.IsAny<PublicarFilaSerapEstudantesCommand>(), It.IsAny<CancellationToken>()), Times.Exactly(alunos.Length));
        }
    }
}

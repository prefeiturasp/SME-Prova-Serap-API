using MediatR;
using Moq;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.SERAp.Aplicacao.Test.UseCase
{
    public class ObterRespostasAlunoPorProvaIdUseCaseTeste
    {
        [Fact]
        public void Construtor_Deve_Lancar_Argument_Null_Exception_Quando_Mediator_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => new ObterRespostasAlunoPorProvaIdUseCase(null));
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Null_Quando_Sem_Respostas()
        {
            var mediatorMock = new Mock<IMediator>();
            var ra = 123L;
            var provaId = 10L;

            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(ra);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterAlunoRespostasPorProvaIdRaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(Enumerable.Empty<QuestaoAlunoResposta>());

            var useCase = new ObterRespostasAlunoPorProvaIdUseCase(mediatorMock.Object);

            var resultado = await useCase.Executar(provaId);

            Assert.Null(resultado);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Lista_Quando_Ha_Respostas()
        {
            var mediatorMock = new Mock<IMediator>();
            var ra = 123L;
            var provaId = 20L;

            var respostas = new List<QuestaoAlunoResposta>
            {
                new QuestaoAlunoResposta { QuestaoId = 1, AlternativaId = 100, Resposta = "R1", CriadoEm = new DateTime(2024,1,1) },
                new QuestaoAlunoResposta { QuestaoId = 2, AlternativaId = 200, Resposta = "R2", CriadoEm = new DateTime(2024,1,2) }
            };

            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(ra);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterAlunoRespostasPorProvaIdRaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(respostas);

            var useCase = new ObterRespostasAlunoPorProvaIdUseCase(mediatorMock.Object);

            var resultado = (await useCase.Executar(provaId)).ToList();

            Assert.Equal(2, resultado.Count);
            Assert.Equal(1, resultado[0].QuestaoId);
            Assert.Equal(100, resultado[0].AlternativaId);
            Assert.Equal("R1", resultado[0].Resposta);
            Assert.Equal(new DateTime(2024, 1, 1), resultado[0].DataHoraResposta);

            Assert.Equal(2, resultado[1].QuestaoId);
            Assert.Equal(200, resultado[1].AlternativaId);
            Assert.Equal("R2", resultado[1].Resposta);
            Assert.Equal(new DateTime(2024, 1, 2), resultado[1].DataHoraResposta);
        }
    }
}

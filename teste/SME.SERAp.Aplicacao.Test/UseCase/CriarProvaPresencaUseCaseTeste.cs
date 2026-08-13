using MediatR;
using Moq;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Aplicacao.Queries.ExisteProvaPresencaPorNomeEAno;
using SME.SERAp.Prova.Aplicacao.UseCase;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.ProvaPresenca;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.SERAp.Aplicacao.Test.UseCase
{
    public class CriarProvaPresencaUseCaseTeste
    {
        [Fact]
        public void Construtor_Deve_Lancar_Argument_Null_Exception_Quando_Mediator_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => new CriarProvaPresencaUseCase(null));
        }

        [Fact]
        public async Task Executar_Deve_Criar_Prova_Quando_Nao_Existe_Duplicidade()
        {
            var mediatorMock = new Mock<IMediator>();
            var useCase = new CriarProvaPresencaUseCase(mediatorMock.Object);
            var dto = new CriarProvaPresencaDto
            {
                NomeProva = "Nova Prova",
                AnoProva = 2027,
                TurmasIds = new long[] { 1, 2 }
            };

            mediatorMock.Setup(m => m.Send(
                It.IsAny<ExisteProvaPresencaPorNomeEAnoQuery>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(false);

            mediatorMock.Setup(m => m.Send(
                It.IsAny<PublicarFilaSerapEstudantesCommand>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(true);

            var resultado = await useCase.Executar(dto);

            Assert.True(resultado);
            mediatorMock.Verify(m => m.Send(
                It.Is<ExisteProvaPresencaPorNomeEAnoQuery>(q =>
                    q.NomeProva == dto.NomeProva && q.AnoProva == dto.AnoProva),
                It.IsAny<CancellationToken>()
            ), Times.Once);
            mediatorMock.Verify(m => m.Send(
                It.Is<PublicarFilaSerapEstudantesCommand>(c =>
                    c.Fila == RotasRabbit.CriarProvaPresenca &&
                    ((CriarProvaPresencaDto)c.Mensagem).NomeProva == dto.NomeProva),
                It.IsAny<CancellationToken>()
            ), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_NegocioException_Quando_Existe_Duplicidade()
        {
            var mediatorMock = new Mock<IMediator>();
            var useCase = new CriarProvaPresencaUseCase(mediatorMock.Object);
            var dto = new CriarProvaPresencaDto
            {
                NomeProva = "Prova Existente",
                AnoProva = 2026,
                TurmasIds = new long[] { 1, 2 }
            };

            mediatorMock.Setup(m => m.Send(
                It.IsAny<ExisteProvaPresencaPorNomeEAnoQuery>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(true);

            var exception = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(dto));

            Assert.Equal($"Já existe uma prova de presença com o nome '{dto.NomeProva}' e ano '{dto.AnoProva}'.", exception.Message);
            mediatorMock.Verify(m => m.Send(
                It.Is<ExisteProvaPresencaPorNomeEAnoQuery>(q =>
                    q.NomeProva == dto.NomeProva && q.AnoProva == dto.AnoProva),
                It.IsAny<CancellationToken>()
            ), Times.Once);

            mediatorMock.Verify(m => m.Send(
                It.IsAny<PublicarFilaSerapEstudantesCommand>(),
                It.IsAny<CancellationToken>()
            ), Times.Never);
        }

        [Fact]
        public async Task Executar_Deve_ReLancar_Exception_Quando_Erro_Na_Verificacao_De_Existencia()
        {
            var mediatorMock = new Mock<IMediator>();
            var useCase = new CriarProvaPresencaUseCase(mediatorMock.Object);
            var dto = new CriarProvaPresencaDto
            {
                NomeProva = "Prova Com Erro",
                AnoProva = 2025,
                TurmasIds = new long[] { 1, 2 }
            };
            var excecaoInesperada = new Exception("Erro de banco de dados inesperado.");

            mediatorMock.Setup(m => m.Send(
                It.IsAny<ExisteProvaPresencaPorNomeEAnoQuery>(),
                It.IsAny<CancellationToken>()
            )).ThrowsAsync(excecaoInesperada);

            var exception = await Assert.ThrowsAsync<Exception>(() => useCase.Executar(dto));

            Assert.Equal(excecaoInesperada.Message, exception.Message);

            mediatorMock.Verify(m => m.Send(
                It.Is<ExisteProvaPresencaPorNomeEAnoQuery>(q =>
                    q.NomeProva == dto.NomeProva && q.AnoProva == dto.AnoProva),
                It.IsAny<CancellationToken>()
            ), Times.Once);

            mediatorMock.Verify(m => m.Send(
                It.IsAny<PublicarFilaSerapEstudantesCommand>(),
                It.IsAny<CancellationToken>()
            ), Times.Never);
        }

        [Fact]
        public async Task Executar_Deve_ReLancar_Exception_Quando_Erro_Na_Publicacao_Da_Fila()
        {
            var mediatorMock = new Mock<IMediator>();
            var useCase = new CriarProvaPresencaUseCase(mediatorMock.Object);
            var dto = new CriarProvaPresencaDto
            {
                NomeProva = "Prova Com Erro Fila",
                AnoProva = 2028,
                TurmasIds = new long[] { 1, 2 }
            };
            var excecaoInesperada = new Exception("Erro ao publicar na fila.");

            mediatorMock.Setup(m => m.Send(
                It.IsAny<ExisteProvaPresencaPorNomeEAnoQuery>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(false);

            mediatorMock.Setup(m => m.Send(
                It.IsAny<PublicarFilaSerapEstudantesCommand>(),
                It.IsAny<CancellationToken>()
            )).ThrowsAsync(excecaoInesperada);

            var exception = await Assert.ThrowsAsync<Exception>(() => useCase.Executar(dto));

            Assert.Equal(excecaoInesperada.Message, exception.Message);

            mediatorMock.Verify(m => m.Send(
                It.Is<ExisteProvaPresencaPorNomeEAnoQuery>(q =>
                    q.NomeProva == dto.NomeProva && q.AnoProva == dto.AnoProva),
                It.IsAny<CancellationToken>()
            ), Times.Once);

            mediatorMock.Verify(m => m.Send(
                It.Is<PublicarFilaSerapEstudantesCommand>(c =>
                    c.Fila == RotasRabbit.CriarProvaPresenca &&
                    ((CriarProvaPresencaDto)c.Mensagem).NomeProva == dto.NomeProva),
                It.IsAny<CancellationToken>()
            ), Times.Once);
        }
    }
}
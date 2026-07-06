using MediatR;
using Moq;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Aplicacao.Queries.VerificaStatusProvaFinalizada;
using SME.SERAp.Prova.Aplicacao.UseCase;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.Aluno;
using SME.SERAp.Prova.Infra.Exceptions;
using SME.SERAp.Prova.Infra.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.SERAp.Aplicacao.Test.UseCase
{
    public class IniciarProvaTaiUseCaseTeste
    {
        [Fact]
        public async Task Executar_Deve_Incluir_Quando_Prova_Nao_Localizada()
        {
            var contexto = CriarContextoPadrao();
            contexto.MediatorMock
                .Setup(m => m.Send(It.IsAny<ObterProvaAlunoPorProvaIdRaQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ProvaAluno)null);

            var dataInicioTicks = new DateTime(2024, 01, 02, 10, 0, 0).Ticks;
            contexto.Dto.DataInicio = dataInicioTicks;

            var expectedDataInicio = new DateTime(dataInicioTicks).AddHours(-3);

            contexto.MediatorMock
                .Setup(m => m.Send(It.IsAny<IncluirProvaAlunoCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var resultado = await contexto.UseCase.Executar(contexto.ProvaId, contexto.Dto);

            Assert.True(resultado);
            contexto.MediatorMock.Verify(m => m.Send(It.Is<IncluirProvaAlunoCommand>(c =>
                c.ProvaId == contexto.ProvaId &&
                c.AlunoRa == contexto.Aluno.Ra &&
                c.Status == ProvaStatus.Iniciado &&
                c.CriadoEm == expectedDataInicio &&
                c.TipoDispositivo == TipoDispositivo.NaoCadastrado &&
                c.DispositivoId == contexto.Aluno.DispositivoId
            ), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_False_Quando_Incluir_Retornar_False()
        {
            var contexto = CriarContextoPadrao();
            contexto.MediatorMock
                .Setup(m => m.Send(It.IsAny<ObterProvaAlunoPorProvaIdRaQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ProvaAluno)null);

            contexto.MediatorMock
                .Setup(m => m.Send(It.IsAny<IncluirProvaAlunoCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var resultado = await contexto.UseCase.Executar(contexto.ProvaId, contexto.Dto);

            Assert.False(resultado);
            contexto.MediatorMock.Verify(m => m.Send(It.IsAny<IncluirProvaAlunoCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Lancar__Negocio_Exception_Quando_Prova_Ja_Finalizada()
        {
            var contexto = CriarContextoPadrao();
            var provaAluno = new ProvaAluno { ProvaId = contexto.ProvaId, AlunoRA = contexto.Aluno.Ra, Status = ProvaStatus.Finalizado };
            contexto.MediatorMock
                .Setup(m => m.Send(It.IsAny<ObterProvaAlunoPorProvaIdRaQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(provaAluno);

            contexto.MediatorMock
                .Setup(m => m.Send(It.IsAny<VerificaStatusProvaFinalizadoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var exception = await Assert.ThrowsAsync<NegocioException>(() => contexto.UseCase.Executar(contexto.ProvaId, contexto.Dto));

            Assert.Equal("Esta prova já foi finalizada", exception.Message);
            Assert.Equal(411, exception.StatusCode);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Prova_Ja_Iniciada()
        {
            var contexto = CriarContextoPadrao();
            var provaAluno = new ProvaAluno { ProvaId = contexto.ProvaId, AlunoRA = contexto.Aluno.Ra, Status = ProvaStatus.Iniciado };
            contexto.MediatorMock
                .Setup(m => m.Send(It.IsAny<ObterProvaAlunoPorProvaIdRaQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(provaAluno);

            contexto.MediatorMock
                .Setup(m => m.Send(It.IsAny<VerificaStatusProvaFinalizadoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var exception = await Assert.ThrowsAsync<NegocioException>(() => contexto.UseCase.Executar(contexto.ProvaId, contexto.Dto));

            Assert.Equal("Esta prova já foi iniciada", exception.Message);
            Assert.Equal(411, exception.StatusCode);
        }

        [Fact]
        public async Task Executar_Deve_Registrar_E_ReLancar_Negocio_Exception_Quando_Ocorre_Erro()
        {
            var contexto = CriarContextoPadrao();
            contexto.MediatorMock
                .Setup(m => m.Send(It.IsAny<ObterDadosAlunoLogadoQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("erro"));

            await Assert.ThrowsAsync<Exception>(() => contexto.UseCase.Executar(contexto.ProvaId, contexto.Dto));

            contexto.ServicoLogMock.Verify(s => s.Registrar(It.IsAny<string>(), It.IsAny<Exception>()), Times.Once);
        }

        private static TesteContexto CriarContextoPadrao()
        {
            const long provaId = 1;
            const long alunoRa = 123;

            var aluno = new DadosAlunoLogadoDto(alunoRa, "device");

            var dto = new ProvaAlunoStatusDto(0, null, null, null);

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterDadosAlunoLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(aluno);
            mediatorMock.Setup(m => m.Send(It.IsAny<PublicarFilaSerapEstudanteAcompanhamentoCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            var servicoLogMock = new Mock<IServicoLog>();

            var useCase = new IniciarProvaTaiUseCase(mediatorMock.Object, servicoLogMock.Object);

            return new TesteContexto
            {
                MediatorMock = mediatorMock,
                ServicoLogMock = servicoLogMock,
                UseCase = useCase,
                Dto = dto,
                Aluno = aluno,
                ProvaId = provaId
            };
        }

        private sealed class TesteContexto
        {
            public Mock<IMediator> MediatorMock { get; init; }
            public Mock<IServicoLog> ServicoLogMock { get; init; }
            public IniciarProvaTaiUseCase UseCase { get; init; }
            public ProvaAlunoStatusDto Dto { get; init; }
            public DadosAlunoLogadoDto Aluno { get; init; }
            public long ProvaId { get; init; }
        }
    }
}

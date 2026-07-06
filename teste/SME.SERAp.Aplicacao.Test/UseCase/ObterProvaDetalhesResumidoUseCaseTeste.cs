using MediatR;
using Moq;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.SERAp.Aplicacao.Test.UseCase
{
    public class ObterProvaDetalhesResumidoUseCaseTeste
    {
        [Fact]
        public void Construtor_Deve_Lancar_Argument_Null_Exception_Quando_Mediator_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => new ObterProvaDetalhesResumidoUseCase(null));
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Ra_Zero()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(0L);

            var useCase = new ObterProvaDetalhesResumidoUseCase(mediatorMock.Object);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(1));
            Assert.Equal("Usuário infomado 0 não foi encontrado", ex.Message);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Prova_Nao_Encontrada()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(123L);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvaPorIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((Prova.Dominio.Prova)null);

            var useCase = new ObterProvaDetalhesResumidoUseCase(mediatorMock.Object);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(5));
            Assert.Equal("A prova infomada 5 não foi encontrada", ex.Message);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Prova_Tai()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(123L);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvaPorIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Prova.Dominio.Prova { Id = 10, FormatoTai = true });

            var useCase = new ObterProvaDetalhesResumidoUseCase(mediatorMock.Object);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(10));
            Assert.Equal("Prova TAI 10 não possui resumo detalhado. Usuário: 123.", ex.Message);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Nenhuma_Questao()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(123L);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvaPorIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Prova.Dominio.Prova { Id = 2, FormatoTai = false });
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestaoResumoPorProvaIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((IEnumerable<QuestaoResumoProvaDto>)null);

            var useCase = new ObterProvaDetalhesResumidoUseCase(mediatorMock.Object);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(2));
            Assert.Equal("Nenhuma questão foi encontrada para a prova 2", ex.Message);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Prova_PossuiBIB_E_Caderno_Vazio()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(123L);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvaPorIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Prova.Dominio.Prova { Id = 3, FormatoTai = false, PossuiBIB = true });
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestaoResumoPorProvaIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new List<QuestaoResumoProvaDto> { new QuestaoResumoProvaDto { QuestaoId = 100, Caderno = "A" } });
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterCadernoAlunoPorProvaIdRaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(string.Empty);

            var useCase = new ObterProvaDetalhesResumidoUseCase(mediatorMock.Object);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(3));
            Assert.Equal("Usuário informado 123 não possui caderno para a prova 3", ex.Message);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Questoes_E_Contextos_Apos_Filtragem_Por_Caderno()
        {
            var provaId = 4L;
            var ra = 555L;
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(ra);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvaPorIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Prova.Dominio.Prova { Id = provaId, FormatoTai = false, PossuiBIB = true });

            var questoes = new List<QuestaoResumoProvaDto>
            {
                new QuestaoResumoProvaDto { QuestaoId = 1, Caderno = "A" },
                new QuestaoResumoProvaDto { QuestaoId = 2, Caderno = "B" },
                new QuestaoResumoProvaDto { QuestaoId = 3, Caderno = "A" }
            };

            mediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestaoResumoPorProvaIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(questoes);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterCadernoAlunoPorProvaIdRaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync("A");

            var contextos = new List<ContextoResumoProvaDto>
            {
                new ContextoResumoProvaDto { ContextoProvaId = 1000 },
                new ContextoResumoProvaDto { ContextoProvaId = 2000 }
            };

            mediatorMock.Setup(m => m.Send(It.IsAny<ObterContextoResumoPorProvaIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(contextos);

            var useCase = new ObterProvaDetalhesResumidoUseCase(mediatorMock.Object);

            var resultado = await useCase.Executar(provaId);

            Assert.NotNull(resultado);
            Assert.Equal(provaId, resultado.ProvaId);
            Assert.Equal(new long[] { 1, 3 }, resultado.QuestoesIds);
            Assert.Equal(new long[] { 1000, 2000 }, resultado.ContextosProvaIds);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Questoes_Quando_Sem_Contextos()
        {
            var provaId = 6L;
            var ra = 777L;
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(ra);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvaPorIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Prova.Dominio.Prova { Id = provaId, FormatoTai = false, PossuiBIB = false });

            var questoes = new List<QuestaoResumoProvaDto>
            {
                new QuestaoResumoProvaDto { QuestaoId = 11, Caderno = "A" },
                new QuestaoResumoProvaDto { QuestaoId = 12, Caderno = "A" }
            };

            mediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestaoResumoPorProvaIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(questoes);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterContextoResumoPorProvaIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(Enumerable.Empty<ContextoResumoProvaDto>());

            var useCase = new ObterProvaDetalhesResumidoUseCase(mediatorMock.Object);

            var resultado = await useCase.Executar(provaId);

            Assert.NotNull(resultado);
            Assert.Equal(provaId, resultado.ProvaId);
            Assert.Equal(new long[] { 11, 12 }, resultado.QuestoesIds);
            Assert.Empty(resultado.ContextosProvaIds);
        }
    }
}

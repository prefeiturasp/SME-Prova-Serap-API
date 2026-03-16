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
    public class ObterProvaDetalheResumidoCadernoUseCaseTeste
    {
        [Fact]
        public void Construtor_Deve_Lancar_Argument_Null_Exception_Quando_Mediator_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => new ObterProvaDetalhesResumidoCadernoUseCase(null));
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Ra_Zero()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(0L);

            var useCase = new ObterProvaDetalhesResumidoCadernoUseCase(mediatorMock.Object);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(1, "A"));
            Assert.Equal("Usuário infomado 0 não foi encontrado", ex.Message);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Prova_Nao_Encontrada()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(123L);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvaPorIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((Prova.Dominio.Prova)null);

            var useCase = new ObterProvaDetalhesResumidoCadernoUseCase(mediatorMock.Object);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(5, "A"));
            Assert.Equal("A prova infomada 5 não foi encontrada", ex.Message);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Prova_Tai()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(123L);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvaPorIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Prova.Dominio.Prova { Id = 10, FormatoTai = true });

            var useCase = new ObterProvaDetalhesResumidoCadernoUseCase(mediatorMock.Object);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(10, "A"));
            Assert.Equal("Prova TAI 10 não possui resumo detalhado. Usuário: 123.", ex.Message);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Nenhuma_Questao()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(123L);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvaPorIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Prova.Dominio.Prova { Id = 2, FormatoTai = false });
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestaoResumoPorProvaIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((IEnumerable<QuestaoResumoProvaDto>)null);

            var useCase = new ObterProvaDetalhesResumidoCadernoUseCase(mediatorMock.Object);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar(2, "A"));
            Assert.Equal("Nenhuma questão foi encontrada para a prova 2", ex.Message);
        }

        [Fact]
        public async Task Executar_Deve_Filtrar_Por_Caderno_Quando_PossuiBIB()
        {
            var provaId = 3L;
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(123L);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvaPorIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Prova.Dominio.Prova { Id = provaId, FormatoTai = false, PossuiBIB = true });

            var questoes = new List<QuestaoResumoProvaDto>
            {
                new QuestaoResumoProvaDto { QuestaoId = 1, QuestaoLegadoId = 100, Caderno = "A", Ordem = 2, Alternativas = new [] { new AlternativaResumoProvaDto { AlternativaId = 11, AlternativaLegadoId = 111, Ordem = 2 }, new AlternativaResumoProvaDto { AlternativaId = 10, AlternativaLegadoId = 110, Ordem = 1 } } },
                new QuestaoResumoProvaDto { QuestaoId = 2, QuestaoLegadoId = 200, Caderno = "B", Ordem = 1, Alternativas = Array.Empty<AlternativaResumoProvaDto>() }
            };

            mediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestaoResumoPorProvaIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(questoes);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterContextoResumoPorProvaIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(Enumerable.Empty<ContextoResumoProvaDto>());

            var useCase = new ObterProvaDetalhesResumidoCadernoUseCase(mediatorMock.Object);

            var resultado = await useCase.Executar(provaId, "A");

            Assert.NotNull(resultado);
            Assert.Equal(provaId, resultado.ProvaId);
            Assert.Single(resultado.Questoes);
            var q = resultado.Questoes[0];
            Assert.Equal(1, q.QuestaoId);
            Assert.Equal(100, q.QuestaoLegadoId);
            // alternativas devem estar ordenadas por Ordem
            Assert.Equal(2, q.Alternativas.Length);
            Assert.Equal(10, q.Alternativas[0].AlternativaId);
            Assert.Equal(11, q.Alternativas[1].AlternativaId);
            Assert.Equal(2, q.Ordem);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Questoes_E_Contextos_Ordenados()
        {
            var provaId = 4L;
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(999L);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvaPorIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Prova.Dominio.Prova { Id = provaId, FormatoTai = false, PossuiBIB = false });

            var questoes = new List<QuestaoResumoProvaDto>
            {
                new QuestaoResumoProvaDto { QuestaoId = 5, QuestaoLegadoId = 500, Caderno = "A", Ordem = 2, Alternativas = new [] { new AlternativaResumoProvaDto { AlternativaId = 51, AlternativaLegadoId = 501, Ordem = 1 } } },
                new QuestaoResumoProvaDto { QuestaoId = 4, QuestaoLegadoId = 400, Caderno = "A", Ordem = 1, Alternativas = new [] { new AlternativaResumoProvaDto { AlternativaId = 41, AlternativaLegadoId = 401, Ordem = 1 } } }
            };

            mediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestaoResumoPorProvaIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(questoes);

            var contextos = new List<ContextoResumoProvaDto>
            {
                new ContextoResumoProvaDto { ContextoProvaId = 300 },
                new ContextoResumoProvaDto { ContextoProvaId = 200 }
            };

            mediatorMock.Setup(m => m.Send(It.IsAny<ObterContextoResumoPorProvaIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(contextos);

            var useCase = new ObterProvaDetalhesResumidoCadernoUseCase(mediatorMock.Object);

            var resultado = await useCase.Executar(provaId, "A");

            Assert.NotNull(resultado);
            Assert.Equal(provaId, resultado.ProvaId);
            Assert.Equal(new long[] { 4, 5 }, resultado.Questoes.Select(q => q.QuestaoId));
            Assert.Equal(new long[] { 300, 200 }, resultado.ContextosProvaIds);
        }
    }
}

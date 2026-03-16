using MediatR;
using Moq;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Dominio;
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
    public class ObterProvasAnterioresAreaEstudanteUseCaseTeste
    {
        [Fact]
        public void Construtor_Deve_Lancar_Argument_Null_Exception_Quando_Mediator_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => new ObterProvasAnterioresAreaEstudanteUseCase(null));
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Ra_Zero()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(0L);

            var useCase = new ObterProvasAnterioresAreaEstudanteUseCase(mediatorMock.Object);

            var ex = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar());
            Assert.Equal("Não foi possível obter o RA do usuário logado.", ex.Message);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Null_Quando_Sem_Provas()
        {
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(123L);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvasAnterioresAlunoPorRaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((IEnumerable<ProvaAlunoAnoDto>)null);

            var useCase = new ObterProvasAnterioresAreaEstudanteUseCase(mediatorMock.Object);

            var resultado = await useCase.Executar();

            Assert.Null(resultado);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Lista_Mapeada_Quando_Existem_Provas()
        {
            var mediatorMock = new Mock<IMediator>();
            var ra = 123L;
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(ra);

            var prova1 = new ProvaAlunoAnoDto
            {
                Id = 1,
                Descricao = "Prova 1",
                TotalItens = 10,
                Inicio = new DateTime(2024, 1, 1),
                Fim = new DateTime(2024, 1, 2),
                Status = (int)ProvaStatus.Finalizado,
                DataInicioProvaAluno = new DateTime(2024, 1, 1, 10, 0, 0),
                DataFimProvaAluno = new DateTime(2024, 1, 1, 11, 0, 0)
            };

            var provas = new List<ProvaAlunoAnoDto> { prova1 };

            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvasAnterioresAlunoPorRaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(provas);

            var useCase = new ObterProvasAnterioresAreaEstudanteUseCase(mediatorMock.Object);

            var resultado = (await useCase.Executar()).ToList();

            Assert.Single(resultado);
            var r = resultado[0];
            Assert.Equal(prova1.Id, r.Id);
            Assert.Equal(prova1.Descricao, r.Descricao);
            Assert.Equal(prova1.TotalItens, r.ItensQuantidade);
            Assert.Equal(0, r.TempoTotal);
            Assert.Equal(prova1.Status, r.Status);
            Assert.Equal(prova1.Inicio, r.DataInicio);
            Assert.Equal(prova1.Fim, r.DataFim);
            Assert.Equal(prova1.DataInicioProvaAluno, r.DataInicioProvaAluno);
            Assert.Equal(prova1.DataFimProvaAluno, r.DataFimProvaAluno);
        }
    }
}

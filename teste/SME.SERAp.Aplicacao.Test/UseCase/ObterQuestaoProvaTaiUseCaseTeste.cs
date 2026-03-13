using MediatR;
using Moq;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Aplicacao.Queries;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.Aluno;
using SME.SERAp.Prova.Infra.Dtos.Questao;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.SERAp.Aplicacao.Test.UseCase
{
    public class ObterQuestaoProvaTaiUseCaseTeste
    {
        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Prova_Nao_Iniciada()
        {
            var contexto = CriarContextoPadrao();
            contexto.MediatorMock
                .Setup(m => m.Send(It.IsAny<ObterProvaAlunoPorProvaIdRaQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ProvaAluno { ProvaId = contexto.ProvaId, AlunoRA = contexto.Aluno.Ra, Status = ProvaStatus.NaoIniciado });

            var exception = await Assert.ThrowsAsync<NegocioException>(() => contexto.UseCase.Executar(contexto.ProvaId));

            Assert.Equal("Esta prova precisa ser iniciada.", exception.Message);
            Assert.Equal(411, exception.StatusCode);
        }

        [Fact]
        public async Task Executar_Deve_Incluir_Primeira_Questao_Quando_Nao_Ha_Administrado()
        {
            var contexto = CriarContextoPadrao();

            contexto.MediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestoesTaiAdministradoPorProvaAlunoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((IEnumerable<QuestaoTaiDto>)Array.Empty<QuestaoTaiDto>());

            var alunoDetalhes = new AlunoDetalheDto { AlunoId = 456, DreAbreviacao = "DRE", Escola = "Escola", Turma = "Turma", Nome = "Nome" };
            contexto.MediatorMock.Setup(m => m.Send(It.IsAny<ObterAlunoDadosPorRaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(alunoDetalhes);

            contexto.MediatorMock.Setup(m => m.Send(It.IsAny<ExisteCadernoAlunoPorProvaIdAlunoIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(false);
            contexto.MediatorMock.Setup(m => m.Send(It.IsAny<ExisteQuestaoAlunoTaiPorAlunoIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(false);

            contexto.MediatorMock.Setup(m => m.Send(It.IsAny<ObterIdsQuestoesPorProvaIdCadernoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<long> { 100 });

            var questao = new QuestaoCompletaDto { Id = 100, Titulo = "Q", Descricao = "D", Ordem = 0 };
            var json = JsonSerializer.Serialize(questao);
            contexto.MediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestaoCompletaPorIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<string> { json } as IEnumerable<string>);

            var resultado = await contexto.UseCase.Executar(contexto.ProvaId);

            Assert.NotNull(resultado);
            Assert.Equal(questao.Id, resultado.Id);
            Assert.Equal(0, resultado.Ordem);

            contexto.MediatorMock.Verify(m => m.Send(It.Is<PublicarFilaSerapEstudantesCommand>(c => c.Fila == RotasRabbit.TratarCadernoAlunoProva), It.IsAny<CancellationToken>()), Times.Once);
            contexto.MediatorMock.Verify(m => m.Send(It.IsAny<SalvarCacheCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Usar_Administrado_Quando_ExisteQuestaoAlunoTai()
        {
            var contexto = CriarContextoPadrao();

            contexto.MediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestoesTaiAdministradoPorProvaAlunoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((IEnumerable<QuestaoTaiDto>)Array.Empty<QuestaoTaiDto>());

            var alunoDetalhes = new AlunoDetalheDto { AlunoId = 456, DreAbreviacao = "DRE", Escola = "Escola", Turma = "Turma", Nome = "Nome" };
            contexto.MediatorMock.Setup(m => m.Send(It.IsAny<ObterAlunoDadosPorRaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(alunoDetalhes);

            contexto.MediatorMock.Setup(m => m.Send(It.IsAny<ExisteCadernoAlunoPorProvaIdAlunoIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            contexto.MediatorMock.Setup(m => m.Send(It.IsAny<ExisteQuestaoAlunoTaiPorAlunoIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            contexto.MediatorMock.Setup(m => m.Send(It.Is<ObterQuestoesTaiAdministradoPorProvaAlunoQuery>(q => q.UtilizarCache == false), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<QuestaoTaiDto> { new QuestaoTaiDto { Id = 200, Ordem = 5 } });

            var questao = new QuestaoCompletaDto { Id = 200, Titulo = "Q2", Descricao = "D2", Ordem = 0 };
            var json = JsonSerializer.Serialize(questao);
            contexto.MediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestaoCompletaPorIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<string> { json } as IEnumerable<string>);

            var resultado = await contexto.UseCase.Executar(contexto.ProvaId);

            Assert.NotNull(resultado);
            Assert.Equal(questao.Id, resultado.Id);
            Assert.Equal(5, resultado.Ordem);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_UltimaQuestao_Nao_Localizada_Json()
        {
            var contexto = CriarContextoPadrao();

            contexto.MediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestoesTaiAdministradoPorProvaAlunoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<QuestaoTaiDto> { new QuestaoTaiDto { Id = 300, Ordem = 2 } });

            contexto.MediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestaoCompletaPorIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Enumerable.Empty<string>());

            var exception = await Assert.ThrowsAsync<NegocioException>(() => contexto.UseCase.Executar(contexto.ProvaId));

            Assert.Equal("Última questão não localizada (json).", exception.Message);
        }

        private static TesteContexto CriarContextoPadrao()
        {
            const long provaId = 1;
            const long alunoRa = 123;

            var aluno = new DadosAlunoLogadoDto(alunoRa, "device");

            var dados = new MeusDadosRetornoDto(456, "DRE", "Escola", "Turma", "Nome", "5", "M", 12, Modalidade.Fundamental, 1, 7, 12, Array.Empty<int>());

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterDadosAlunoLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(aluno);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterDetalhesAlunoCacheQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(dados);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvaAlunoPorProvaIdRaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ProvaAluno { ProvaId = provaId, AlunoRA = alunoRa, Status = ProvaStatus.Iniciado });
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestoesTaiAdministradoPorProvaAlunoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new List<QuestaoTaiDto> { new QuestaoTaiDto { Id = 10, Ordem = 1 } });

            mediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestaoCompletaPorIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<string> { JsonSerializer.Serialize(new QuestaoCompletaDto { Id = 10, Titulo = "Q", Descricao = "D", Ordem = 1 }) } as IEnumerable<string>);

            var useCase = new ObterQuestaoProvaTaiUseCase(mediatorMock.Object);

            return new TesteContexto
            {
                MediatorMock = mediatorMock,
                UseCase = useCase,
                ProvaId = provaId,
                Aluno = aluno,
                Dados = dados
            };
        }

        private sealed class TesteContexto
        {
            public Mock<IMediator> MediatorMock { get; init; }
            public ObterQuestaoProvaTaiUseCase UseCase { get; init; }
            public long ProvaId { get; init; }
            public DadosAlunoLogadoDto Aluno { get; init; }
            public MeusDadosRetornoDto Dados { get; init; }
        }
    }
}

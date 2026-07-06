using MediatR;
using Moq;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Dtos.Aluno;
using SME.SERAp.Prova.Infra.Dtos.ApiR;
using SME.SERAp.Prova.Infra.Dtos.Questao;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.SERAp.Aplicacao.Test.UseCase
{
    public class ObterProximaQuestaoProvaTaiUseCaseTeste
    {
        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Prova_Nao_Localizada()
        {
            var contexto = CriarContextoPadrao();
            contexto.MediatorMock
                .Setup(m => m.Send(It.IsAny<ObterProvaPorIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Prova.Dominio.Prova)null);

            var exception = await Assert.ThrowsAsync<NegocioException>(() => contexto.UseCase.Executar(contexto.ProvaId, contexto.Dto));

            Assert.Equal($"Prova {contexto.ProvaId} não localizada.", exception.Message);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_AlunoRa_Diferente()
        {
            var contexto = CriarContextoPadrao();
            contexto.Dto.AlunoRa = contexto.AlunoRa + 1;

            var exception = await Assert.ThrowsAsync<NegocioException>(() => contexto.UseCase.Executar(contexto.ProvaId, contexto.Dto));

            Assert.Equal("Resposta enviada não pertence ao aluno logado", exception.Message);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_UltimaQuestao_Diferente()
        {
            var contexto = CriarContextoPadrao();
            contexto.QuestoesAdministrado.Clear();
            contexto.QuestoesAdministrado.Add(new QuestaoTaiDto { Id = 999, Ordem = 1 });

            var exception = await Assert.ThrowsAsync<NegocioException>(() => contexto.UseCase.Executar(contexto.ProvaId, contexto.Dto));

            Assert.Equal("A questão respondida não é a última questão administrada para o aluno. Página precisa ser atualizada.", exception.Message);
            Assert.Equal(410, exception.StatusCode);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Prova_Nao_Iniciada()
        {
            var contexto = CriarContextoPadrao();
            contexto.ProvaAluno.Status = ProvaStatus.NaoIniciado;

            var exception = await Assert.ThrowsAsync<NegocioException>(() => contexto.UseCase.Executar(contexto.ProvaId, contexto.Dto));

            Assert.Equal("Esta prova precisa ser iniciada.", exception.Message);
            Assert.Equal(411, exception.StatusCode);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Questao_Nao_Pertence_Ao_Aluno()
        {
            var contexto = CriarContextoPadrao();
            contexto.QuestoesAluno.RemoveAll(q => q.Id == contexto.QuestaoId);

            var exception = await Assert.ThrowsAsync<NegocioException>(() => contexto.UseCase.Executar(contexto.ProvaId, contexto.Dto));

            Assert.Equal($"Questão respondida não pertence ao aluno logado. Questão: {contexto.QuestaoId}", exception.Message);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Resposta_Nao_Encontrada()
        {
            var contexto = CriarContextoPadrao();
            contexto.AlunoRespostas.Clear();
            contexto.AlunoRespostas.Add(new QuestaoAlternativaAlunoRespostaDto { QuestaoId = 999, AlternativaCorreta = 10 });

            var exception = await Assert.ThrowsAsync<NegocioException>(() => contexto.UseCase.Executar(contexto.ProvaId, contexto.Dto));

            Assert.Equal($"Questão respondida não encontrada na lista de respostas do aluno. Questão: {contexto.QuestaoId}", exception.Message);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Retorno_Tai_Nao_Existe_Para_Aluno()
        {
            var contexto = CriarContextoPadrao();
            contexto.Retorno.ProximaQuestao = 999;

            var exception = await Assert.ThrowsAsync<NegocioException>(() => contexto.UseCase.Executar(contexto.ProvaId, contexto.Dto));

            Assert.Equal($"Próxima questão retornada pelo TAI não existe para o aluno. Questão: {contexto.Retorno.ProximaQuestao}", exception.Message);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_True_Quando_ContinuarProva()
        {
            var contexto = CriarContextoPadrao();

            var resultado = await contexto.UseCase.Executar(contexto.ProvaId, contexto.Dto);

            Assert.True(resultado);
            var proximaQuestao = contexto.QuestoesAluno.First(q => q.Id == contexto.ProximaQuestaoId);
            Assert.Equal(contexto.Retorno.Ordem, proximaQuestao.Ordem);
        }

        [Fact]
        public async Task Executar_Deve_Ajustar_Ordem_Quando_Ja_Administrado()
        {
            var contexto = CriarContextoPadrao();
            var questaoRespondida = contexto.QuestoesAdministrado.First(q => q.Id == contexto.QuestaoId);
            questaoRespondida.Ordem = contexto.Retorno.Ordem;
            var ordemEsperada = contexto.QuestoesAdministrado.Max(q => q.Ordem) + 1;

            var resultado = await contexto.UseCase.Executar(contexto.ProvaId, contexto.Dto);

            Assert.True(resultado);
            Assert.Equal(ordemEsperada, contexto.Retorno.Ordem);
            var proximaQuestao = contexto.QuestoesAluno.First(q => q.Id == contexto.ProximaQuestaoId);
            Assert.Equal(ordemEsperada, proximaQuestao.Ordem);
        }

        [Fact]
        public async Task Executar_Deve_Finalizar_Quando_Nao_Ha_ProximaQuestao()
        {
            var dataResposta = new DateTime(2024, 01, 03, 10, 0, 0);
            var contexto = CriarContextoPadrao(continuarProva: false, dataHoraRespostaTicks: dataResposta.Ticks);
            contexto.Prova.ProvaFormatoTaiItem = ProvaFormatoTaiItem.Item_20;

            var resultado = await contexto.UseCase.Executar(contexto.ProvaId, contexto.Dto);

            Assert.False(resultado);
            Assert.Equal(ProvaStatus.Finalizado, contexto.ProvaAluno.Status);
            Assert.Equal(dataResposta.AddHours(-3), contexto.ProvaAluno.FinalizadoEm);
            contexto.MediatorMock.Verify(m => m.Send(It.IsAny<AtualizarProvaAlunoCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Finalizar_Com_Ticks_Zerado()
        {
            var contexto = CriarContextoPadrao(continuarProva: false, dataHoraRespostaTicks: 0);
            var inicio = DateTime.Now.AddHours(-3);

            var resultado = await contexto.UseCase.Executar(contexto.ProvaId, contexto.Dto);

            var fim = DateTime.Now.AddHours(-3);
            Assert.False(resultado);
            Assert.NotNull(contexto.ProvaAluno.FinalizadoEm);
            Assert.InRange(contexto.ProvaAluno.FinalizadoEm.Value, inicio, fim);
        }

        private static TesteContexto CriarContextoPadrao(bool continuarProva = true, long? dataHoraRespostaTicks = null)
        {
            const long provaId = 1;
            const long alunoRa = 123;
            const long alunoId = 456;
            const long questaoId = 10;
            const long proximaQuestaoId = 20;

            var prova = new Prova.Dominio.Prova
            {
                Id = provaId,
                Disciplina = "MAT",
                DisciplinaId = 1
            };

            var aluno = new DadosAlunoLogadoDto(alunoRa, "device");

            var dados = new MeusDadosRetornoDto(
                alunoId,
                "DRE",
                "Escola",
                "Turma",
                "Nome",
                "5",
                "M",
                12,
                Modalidade.Fundamental,
                1,
                7,
                12,
                Array.Empty<int>());

            var questoesAluno = new List<QuestaoTaiDto>
            {
                new() { Id = questaoId, Ordem = 1, Discriminacao = 1, ProporcaoAcertos = 0.5m, AcertoCasual = 0.2m, EixoId = 1, HabilidadeId = 1 },
                new() { Id = proximaQuestaoId, Ordem = 0, Discriminacao = 1, ProporcaoAcertos = 0.5m, AcertoCasual = 0.2m, EixoId = 1, HabilidadeId = 1 }
            };

            var questoesAdministrado = new List<QuestaoTaiDto>
            {
                new() { Id = questaoId, Ordem = 1 }
            };

            var alunoRespostas = new List<QuestaoAlternativaAlunoRespostaDto>
            {
                new() { QuestaoId = questaoId, AlternativaCorreta = 100 }
            };

            var retorno = new ObterProximoItemApiRRespostaDto
            {
                ProximaQuestao = continuarProva ? proximaQuestaoId : -1,
                Ordem = 2,
                Proficiencia = 0.6m,
                ErroMedida = 0.1m
            };

            var provaAluno = new ProvaAluno
            {
                ProvaId = provaId,
                AlunoRA = alunoRa,
                Status = ProvaStatus.Iniciado,
                CriadoEm = new DateTime(2024, 01, 01),
                TipoDispositivo = TipoDispositivo.Web,
                DispositivoId = "device"
            };

            var dto = new QuestaoAlunoRespostaSincronizarDto
            {
                AlunoRa = alunoRa,
                QuestaoId = questaoId,
                AlternativaId = 1000,
                DataHoraRespostaTicks = dataHoraRespostaTicks ?? new DateTime(2024, 01, 02, 10, 0, 0).Ticks,
                TempoRespostaAluno = 10
            };

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvaPorIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(prova);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterDadosAlunoLogadoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(aluno);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterDetalhesAlunoCacheQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(dados);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestoesTaiAdministradoPorProvaAlunoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(questoesAdministrado);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvaAlunoPorProvaIdRaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(provaAluno);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterUltimaProficienciaPorProvaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(0.5m);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterQuestaoTaiPorProvaAlunoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(questoesAluno);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterAlternativaAlunoRespostaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(alunoRespostas);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProximoItemApiRQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(retorno);
            mediatorMock.Setup(m => m.Send(It.IsAny<SalvarCacheCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            mediatorMock.Setup(m => m.Send(It.IsAny<PublicarFilaSerapEstudantesCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            mediatorMock.Setup(m => m.Send(It.IsAny<PublicarFilaSerapEstudanteAcompanhamentoCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            mediatorMock.Setup(m => m.Send(It.IsAny<AtualizarProvaAlunoCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            var useCase = new ObterProximaQuestaoProvaTaiUseCase(mediatorMock.Object);

            return new TesteContexto
            {
                MediatorMock = mediatorMock,
                UseCase = useCase,
                Dto = dto,
                Prova = prova,
                Aluno = aluno,
                Dados = dados,
                QuestoesAluno = questoesAluno,
                QuestoesAdministrado = questoesAdministrado,
                AlunoRespostas = alunoRespostas,
                Retorno = retorno,
                ProvaAluno = provaAluno,
                ProvaId = provaId,
                AlunoRa = alunoRa,
                QuestaoId = questaoId,
                ProximaQuestaoId = proximaQuestaoId
            };
        }

        private sealed class TesteContexto
        {
            public Mock<IMediator> MediatorMock { get; init; }
            public ObterProximaQuestaoProvaTaiUseCase UseCase { get; init; }
            public QuestaoAlunoRespostaSincronizarDto Dto { get; init; }
            public Prova.Dominio.Prova Prova { get; init; }
            public DadosAlunoLogadoDto Aluno { get; init; }
            public MeusDadosRetornoDto Dados { get; init; }
            public List<QuestaoTaiDto> QuestoesAluno { get; init; }
            public List<QuestaoTaiDto> QuestoesAdministrado { get; init; }
            public List<QuestaoAlternativaAlunoRespostaDto> AlunoRespostas { get; init; }
            public ObterProximoItemApiRRespostaDto Retorno { get; init; }
            public ProvaAluno ProvaAluno { get; init; }
            public long ProvaId { get; init; }
            public long AlunoRa { get; init; }
            public long QuestaoId { get; init; }
            public long ProximaQuestaoId { get; init; }
        }
    }
}

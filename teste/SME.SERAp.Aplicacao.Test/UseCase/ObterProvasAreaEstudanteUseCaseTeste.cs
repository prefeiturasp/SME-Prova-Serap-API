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
    public class ObterProvasAreaEstudanteUseCaseTeste
    {
        [Fact]
        public void Construtor_Deve_Lancar_Argument_Null_Exception_Quando_Mediator_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => new ObterProvasAreaEstudanteUseCase(null));
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Claims_Nao_Localizadas()
        {
            var contexto = CriarContextoPadrao();
            contexto.MediatorMock
                .Setup(m => m.Send(It.IsAny<ObterUsuarioLogadoInformacoesPorClaimsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((IEnumerable<ParametroDto>)null);

            var exception = await Assert.ThrowsAsync<NegocioException>(() => contexto.UseCase.Executar());

            Assert.Equal("Dados do usuário logado não localizado", exception.Message);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Ano_Nao_Localizado()
        {
            var contexto = CriarContextoPadrao();
            contexto.Claims.RemoveAll(c => c.Chave == "ANO");

            var exception = await Assert.ThrowsAsync<NegocioException>(() => contexto.UseCase.Executar());

            Assert.Equal("Ano do aluno logado não localizado", exception.Message);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Negocio_Exception_Quando_Turma_Nao_Localizada()
        {
            var contexto = CriarContextoPadrao();
            contexto.Turmas.Clear();

            var exception = await Assert.ThrowsAsync<NegocioException>(() => contexto.UseCase.Executar());

            Assert.Equal("Turma do aluno não localizado", exception.Message);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Default_Quando_Turma_Atual_Nao_Localizada()
        {
            var contexto = CriarContextoPadrao();
            contexto.Turmas[0].Ano = "9";

            var resultado = await contexto.UseCase.Executar();

            Assert.Null(resultado);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Provas_Quando_Dados_Validos()
        {
            var contexto = CriarContextoPadrao();

            var resultado = (await contexto.UseCase.Executar()).ToList();

            Assert.Single(resultado);
            Assert.Equal(contexto.Prova.Id, resultado[0].Id);
            Assert.Equal(contexto.Prova.Descricao, resultado[0].Descricao);
            Assert.Equal((int)ProvaStatus.Iniciado, resultado[0].Status);
            Assert.Equal(900, resultado[0].TempoExtra);
            Assert.Equal(450, resultado[0].TempoAlerta);
        }

        [Fact]
        public async Task Executar_Nao_Deve_Retornar_Prova_Bib_Quando_Caderno_Vazio()
        {
            var contexto = CriarContextoPadrao();
            contexto.Prova.PossuiBIB = true;
            contexto.MediatorMock
                .Setup(m => m.Send(It.IsAny<ObterCadernoAlunoPorProvaIdRaQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(string.Empty);

            var resultado = await contexto.UseCase.Executar();

            Assert.Empty(resultado);
        }

        [Fact]
        public async Task Executar_Deve_Usar_Total_Itens_Das_Respostas_Quando_Prova_Tai()
        {
            var contexto = CriarContextoPadrao();
            contexto.Prova.FormatoTai = true;

            var resultado = (await contexto.UseCase.Executar()).ToList();

            Assert.Single(resultado);
            Assert.Equal(2, resultado[0].ItensQuantidade);
        }

        private static TesteContexto CriarContextoPadrao()
        {
            const long provaId = 1;
            const long alunoRa = 123;

            var claims = new List<ParametroDto>
            {
                new() { Chave = "ANO", Valor = "5" },
                new() { Chave = "TIPOTURNO", Valor = "1" },
                new() { Chave = "MODALIDADE", Valor = ((int)Modalidade.Fundamental).ToString() },
                new() { Chave = "RA", Valor = alunoRa.ToString() }
            };

            var parametros = new List<ParametroSistema>
            {
                new(DateTime.Now.Year, true, "tempo extra", "TempoExtra", TipoParametroSistema.TempoExtraProva, "900"),
                new(DateTime.Now.Year, true, "tempo alerta", "TempoAlerta", TipoParametroSistema.TempoAlertaProva, "450")
            };

            var turmas = new List<Turma>
            {
                new() { Id = 10, Ano = "5", Modalidade = (int)Modalidade.Fundamental, TipoTurno = 1, EtapaEja = 0, AnoLetivo = DateTime.Now.Year }
            };

            var prova = new ProvaAnoDto
            {
                Id = provaId,
                Descricao = "Prova Matemática",
                InicioDownload = DateTime.Now.AddDays(-1),
                Inicio = DateTime.Now.AddDays(-1),
                Fim = DateTime.Now.AddDays(1),
                TempoExecucao = 90,
                TotalItens = 20,
                Senha = "123",
                Modalidade = Modalidade.Fundamental,
                QuantidadeRespostaSincronizacao = 1,
                UltimaAtualizacao = DateTime.Now,
                PossuiBIB = false,
                FormatoTai = false,
                Deficiente = false,
                ExibirAudio = false,
                ExibirVideo = false
            };

            var provas = new List<ProvaAnoDto> { prova };

            var provasAluno = new List<ProvaAluno>
            {
                new() { ProvaId = provaId, AlunoRA = alunoRa, Status = ProvaStatus.Iniciado, CriadoEm = DateTime.Now.AddMinutes(-10) }
            };

            var dados = new MeusDadosRetornoDto(456, "DRE", "Escola", "Turma", "Nome", "5", "M", 12, Modalidade.Fundamental, 1, 7, 12, Array.Empty<int>());

            var respostasTai = new List<QuestaoAlunoResposta>
            {
                new() { QuestaoId = 10, AlunoRa = alunoRa },
                new() { QuestaoId = 11, AlunoRa = alunoRa }
            };

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterUsuarioLogadoInformacoesPorClaimsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(claims);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterParametroSistemaPorTiposEAnoQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(parametros);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterTurmasAlunoPorRaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(turmas);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvasPorAnoEModalidadeQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(provas);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvasAdesaoPorAlunoRaETurmaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(Enumerable.Empty<ProvaAnoDto>());
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterDetalhesAlunoCacheQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(dados);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvaAlunoPorProvaIdsRaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(provasAluno);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterCadernoAlunoPorProvaIdRaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync("A");
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterAlunoRespostasPorProvaIdRaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(respostasTai);

            var useCase = new ObterProvasAreaEstudanteUseCase(mediatorMock.Object);

            return new TesteContexto
            {
                MediatorMock = mediatorMock,
                UseCase = useCase,
                Claims = claims,
                Turmas = turmas,
                Prova = prova
            };
        }

        private sealed class TesteContexto
        {
            public Mock<IMediator> MediatorMock { get; init; }
            public ObterProvasAreaEstudanteUseCase UseCase { get; init; }
            public List<ParametroDto> Claims { get; init; }
            public List<Turma> Turmas { get; init; }
            public ProvaAnoDto Prova { get; init; }
        }
    }
}

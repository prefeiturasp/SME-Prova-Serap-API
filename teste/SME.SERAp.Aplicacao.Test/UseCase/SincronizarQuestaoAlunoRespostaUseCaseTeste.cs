using MediatR;
using Moq;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.SERAp.Aplicacao.Test.UseCase
{
    public class SincronizarQuestaoAlunoRespostaUseCaseTeste
    {
        [Fact]
        public void Construtor_Deve_Lancar_Argument_Null_Exception_Quando_Mediator_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => new SincronizarQuestaoAlunoRespostaUseCase(null));
        }

        [Fact]
        public async Task Executar_Deve_Publicar_Resposta_Quando_Prova_Regular()
        {
            var contexto = CriarContextoPadrao();
            contexto.Prova.FormatoTai = false;
            contexto.Prova.PossuiBIB = false;

            var resultado = await contexto.UseCase.Executar(contexto.ListaResposta);

            Assert.True(resultado);
            contexto.MediatorMock.Verify(m => m.Send(It.IsAny<PublicarFilaSerapEstudantesCommand>(), It.IsAny<CancellationToken>()), Times.Once);
            contexto.MediatorMock.Verify(m => m.Send(It.IsAny<PublicarFilaSerapEstudanteAcompanhamentoCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Nao_Deve_Publicar_Quando_Prova_Formato_Tai()
        {
            var contexto = CriarContextoPadrao();
            contexto.Prova.FormatoTai = true;

            var resultado = await contexto.UseCase.Executar(contexto.ListaResposta);

            Assert.True(resultado);
            contexto.MediatorMock.Verify(m => m.Send(It.IsAny<PublicarFilaSerapEstudantesCommand>(), It.IsAny<CancellationToken>()), Times.Never);
            contexto.MediatorMock.Verify(m => m.Send(It.IsAny<PublicarFilaSerapEstudanteAcompanhamentoCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Executar_Deve_Publicar_Quando_Prova_Bib_E_Questao_Existe_Para_Aluno()
        {
            var contexto = CriarContextoPadrao();
            contexto.Prova.FormatoTai = false;
            contexto.Prova.PossuiBIB = true;
            contexto.AlunoRespostas.Add(new QuestaoAlternativaAlunoRespostaDto { QuestaoId = contexto.QuestaoId, AlternativaResposta = 10 });

            var resultado = await contexto.UseCase.Executar(contexto.ListaResposta);

            Assert.True(resultado);
            contexto.MediatorMock.Verify(m => m.Send(It.IsAny<PublicarFilaSerapEstudantesCommand>(), It.IsAny<CancellationToken>()), Times.Once);
            contexto.MediatorMock.Verify(m => m.Send(It.IsAny<PublicarFilaSerapEstudanteAcompanhamentoCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Nao_Deve_Publicar_Quando_Prova_Bib_E_Questao_Nao_Existe_Para_Aluno()
        {
            var contexto = CriarContextoPadrao();
            contexto.Prova.FormatoTai = false;
            contexto.Prova.PossuiBIB = true;

            var resultado = await contexto.UseCase.Executar(contexto.ListaResposta);

            Assert.True(resultado);
            contexto.MediatorMock.Verify(m => m.Send(It.IsAny<PublicarFilaSerapEstudantesCommand>(), It.IsAny<CancellationToken>()), Times.Never);
            contexto.MediatorMock.Verify(m => m.Send(It.IsAny<PublicarFilaSerapEstudanteAcompanhamentoCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        private static TesteContexto CriarContextoPadrao()
        {
            const long provaId = 1;
            const long alunoRa = 123;
            const long questaoId = 10;

            var listaResposta = new List<QuestaoAlunoRespostaSincronizarDto>
            {
                new()
                {
                    AlunoRa = alunoRa,
                    QuestaoId = questaoId,
                    AlternativaId = 1000,
                    TempoRespostaAluno = 12,
                    DataHoraRespostaTicks = DateTime.Now.Ticks
                }
            };

            var provas = new List<ProvaQuestaoDto>
            {
                new() { ProvaId = provaId, ProvaLegadoId = 999 }
            };

            var prova = new SME.SERAp.Prova.Dominio.Prova { Id = provaId, FormatoTai = false, PossuiBIB = false };
            var alunoRespostas = new List<QuestaoAlternativaAlunoRespostaDto>();

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvasEmAndamentoPorQuestaoIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(provas);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterProvaPorIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(prova);
            mediatorMock.Setup(m => m.Send(It.IsAny<ObterAlternativaAlunoRespostaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(alunoRespostas);
            mediatorMock.Setup(m => m.Send(It.IsAny<PublicarFilaSerapEstudantesCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            mediatorMock.Setup(m => m.Send(It.IsAny<PublicarFilaSerapEstudanteAcompanhamentoCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            var useCase = new SincronizarQuestaoAlunoRespostaUseCase(mediatorMock.Object);

            return new TesteContexto
            {
                MediatorMock = mediatorMock,
                UseCase = useCase,
                ListaResposta = listaResposta,
                Prova = prova,
                AlunoRespostas = alunoRespostas,
                QuestaoId = questaoId
            };
        }

        private sealed class TesteContexto
        {
            public Mock<IMediator> MediatorMock { get; init; }
            public SincronizarQuestaoAlunoRespostaUseCase UseCase { get; init; }
            public List<QuestaoAlunoRespostaSincronizarDto> ListaResposta { get; init; }
            public SME.SERAp.Prova.Dominio.Prova Prova { get; init; }
            public List<QuestaoAlternativaAlunoRespostaDto> AlunoRespostas { get; init; }
            public long QuestaoId { get; init; }
        }
    }
}

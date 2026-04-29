using MediatR;
using Moq;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.SERAp.Aplicacao.Test.UseCase
{
    public class ObterMeusDadosUseCaseTeste
    {
        private readonly Mock<IMediator> mediator;
        private readonly long usuarioLogadoRa;
        private readonly MeusDadosRetornoDto meusDados;

        public ObterMeusDadosUseCaseTeste()
        {
            mediator = new Mock<IMediator>();
            usuarioLogadoRa = 12345678;

            meusDados = new MeusDadosRetornoDto(
                alunoId: usuarioLogadoRa,
                dreAbreviacao: "DRE - Teste",
                escola: "EMEF Teste",
                turma: "9º A",
                nome: "João da Silva",
                ano: "9",
                tipoTurno: "Manhã",
                tamanhoFonte: 14,
                modalidade: Modalidade.Fundamental,
                familiaFonte: 1,
                inicioTurno: 7,
                fimTurno: 12,
                deficiencias: new int[] { }
            );
        }

        private void ConfigurarMocksParaSucesso()
        {
            mediator
                .Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(usuarioLogadoRa);

            mediator
                .Setup(m => m.Send(It.IsAny<ObterDetalhesAlunoCacheQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(meusDados);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Dados_Aluno_Quando_Sucesso()
        {
            ConfigurarMocksParaSucesso();

            var useCase = new ObterMeusDadosUseCase(mediator.Object);

            var resultado = await useCase.Executar();

            Assert.NotNull(resultado);
            Assert.Equal(usuarioLogadoRa, resultado.AlunoId);
            Assert.Equal(meusDados.Nome, resultado.Nome);
            Assert.Equal(meusDados.Ano, resultado.Ano);
            Assert.Equal(meusDados.TipoTurno, resultado.TipoTurno);
            Assert.Equal(meusDados.Modalidade, resultado.Modalidade);
            Assert.Equal(meusDados.Turma, resultado.Turma);
            Assert.Equal(meusDados.Escola, resultado.Escola);
            Assert.Equal(meusDados.DreAbreviacao, resultado.DreAbreviacao);
            Assert.Equal(meusDados.TamanhoFonte, resultado.TamanhoFonte);
            Assert.Equal(meusDados.FamiliaFonte, resultado.FamiliaFonte);
            Assert.Equal(meusDados.InicioTurno, resultado.InicioTurno);
            Assert.Equal(meusDados.FimTurno, resultado.FimTurno);

            mediator.Verify(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(m => m.Send(It.IsAny<ObterDetalhesAlunoCacheQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Excecao_Quando_Aluno_Nao_Encontrado()
        {
            mediator
                .Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(usuarioLogadoRa);

            mediator
                .Setup(m => m.Send(It.IsAny<ObterDetalhesAlunoCacheQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((MeusDadosRetornoDto)null);

            var useCase = new ObterMeusDadosUseCase(mediator.Object);

            var exception = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar());

            Assert.Equal($"Não foi possível localizar os dados do aluno {usuarioLogadoRa}", exception.Message);

            mediator.Verify(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(m => m.Send(It.IsAny<ObterDetalhesAlunoCacheQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Obter_RA_Usuario_Logado()
        {
            ConfigurarMocksParaSucesso();

            ObterRAUsuarioLogadoQuery queryCapturada = null;
            mediator
                .Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>()))
                .Callback<IRequest<long>, CancellationToken>((query, token) =>
                {
                    queryCapturada = query as ObterRAUsuarioLogadoQuery;
                })
                .ReturnsAsync(usuarioLogadoRa);

            var useCase = new ObterMeusDadosUseCase(mediator.Object);

            var resultado = await useCase.Executar();

            Assert.NotNull(resultado);
            Assert.NotNull(queryCapturada);

            mediator.Verify(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Buscar_Detalhes_Com_RA_Correto()
        {
            ConfigurarMocksParaSucesso();

            ObterDetalhesAlunoCacheQuery queryCapturada = null;
            mediator
                .Setup(m => m.Send(It.IsAny<ObterDetalhesAlunoCacheQuery>(), It.IsAny<CancellationToken>()))
                .Callback<IRequest<MeusDadosRetornoDto>, CancellationToken>((query, token) =>
                {
                    queryCapturada = query as ObterDetalhesAlunoCacheQuery;
                })
                .ReturnsAsync(meusDados);

            var useCase = new ObterMeusDadosUseCase(mediator.Object);

            var resultado = await useCase.Executar();

            Assert.NotNull(resultado);
            Assert.NotNull(queryCapturada);
            Assert.Equal(usuarioLogadoRa, queryCapturada.AlunoRA);

            mediator.Verify(m => m.Send(It.IsAny<ObterDetalhesAlunoCacheQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Dados_Completos_Do_Aluno()
        {
            var dadosCompletos = new MeusDadosRetornoDto(
                alunoId: 98765432,
                dreAbreviacao: "DRE - Sul",
                escola: "EMEF Escola Teste 2",
                turma: "7º B",
                nome: "Maria Oliveira",
                ano: "7",
                tipoTurno: "Tarde",
                tamanhoFonte: 16,
                modalidade: Modalidade.Medio,
                familiaFonte: 2,
                inicioTurno: 13,
                fimTurno: 18,
                deficiencias: new int[] { 1, 2 }
            );

            mediator
                .Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(dadosCompletos.AlunoId);

            mediator
                .Setup(m => m.Send(It.IsAny<ObterDetalhesAlunoCacheQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(dadosCompletos);

            var useCase = new ObterMeusDadosUseCase(mediator.Object);

            var resultado = await useCase.Executar();

            Assert.NotNull(resultado);
            Assert.Equal(dadosCompletos.AlunoId, resultado.AlunoId);
            Assert.Equal(dadosCompletos.Nome, resultado.Nome);
            Assert.Equal(dadosCompletos.Ano, resultado.Ano);
            Assert.Equal(dadosCompletos.TipoTurno, resultado.TipoTurno);
            Assert.Equal(dadosCompletos.Modalidade, resultado.Modalidade);
            Assert.Equal(dadosCompletos.Turma, resultado.Turma);
            Assert.Equal(dadosCompletos.Escola, resultado.Escola);
            Assert.Equal(dadosCompletos.DreAbreviacao, resultado.DreAbreviacao);
            Assert.Equal(dadosCompletos.TamanhoFonte, resultado.TamanhoFonte);
            Assert.Equal(dadosCompletos.FamiliaFonte, resultado.FamiliaFonte);
            Assert.Equal(dadosCompletos.InicioTurno, resultado.InicioTurno);
            Assert.Equal(dadosCompletos.FimTurno, resultado.FimTurno);
            Assert.Equal(dadosCompletos.Deficiencias, resultado.Deficiencias);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Excecao_Com_Mensagem_Personalizada_Por_RA()
        {
            var raEspecifico = 11223344L;

            mediator
                .Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(raEspecifico);

            mediator
                .Setup(m => m.Send(It.IsAny<ObterDetalhesAlunoCacheQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((MeusDadosRetornoDto)null);

            var useCase = new ObterMeusDadosUseCase(mediator.Object);

            var exception = await Assert.ThrowsAsync<NegocioException>(() => useCase.Executar());

            Assert.Contains(raEspecifico.ToString(), exception.Message);
            Assert.Equal($"Não foi possível localizar os dados do aluno {raEspecifico}", exception.Message);
        }

        [Fact]
        public async Task Executar_Deve_Executar_Queries_Na_Ordem_Correta()
        {
            var execucoes = new System.Collections.Generic.List<string>();

            mediator
                .Setup(m => m.Send(It.IsAny<ObterRAUsuarioLogadoQuery>(), It.IsAny<CancellationToken>()))
                .Callback(() => execucoes.Add("ObterRAUsuarioLogadoQuery"))
                .ReturnsAsync(usuarioLogadoRa);

            mediator
                .Setup(m => m.Send(It.IsAny<ObterDetalhesAlunoCacheQuery>(), It.IsAny<CancellationToken>()))
                .Callback(() => execucoes.Add("ObterDetalhesAlunoCacheQuery"))
                .ReturnsAsync(meusDados);

            var useCase = new ObterMeusDadosUseCase(mediator.Object);

            var resultado = await useCase.Executar();

            Assert.NotNull(resultado);
            Assert.Equal(2, execucoes.Count);
            Assert.Equal("ObterRAUsuarioLogadoQuery", execucoes[0]);
            Assert.Equal("ObterDetalhesAlunoCacheQuery", execucoes[1]);
        }
    }
}

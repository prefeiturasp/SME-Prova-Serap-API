using MediatR;
using Moq;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.SERAp.Aplicacao.Test.UseCase
{
    public class AutenticarUsuarioValidarAdmUseCaseTeste
    {
        private readonly Mock<IMediator> mediator;
        private readonly AutenticacaoValidarAdmDto autenticacaoValidarAdmDto;
        private readonly AutenticacaoUsuarioAdmDto usuarioAdmDto;
        private readonly string codigo;
        private readonly DateTime dataExpiracao;
        private readonly string token;

        public AutenticarUsuarioValidarAdmUseCaseTeste()
        {
            mediator = new Mock<IMediator>();

            codigo = "123456";

            autenticacaoValidarAdmDto = new AutenticacaoValidarAdmDto(codigo);

            usuarioAdmDto = new AutenticacaoUsuarioAdmDto(
                login: "admin-teste",
                nome: "Admin Teste",
                perfil: Guid.NewGuid()
            );

            token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...";
            dataExpiracao = DateTime.UtcNow.AddHours(1);
        }

        private void ConfigurarMocksParaValidacaoSucesso()
        {
            mediator
                .Setup(m => m.Send(It.IsAny<ObterCodigoValidacaoAdmQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(usuarioAdmDto);

            mediator
                .Setup(m => m.Send(It.IsAny<ObterTokenJwtAdmQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((token, dataExpiracao));
        }

        [Fact]
        public void Construtor_Deve_Lancar_Argument_Null_Exception_Quando_Mediator_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => new AutenticarUsuarioValidarAdmUseCase(null));
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Token_Quando_Validacao_Sucesso()
        {
            ConfigurarMocksParaValidacaoSucesso();

            var useCase = new AutenticarUsuarioValidarAdmUseCase(mediator.Object);

            var resultado = await useCase.Executar(autenticacaoValidarAdmDto);

            Assert.NotNull(resultado);
            Assert.Equal(token, resultado.Token);
            Assert.Equal(dataExpiracao, resultado.DataHoraExpiracao);

            mediator.Verify(m => m.Send(It.IsAny<ObterCodigoValidacaoAdmQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(m => m.Send(It.IsAny<ObterTokenJwtAdmQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Excecao_Quando_Codigo_Invalido()
        {
            ConfigurarMocksParaValidacaoSucesso();

            mediator
                .Setup(m => m.Send(It.IsAny<ObterCodigoValidacaoAdmQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((AutenticacaoUsuarioAdmDto)null);

            var useCase = new AutenticarUsuarioValidarAdmUseCase(mediator.Object);

            var exception = await Assert.ThrowsAsync<NaoAutorizadoException>(() => useCase.Executar(autenticacaoValidarAdmDto));

            Assert.Equal("Código inválido", exception.Message);
            Assert.Equal(401, exception.StatusCode);

            mediator.Verify(m => m.Send(It.IsAny<ObterCodigoValidacaoAdmQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(m => m.Send(It.IsAny<ObterTokenJwtAdmQuery>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Executar_Deve_Enviar_Codigo_Correto_Para_Obter_Validacao()
        {
            ConfigurarMocksParaValidacaoSucesso();

            ObterCodigoValidacaoAdmQuery queryCapturada = null;
            mediator
                .Setup(m => m.Send(It.IsAny<ObterCodigoValidacaoAdmQuery>(), It.IsAny<CancellationToken>()))
                .Callback<IRequest<AutenticacaoUsuarioAdmDto>, CancellationToken>((query, token) =>
                {
                    queryCapturada = query as ObterCodigoValidacaoAdmQuery;
                })
                .ReturnsAsync(usuarioAdmDto);

            var useCase = new AutenticarUsuarioValidarAdmUseCase(mediator.Object);

            var resultado = await useCase.Executar(autenticacaoValidarAdmDto);

            Assert.NotNull(resultado);
            Assert.NotNull(queryCapturada);
            Assert.Equal(codigo, queryCapturada.Codigo);

            mediator.Verify(m => m.Send(It.IsAny<ObterCodigoValidacaoAdmQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Gerar_Token_Com_Parametros_Corretos()
        {
            ConfigurarMocksParaValidacaoSucesso();

            ObterTokenJwtAdmQuery queryCapturada = null;
            mediator
                .Setup(m => m.Send(It.IsAny<ObterTokenJwtAdmQuery>(), It.IsAny<CancellationToken>()))
                .Callback<IRequest<(string, DateTime)>, CancellationToken>((query, token) =>
                {
                    queryCapturada = query as ObterTokenJwtAdmQuery;
                })
                .ReturnsAsync((token, dataExpiracao));

            var useCase = new AutenticarUsuarioValidarAdmUseCase(mediator.Object);

            var resultado = await useCase.Executar(autenticacaoValidarAdmDto);

            Assert.NotNull(resultado);
            Assert.NotNull(queryCapturada);
            Assert.Equal(usuarioAdmDto.Login, queryCapturada.Login);
            Assert.Equal(usuarioAdmDto.Nome, queryCapturada.Nome);
            Assert.Equal(usuarioAdmDto.Perfil, queryCapturada.Perfil);

            mediator.Verify(m => m.Send(It.IsAny<ObterTokenJwtAdmQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Executar_Operacoes_Na_Ordem_Correta()
        {
            ConfigurarMocksParaValidacaoSucesso();

            var execucoes = new System.Collections.Generic.List<string>();

            mediator
                .Setup(m => m.Send(It.IsAny<ObterCodigoValidacaoAdmQuery>(), It.IsAny<CancellationToken>()))
                .Callback(() => execucoes.Add("ObterCodigo"))
                .ReturnsAsync(usuarioAdmDto);

            mediator
                .Setup(m => m.Send(It.IsAny<ObterTokenJwtAdmQuery>(), It.IsAny<CancellationToken>()))
                .Callback(() => execucoes.Add("GerarToken"))
                .ReturnsAsync((token, dataExpiracao));

            var useCase = new AutenticarUsuarioValidarAdmUseCase(mediator.Object);

            var resultado = await useCase.Executar(autenticacaoValidarAdmDto);

            Assert.NotNull(resultado);
            Assert.Equal(2, execucoes.Count);
            Assert.Equal("ObterCodigo", execucoes[0]);
            Assert.Equal("GerarToken", execucoes[1]);
        }

        [Fact]
        public async Task Executar_Deve_Mapear_Todos_Campos_Do_Resultado()
        {
            var loginEsperado = "admin-especifico";
            var nomeEsperado = "Admin Especifico";
            var perfilEsperado = Guid.NewGuid();
            var tokenEsperado = "token-unico-teste";
            var dataExpiracaoEsperada = DateTime.UtcNow.AddHours(2);

            var usuarioEspecifico = new AutenticacaoUsuarioAdmDto(loginEsperado, nomeEsperado, perfilEsperado);

            mediator
                .Setup(m => m.Send(It.IsAny<ObterCodigoValidacaoAdmQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(usuarioEspecifico);

            mediator
                .Setup(m => m.Send(It.IsAny<ObterTokenJwtAdmQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((tokenEsperado, dataExpiracaoEsperada));

            var useCase = new AutenticarUsuarioValidarAdmUseCase(mediator.Object);

            var resultado = await useCase.Executar(autenticacaoValidarAdmDto);

            Assert.NotNull(resultado);
            Assert.Equal(tokenEsperado, resultado.Token);
            Assert.Equal(dataExpiracaoEsperada, resultado.DataHoraExpiracao);
        }

        [Fact]
        public async Task Executar_Deve_Usar_Dados_Do_Usuario_Obtido_Para_Token()
        {
            var usuarioComDadosEspecificos = new AutenticacaoUsuarioAdmDto(
                login: "login-unico",
                nome: "Nome Unico",
                perfil: Guid.NewGuid()
            );

            mediator
                .Setup(m => m.Send(It.IsAny<ObterCodigoValidacaoAdmQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(usuarioComDadosEspecificos);

            ObterTokenJwtAdmQuery queryToken = null;
            mediator
                .Setup(m => m.Send(It.IsAny<ObterTokenJwtAdmQuery>(), It.IsAny<CancellationToken>()))
                .Callback<IRequest<(string, DateTime)>, CancellationToken>((query, token) =>
                {
                    queryToken = query as ObterTokenJwtAdmQuery;
                })
                .ReturnsAsync((token, dataExpiracao));

            var useCase = new AutenticarUsuarioValidarAdmUseCase(mediator.Object);

            var resultado = await useCase.Executar(autenticacaoValidarAdmDto);

            Assert.NotNull(resultado);
            Assert.NotNull(queryToken);
            Assert.Equal(usuarioComDadosEspecificos.Login, queryToken.Login);
            Assert.Equal(usuarioComDadosEspecificos.Nome, queryToken.Nome);
            Assert.Equal(usuarioComDadosEspecificos.Perfil, queryToken.Perfil);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Usuario_Autenticacao_Dto()
        {
            ConfigurarMocksParaValidacaoSucesso();

            var useCase = new AutenticarUsuarioValidarAdmUseCase(mediator.Object);

            var resultado = await useCase.Executar(autenticacaoValidarAdmDto);

            Assert.NotNull(resultado);
            Assert.IsType<UsuarioAutenticacaoDto>(resultado);
        }

        [Fact]
        public async Task Executar_Deve_Lan_CarExpiracao_No_Resultado()
        {
            var dataExpiracaoEsperada = DateTime.UtcNow.AddHours(3);

            mediator
                .Setup(m => m.Send(It.IsAny<ObterCodigoValidacaoAdmQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(usuarioAdmDto);

            mediator
                .Setup(m => m.Send(It.IsAny<ObterTokenJwtAdmQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((token, dataExpiracaoEsperada));

            var useCase = new AutenticarUsuarioValidarAdmUseCase(mediator.Object);

            var resultado = await useCase.Executar(autenticacaoValidarAdmDto);

            Assert.NotNull(resultado);
            Assert.Equal(dataExpiracaoEsperada, resultado.DataHoraExpiracao);
        }
    }
}

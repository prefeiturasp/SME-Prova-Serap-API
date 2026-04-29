using MediatR;
using Moq;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Dominio.Constantes;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.SERAp.Aplicacao.Test.UseCase
{
    public class AutenticarUsuarioAdmUseCaseTeste
    {
        private readonly Mock<IMediator> mediator;
        private readonly AutenticacaoAdmDto autenticacaoDto;
        private readonly UsuarioSerapCoreSSO usuario;
        private readonly string chaveApiValida;
        private readonly Guid perfilValido;
        private readonly AutenticacaoValidarAdmDto autenticacaoEsperada;

        public AutenticarUsuarioAdmUseCaseTeste()
        {
            mediator = new Mock<IMediator>();

            chaveApiValida = "chave-api-valida-teste";
            perfilValido = Perfis.PERFIL_ADMINISTRADOR;

            autenticacaoDto = new AutenticacaoAdmDto
            {
                Login = "admin-teste",
                Perfil = perfilValido.ToString(),
                ChaveApi = chaveApiValida
            };

            usuario = new UsuarioSerapCoreSSO
            {
                IdCoreSSO = Guid.NewGuid(),
                Login = autenticacaoDto.Login,
                Nome = "Admin Teste",
                CriadoEm = DateTime.Now,
                AtualizadoEm = DateTime.Now
            };

            autenticacaoEsperada = new AutenticacaoValidarAdmDto("codigo-validacao-teste");
        }

        private void ConfigurarMocksParaAutenticacaoSucesso()
        {
            // Configurar variável de ambiente para a chave API
            Environment.SetEnvironmentVariable("ChaveSerapProvaApi", chaveApiValida);

            mediator
                .Setup(m => m.Send(It.IsAny<ObterUsuarioSerapCoreSSOPorLoginQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(usuario);

            mediator
                .Setup(m => m.Send(It.IsAny<GerarCodigoValidacaoAdmCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(autenticacaoEsperada);
        }

        private void LimparMocksParaAutenticacaoSucesso()
        {
            Environment.SetEnvironmentVariable("ChaveSerapProvaApi", null);
        }

        [Fact]
        public void Construtor_Deve_Lancar_Argument_Null_Exception_Quando_Mediator_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => new AutenticarUsuarioAdmUseCase(null));
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Codigo_Validacao_Quando_Autenticacao_Sucesso()
        {
            ConfigurarMocksParaAutenticacaoSucesso();

            try
            {
                var useCase = new AutenticarUsuarioAdmUseCase(mediator.Object);

                var resultado = await useCase.Executar(autenticacaoDto);

                Assert.NotNull(resultado);
                Assert.Equal(autenticacaoEsperada.Codigo, resultado.Codigo);

                mediator.Verify(m => m.Send(It.IsAny<ObterUsuarioSerapCoreSSOPorLoginQuery>(), It.IsAny<CancellationToken>()), Times.Once);
                mediator.Verify(m => m.Send(It.IsAny<GerarCodigoValidacaoAdmCommand>(), It.IsAny<CancellationToken>()), Times.Once);
            }
            finally
            {
                LimparMocksParaAutenticacaoSucesso();
            }
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Excecao_Quando_Usuario_Nao_Encontrado()
        {
            ConfigurarMocksParaAutenticacaoSucesso();

            mediator
                .Setup(m => m.Send(It.IsAny<ObterUsuarioSerapCoreSSOPorLoginQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((UsuarioSerapCoreSSO)null);

            try
            {
                var useCase = new AutenticarUsuarioAdmUseCase(mediator.Object);

                var exception = await Assert.ThrowsAsync<NaoAutorizadoException>(() => useCase.Executar(autenticacaoDto));

                Assert.Equal("Usuário inválido", exception.Message);
                Assert.Equal(401, exception.StatusCode);

                mediator.Verify(m => m.Send(It.IsAny<ObterUsuarioSerapCoreSSOPorLoginQuery>(), It.IsAny<CancellationToken>()), Times.Once);
                mediator.Verify(m => m.Send(It.IsAny<GerarCodigoValidacaoAdmCommand>(), It.IsAny<CancellationToken>()), Times.Never);
            }
            finally
            {
                LimparMocksParaAutenticacaoSucesso();
            }
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Excecao_Quando_Chave_Api_Invalida()
        {
            ConfigurarMocksParaAutenticacaoSucesso();

            var autenticacaoComChaveInvalida = new AutenticacaoAdmDto
            {
                Login = autenticacaoDto.Login,
                Perfil = autenticacaoDto.Perfil,
                ChaveApi = "chave-invalida"
            };

            try
            {
                var useCase = new AutenticarUsuarioAdmUseCase(mediator.Object);

                var exception = await Assert.ThrowsAsync<NaoAutorizadoException>(() => useCase.Executar(autenticacaoComChaveInvalida));

                Assert.Equal("Chave api inválida", exception.Message);
                Assert.Equal(401, exception.StatusCode);

                mediator.Verify(m => m.Send(It.IsAny<ObterUsuarioSerapCoreSSOPorLoginQuery>(), It.IsAny<CancellationToken>()), Times.Once);
                mediator.Verify(m => m.Send(It.IsAny<GerarCodigoValidacaoAdmCommand>(), It.IsAny<CancellationToken>()), Times.Never);
            }
            finally
            {
                LimparMocksParaAutenticacaoSucesso();
            }
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Excecao_Quando_Perfil_Invalido()
        {
            ConfigurarMocksParaAutenticacaoSucesso();

            var autenticacaoComPerfilInvalido = new AutenticacaoAdmDto
            {
                Login = autenticacaoDto.Login,
                Perfil = "perfil-invalido",
                ChaveApi = autenticacaoDto.ChaveApi
            };

            try
            {
                var useCase = new AutenticarUsuarioAdmUseCase(mediator.Object);

                var exception = await Assert.ThrowsAsync<NaoAutorizadoException>(() => useCase.Executar(autenticacaoComPerfilInvalido));

                Assert.Equal("Perfil Inválido", exception.Message);
                Assert.Equal(401, exception.StatusCode);

                mediator.Verify(m => m.Send(It.IsAny<ObterUsuarioSerapCoreSSOPorLoginQuery>(), It.IsAny<CancellationToken>()), Times.Once);
                mediator.Verify(m => m.Send(It.IsAny<GerarCodigoValidacaoAdmCommand>(), It.IsAny<CancellationToken>()), Times.Never);
            }
            finally
            {
                LimparMocksParaAutenticacaoSucesso();
            }
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Excecao_Quando_Perfil_Nao_Eh_Guid()
        {
            ConfigurarMocksParaAutenticacaoSucesso();

            var autenticacaoComPerfilNaoGuid = new AutenticacaoAdmDto
            {
                Login = autenticacaoDto.Login,
                Perfil = "nao-eh-guid",
                ChaveApi = autenticacaoDto.ChaveApi
            };

            try
            {
                var useCase = new AutenticarUsuarioAdmUseCase(mediator.Object);

                var exception = await Assert.ThrowsAsync<NaoAutorizadoException>(() => useCase.Executar(autenticacaoComPerfilNaoGuid));

                Assert.Equal("Perfil Inválido", exception.Message);
                Assert.Equal(401, exception.StatusCode);

                mediator.Verify(m => m.Send(It.IsAny<GerarCodigoValidacaoAdmCommand>(), It.IsAny<CancellationToken>()), Times.Never);
            }
            finally
            {
                LimparMocksParaAutenticacaoSucesso();
            }
        }

        [Fact]
        public async Task Executar_Deve_Enviar_Login_Correto_Para_Obter_Usuario()
        {
            ConfigurarMocksParaAutenticacaoSucesso();

            ObterUsuarioSerapCoreSSOPorLoginQuery queryCapturada = null;
            mediator
                .Setup(m => m.Send(It.IsAny<ObterUsuarioSerapCoreSSOPorLoginQuery>(), It.IsAny<CancellationToken>()))
                .Callback<IRequest<UsuarioSerapCoreSSO>, CancellationToken>((query, token) =>
                {
                    queryCapturada = query as ObterUsuarioSerapCoreSSOPorLoginQuery;
                })
                .ReturnsAsync(usuario);

            try
            {
                var useCase = new AutenticarUsuarioAdmUseCase(mediator.Object);

                var resultado = await useCase.Executar(autenticacaoDto);

                Assert.NotNull(resultado);
                Assert.NotNull(queryCapturada);
                Assert.Equal(autenticacaoDto.Login, queryCapturada.Login);

                mediator.Verify(m => m.Send(It.IsAny<ObterUsuarioSerapCoreSSOPorLoginQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            }
            finally
            {
                LimparMocksParaAutenticacaoSucesso();
            }
        }

        [Fact]
        public async Task Executar_Deve_Gerar_Codigo_Validacao_Com_Parametros_Corretos()
        {
            ConfigurarMocksParaAutenticacaoSucesso();

            GerarCodigoValidacaoAdmCommand commandCapturado = null;
            mediator
                .Setup(m => m.Send(It.IsAny<GerarCodigoValidacaoAdmCommand>(), It.IsAny<CancellationToken>()))
                .Callback<IRequest<AutenticacaoValidarAdmDto>, CancellationToken>((cmd, token) =>
                {
                    commandCapturado = cmd as GerarCodigoValidacaoAdmCommand;
                })
                .ReturnsAsync(autenticacaoEsperada);

            try
            {
                var useCase = new AutenticarUsuarioAdmUseCase(mediator.Object);

                var resultado = await useCase.Executar(autenticacaoDto);

                Assert.NotNull(resultado);
                Assert.NotNull(commandCapturado);
                Assert.Equal(autenticacaoDto.Login, commandCapturado.Login);
                Assert.Equal(usuario.Nome, commandCapturado.Nome);
                Assert.Equal(perfilValido, commandCapturado.Perfil);

                mediator.Verify(m => m.Send(It.IsAny<GerarCodigoValidacaoAdmCommand>(), It.IsAny<CancellationToken>()), Times.Once);
            }
            finally
            {
                LimparMocksParaAutenticacaoSucesso();
            }
        }

        [Fact]
        public async Task Executar_Deve_Aceitar_Todos_Perfis_Validos()
        {
            var perfisValidos = new[]
            {
                Perfis.PERFIL_ADMINISTRADOR,
                Perfis.PERFIL_ADMINISTRADOR_SERAP_DRE,
                Perfis.PERFIL_ADMINISTRADOR_NTA,
                Perfis.PERFIL_ADMINISTRADOR_SERAP_UE,
                Perfis.PERFIL_ASSISTENTE_DIRETOR_UE,
                Perfis.PERFIL_COORDENADOR_PEDAGOGICO,
                Perfis.PERFIL_DIRETOR_ESCOLAR,
                Perfis.PERFIL_PROFESSOR,
                Perfis.PERFIL_PROFESSOR_OLD,
                Perfis.PERFIL_ADM_COPED_LEITURA
            };

            foreach (var perfil in perfisValidos)
            {
                ConfigurarMocksParaAutenticacaoSucesso();

                var autenticacaoComPerfil = new AutenticacaoAdmDto
                {
                    Login = autenticacaoDto.Login,
                    Perfil = perfil.ToString(),
                    ChaveApi = chaveApiValida
                };

                try
                {
                    var useCase = new AutenticarUsuarioAdmUseCase(mediator.Object);

                    var resultado = await useCase.Executar(autenticacaoComPerfil);

                    Assert.NotNull(resultado);
                    Assert.Equal(autenticacaoEsperada.Codigo, resultado.Codigo);
                }
                finally
                {
                    LimparMocksParaAutenticacaoSucesso();
                    mediator.Reset();
                }
            }
        }

        [Fact]
        public async Task Executar_Deve_Executar_Validacoes_Na_Ordem_Correta()
        {
            ConfigurarMocksParaAutenticacaoSucesso();

            var execucoes = new System.Collections.Generic.List<string>();

            mediator
                .Setup(m => m.Send(It.IsAny<ObterUsuarioSerapCoreSSOPorLoginQuery>(), It.IsAny<CancellationToken>()))
                .Callback(() => execucoes.Add("ObterUsuario"))
                .ReturnsAsync(usuario);

            mediator
                .Setup(m => m.Send(It.IsAny<GerarCodigoValidacaoAdmCommand>(), It.IsAny<CancellationToken>()))
                .Callback(() => execucoes.Add("GerarCodigo"))
                .ReturnsAsync(autenticacaoEsperada);

            try
            {
                var useCase = new AutenticarUsuarioAdmUseCase(mediator.Object);

                var resultado = await useCase.Executar(autenticacaoDto);

                Assert.NotNull(resultado);
                Assert.Equal(2, execucoes.Count);
                Assert.Equal("ObterUsuario", execucoes[0]);
                Assert.Equal("GerarCodigo", execucoes[1]);
            }
            finally
            {
                LimparMocksParaAutenticacaoSucesso();
            }
        }
    }
}

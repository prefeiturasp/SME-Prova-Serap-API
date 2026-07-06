using MediatR;
using Moq;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using SME.SERAp.Prova.Infra.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.SERAp.Aplicacao.Test.UseCase
{
    public class AutenticarUsuarioUseCaseTeste
    {
        private readonly Mock<IMediator> mediator;
        private readonly AutenticacaoDto autenticacaoDto;
        private readonly ObterAlunoAtivoRetornoDto aluno;
        private readonly string tokenEsperado;
        private readonly DateTime dataExpiracaoEsperada;

        public AutenticarUsuarioUseCaseTeste()
        {
            mediator = new Mock<IMediator>();

            autenticacaoDto = new AutenticacaoDto
            {
                Login = 12345678,
                Senha = "15052010",
                Dispositivo = "dispositivo-teste"
            };

            aluno = new ObterAlunoAtivoRetornoDto
            {
                Ra = 12345678,
                Ano = "9",
                TipoTurno = 1,
                Modalidade = Modalidade.Fundamental,
                TurmaId = 100,
                DataNascimento = new DateTime(2010, 5, 15)
            };

            tokenEsperado = "token-jwt-teste";
            dataExpiracaoEsperada = DateTime.Now.AddHours(1);
        }

        private void ConfigurarMocksParaAutenticacaoSucesso()
        {
            mediator
                .Setup(m => m.Send(It.IsAny<ObterAlunoAtivoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(aluno);

            mediator
                .Setup(m => m.Send(It.IsAny<VerificaAutenticacaoUsuarioQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediator
                .Setup(m => m.Send(It.IsAny<ObterTokenJwtQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((tokenEsperado, dataExpiracaoEsperada));

            mediator
                .Setup(m => m.Send(It.IsAny<IncluirOuAtualizarUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediator
                .Setup(m => m.Send(It.IsAny<RemoverCacheCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            mediator
                .Setup(m => m.Send(It.IsAny<PublicarFilaSerapEstudantesCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
        }

        [Fact]
        public void Construtor_Deve_Lancar_Argument_Null_Exception_Quando_Mediator_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => new AutenticarUsuarioUseCase(null));
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Token_Quando_Autenticacao_Sucesso()
        {
            ConfigurarMocksParaAutenticacaoSucesso();

            var useCase = new AutenticarUsuarioUseCase(mediator.Object);

            var resultado = await useCase.Executar(autenticacaoDto);

            Assert.NotNull(resultado);
            Assert.Equal(tokenEsperado, resultado.Token);
            Assert.Equal(dataExpiracaoEsperada, resultado.DataHoraExpiracao);
            Assert.NotNull(resultado.UltimoLogin);
            Assert.True(resultado.UltimoLogin <= DateTime.Now);

            mediator.Verify(m => m.Send(It.IsAny<ObterAlunoAtivoQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(m => m.Send(It.IsAny<VerificaAutenticacaoUsuarioQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(m => m.Send(It.IsAny<ObterTokenJwtQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(m => m.Send(It.IsAny<IncluirOuAtualizarUsuarioCommand>(), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(m => m.Send(It.IsAny<RemoverCacheCommand>(), It.IsAny<CancellationToken>()), Times.Exactly(4));
            mediator.Verify(m => m.Send(It.IsAny<PublicarFilaSerapEstudantesCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Excecao_Quando_Aluno_Nao_Encontrado()
        {
            mediator
                .Setup(m => m.Send(It.IsAny<ObterAlunoAtivoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ObterAlunoAtivoRetornoDto)null);

            var useCase = new AutenticarUsuarioUseCase(mediator.Object);

            var exception = await Assert.ThrowsAsync<NaoAutorizadoException>(() => useCase.Executar(autenticacaoDto));

            Assert.Equal($"Código EOL {autenticacaoDto.Login} inválido", exception.Message);
            Assert.Equal(411, exception.StatusCode);

            mediator.Verify(m => m.Send(It.IsAny<ObterAlunoAtivoQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(m => m.Send(It.IsAny<VerificaAutenticacaoUsuarioQuery>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Excecao_Quando_Senha_Invalida()
        {
            mediator
                .Setup(m => m.Send(It.IsAny<ObterAlunoAtivoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(aluno);

            mediator
                .Setup(m => m.Send(It.IsAny<VerificaAutenticacaoUsuarioQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var useCase = new AutenticarUsuarioUseCase(mediator.Object);

            var exception = await Assert.ThrowsAsync<NaoAutorizadoException>(() => useCase.Executar(autenticacaoDto));

            Assert.Equal("Senha inválida", exception.Message);
            Assert.Equal(412, exception.StatusCode);

            mediator.Verify(m => m.Send(It.IsAny<ObterAlunoAtivoQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(m => m.Send(It.IsAny<VerificaAutenticacaoUsuarioQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(m => m.Send(It.IsAny<ObterTokenJwtQuery>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Executar_Deve_Publicar_Fila_Com_Dispositivo_Vazio_Quando_Dispositivo_Nulo()
        {
            var autenticacaoSemDispositivo = new AutenticacaoDto
            {
                Login = autenticacaoDto.Login,
                Senha = autenticacaoDto.Senha,
                Dispositivo = null
            };

            ConfigurarMocksParaAutenticacaoSucesso();

            UsuarioDispositivoLoginDto usuarioDispositivoCapturado = null;
            mediator
                .Setup(m => m.Send(It.IsAny<PublicarFilaSerapEstudantesCommand>(), It.IsAny<CancellationToken>()))
                .Callback<IRequest<bool>, CancellationToken>((cmd, token) =>
                {
                    if (cmd is PublicarFilaSerapEstudantesCommand command)
                    {
                        usuarioDispositivoCapturado = command.Mensagem as UsuarioDispositivoLoginDto;
                    }
                })
                .ReturnsAsync(true);

            var useCase = new AutenticarUsuarioUseCase(mediator.Object);

            var resultado = await useCase.Executar(autenticacaoSemDispositivo);

            Assert.NotNull(resultado);
            Assert.NotNull(usuarioDispositivoCapturado);
            Assert.Equal(string.Empty, usuarioDispositivoCapturado.DispositivoId);
            Assert.Equal(aluno.Ra, usuarioDispositivoCapturado.Ra);
            Assert.Equal(aluno.TurmaId, usuarioDispositivoCapturado.TurmaId);

            mediator.Verify(m => m.Send(It.IsAny<PublicarFilaSerapEstudantesCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Remover_Todos_Caches_Quando_Autenticacao_Sucesso()
        {
            ConfigurarMocksParaAutenticacaoSucesso();

            var cachesRemovidos = new System.Collections.Generic.List<string>();
            mediator
                .Setup(m => m.Send(It.IsAny<RemoverCacheCommand>(), It.IsAny<CancellationToken>()))
                .Callback<IRequest<bool>, CancellationToken>((cmd, token) =>
                {
                    if (cmd is RemoverCacheCommand command)
                    {
                        cachesRemovidos.Add(command.NomeChave);
                    }
                })
                .ReturnsAsync(true);

            var useCase = new AutenticarUsuarioUseCase(mediator.Object);

            var resultado = await useCase.Executar(autenticacaoDto);

            Assert.NotNull(resultado);
            Assert.Equal(4, cachesRemovidos.Count);
            Assert.Contains(cachesRemovidos, c => c.Contains("al-"));
            Assert.Contains(cachesRemovidos, c => c.Contains("ra-"));
            Assert.Contains(cachesRemovidos, c => c.Contains("al-def-"));
            Assert.Contains(cachesRemovidos, c => c.Contains("prefa-"));

            mediator.Verify(m => m.Send(It.IsAny<RemoverCacheCommand>(), It.IsAny<CancellationToken>()), Times.Exactly(4));
        }

        [Fact]
        public async Task Executar_Deve_Atualizar_Usuario_Com_Login_Correto()
        {
            ConfigurarMocksParaAutenticacaoSucesso();

            IncluirOuAtualizarUsuarioCommand commandCapturado = null;
            mediator
                .Setup(m => m.Send(It.IsAny<IncluirOuAtualizarUsuarioCommand>(), It.IsAny<CancellationToken>()))
                .Callback<IRequest<bool>, CancellationToken>((cmd, token) =>
                {
                    commandCapturado = cmd as IncluirOuAtualizarUsuarioCommand;
                })
                .ReturnsAsync(true);

            var useCase = new AutenticarUsuarioUseCase(mediator.Object);

            var resultado = await useCase.Executar(autenticacaoDto);

            Assert.NotNull(resultado);
            Assert.NotNull(commandCapturado);

            mediator.Verify(m => m.Send(It.IsAny<IncluirOuAtualizarUsuarioCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Gerar_Token_Com_Parametros_Corretos()
        {
            ConfigurarMocksParaAutenticacaoSucesso();

            ObterTokenJwtQuery tokenQueryCapturado = null;
            mediator
                .Setup(m => m.Send(It.IsAny<ObterTokenJwtQuery>(), It.IsAny<CancellationToken>()))
                .Callback<IRequest<(string, DateTime)>, CancellationToken>((query, token) =>
                {
                    tokenQueryCapturado = query as ObterTokenJwtQuery;
                })
                .ReturnsAsync((tokenEsperado, dataExpiracaoEsperada));

            var useCase = new AutenticarUsuarioUseCase(mediator.Object);

            var resultado = await useCase.Executar(autenticacaoDto);

            Assert.NotNull(resultado);
            Assert.NotNull(tokenQueryCapturado);

            mediator.Verify(m => m.Send(It.IsAny<ObterTokenJwtQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}

using MediatR;
using Moq;
using SME.SERAp.Prova.Aplicacao;
using SME.SERAp.Prova.Infra;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SME.SERAp.Aplicacao.Test.UseCase
{
    public class RevalidaTokenJwtAdmUseCaseTeste
    {
        private readonly Mock<IMediator> mediator;
        private readonly RevalidaTokenDto revalidaTokenDto;
        private readonly InformacoesTokenAdmDto informacoesTokenAdm;
        private readonly string token;
        private readonly string novoToken;
        private readonly DateTime novaDataExpiracao;

        public RevalidaTokenJwtAdmUseCaseTeste()
        {
            mediator = new Mock<IMediator>();

            token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkFkbWluIFRlc3RlIn0.dozjgNryP4J3jVmNHl0w5N_XgL0n3I9PlFUP0THsR8U";

            revalidaTokenDto = new RevalidaTokenDto { Token = token };

            informacoesTokenAdm = new InformacoesTokenAdmDto(
                login: "admin-teste",
                nome: "Admin Teste",
                perfil: Guid.NewGuid()
            );

            novoToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkFkbWluIFRlc3RlIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
            novaDataExpiracao = DateTime.UtcNow.AddHours(1);
        }

        private void ConfigurarMocksParaRevalidacaoSucesso()
        {
            mediator
                .Setup(m => m.Send(It.IsAny<VerificaERetornaInformacoesPorTokenAdmQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(informacoesTokenAdm);

            mediator
                .Setup(m => m.Send(It.IsAny<ObterTokenJwtAdmQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((novoToken, novaDataExpiracao));
        }

        [Fact]
        public void Construtor_Deve_Lancar_Argument_Null_Exception_Quando_Mediator_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => new RevalidaTokenJwtAdmUseCase(null));
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Novo_Token_Quando_Revalidacao_Sucesso()
        {
            ConfigurarMocksParaRevalidacaoSucesso();

            var useCase = new RevalidaTokenJwtAdmUseCase(mediator.Object);

            var resultado = await useCase.Executar(revalidaTokenDto);

            Assert.NotNull(resultado);
            Assert.Equal(novoToken, resultado.Token);
            Assert.Equal(novaDataExpiracao, resultado.DataHoraExpiracao);

            mediator.Verify(m => m.Send(It.IsAny<VerificaERetornaInformacoesPorTokenAdmQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(m => m.Send(It.IsAny<ObterTokenJwtAdmQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Enviar_Token_Correto_Para_Verificacao()
        {
            ConfigurarMocksParaRevalidacaoSucesso();

            VerificaERetornaInformacoesPorTokenAdmQuery queryCapturada = null;
            mediator
                .Setup(m => m.Send(It.IsAny<VerificaERetornaInformacoesPorTokenAdmQuery>(), It.IsAny<CancellationToken>()))
                .Callback<IRequest<InformacoesTokenAdmDto>, CancellationToken>((query, token) =>
                {
                    queryCapturada = query as VerificaERetornaInformacoesPorTokenAdmQuery;
                })
                .ReturnsAsync(informacoesTokenAdm);

            var useCase = new RevalidaTokenJwtAdmUseCase(mediator.Object);

            var resultado = await useCase.Executar(revalidaTokenDto);

            Assert.NotNull(resultado);
            Assert.NotNull(queryCapturada);
            Assert.Equal(token, queryCapturada.Token);

            mediator.Verify(m => m.Send(It.IsAny<VerificaERetornaInformacoesPorTokenAdmQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Gerar_Novo_Token_Com_Parametros_Corretos()
        {
            ConfigurarMocksParaRevalidacaoSucesso();

            ObterTokenJwtAdmQuery queryCapturada = null;
            mediator
                .Setup(m => m.Send(It.IsAny<ObterTokenJwtAdmQuery>(), It.IsAny<CancellationToken>()))
                .Callback<IRequest<(string, DateTime)>, CancellationToken>((query, token) =>
                {
                    queryCapturada = query as ObterTokenJwtAdmQuery;
                })
                .ReturnsAsync((novoToken, novaDataExpiracao));

            var useCase = new RevalidaTokenJwtAdmUseCase(mediator.Object);

            var resultado = await useCase.Executar(revalidaTokenDto);

            Assert.NotNull(resultado);
            Assert.NotNull(queryCapturada);
            Assert.Equal(informacoesTokenAdm.Login, queryCapturada.Login);
            Assert.Equal(informacoesTokenAdm.Nome, queryCapturada.Nome);
            Assert.Equal(informacoesTokenAdm.Perfil, queryCapturada.Perfil);

            mediator.Verify(m => m.Send(It.IsAny<ObterTokenJwtAdmQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Executar_Operacoes_Na_Ordem_Correta()
        {
            ConfigurarMocksParaRevalidacaoSucesso();

            var execucoes = new System.Collections.Generic.List<string>();

            mediator
                .Setup(m => m.Send(It.IsAny<VerificaERetornaInformacoesPorTokenAdmQuery>(), It.IsAny<CancellationToken>()))
                .Callback(() => execucoes.Add("VerificaToken"))
                .ReturnsAsync(informacoesTokenAdm);

            mediator
                .Setup(m => m.Send(It.IsAny<ObterTokenJwtAdmQuery>(), It.IsAny<CancellationToken>()))
                .Callback(() => execucoes.Add("GeraTokenAdm"))
                .ReturnsAsync((novoToken, novaDataExpiracao));

            var useCase = new RevalidaTokenJwtAdmUseCase(mediator.Object);

            var resultado = await useCase.Executar(revalidaTokenDto);

            Assert.NotNull(resultado);
            Assert.Equal(2, execucoes.Count);
            Assert.Equal("VerificaToken", execucoes[0]);
            Assert.Equal("GeraTokenAdm", execucoes[1]);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Usuario_Autenticacao_Dto()
        {
            ConfigurarMocksParaRevalidacaoSucesso();

            var useCase = new RevalidaTokenJwtAdmUseCase(mediator.Object);

            var resultado = await useCase.Executar(revalidaTokenDto);

            Assert.NotNull(resultado);
            Assert.IsType<UsuarioAutenticacaoDto>(resultado);
        }

        [Fact]
        public async Task Executar_Deve_Mapear_Token_No_Resultado()
        {
            var tokenEsperado = "token-especifico-teste";
            var dataExpiracaoEsperada = DateTime.UtcNow.AddHours(2);

            mediator
                .Setup(m => m.Send(It.IsAny<VerificaERetornaInformacoesPorTokenAdmQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(informacoesTokenAdm);

            mediator
                .Setup(m => m.Send(It.IsAny<ObterTokenJwtAdmQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((tokenEsperado, dataExpiracaoEsperada));

            var useCase = new RevalidaTokenJwtAdmUseCase(mediator.Object);

            var resultado = await useCase.Executar(revalidaTokenDto);

            Assert.NotNull(resultado);
            Assert.Equal(tokenEsperado, resultado.Token);
            Assert.Equal(dataExpiracaoEsperada, resultado.DataHoraExpiracao);
        }

        [Fact]
        public async Task Executar_Deve_Usar_Informacoes_Token_Para_Gerar_Novo_Token()
        {
            var loginEsperado = "admin-especifico";
            var nomeEsperado = "Admin Especifico";
            var perfilEsperado = Guid.NewGuid();

            var informacoesEspecificas = new InformacoesTokenAdmDto(loginEsperado, nomeEsperado, perfilEsperado);

            mediator
                .Setup(m => m.Send(It.IsAny<VerificaERetornaInformacoesPorTokenAdmQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(informacoesEspecificas);

            ObterTokenJwtAdmQuery queryCapturada = null;
            mediator
                .Setup(m => m.Send(It.IsAny<ObterTokenJwtAdmQuery>(), It.IsAny<CancellationToken>()))
                .Callback<IRequest<(string, DateTime)>, CancellationToken>((query, token) =>
                {
                    queryCapturada = query as ObterTokenJwtAdmQuery;
                })
                .ReturnsAsync((novoToken, novaDataExpiracao));

            var useCase = new RevalidaTokenJwtAdmUseCase(mediator.Object);

            var resultado = await useCase.Executar(revalidaTokenDto);

            Assert.NotNull(resultado);
            Assert.NotNull(queryCapturada);
            Assert.Equal(loginEsperado, queryCapturada.Login);
            Assert.Equal(nomeEsperado, queryCapturada.Nome);
            Assert.Equal(perfilEsperado, queryCapturada.Perfil);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Data_Expiracao_Correta()
        {
            var dataExpiracaoEsperada = DateTime.UtcNow.AddHours(3);

            mediator
                .Setup(m => m.Send(It.IsAny<VerificaERetornaInformacoesPorTokenAdmQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(informacoesTokenAdm);

            mediator
                .Setup(m => m.Send(It.IsAny<ObterTokenJwtAdmQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((novoToken, dataExpiracaoEsperada));

            var useCase = new RevalidaTokenJwtAdmUseCase(mediator.Object);

            var resultado = await useCase.Executar(revalidaTokenDto);

            Assert.NotNull(resultado);
            Assert.Equal(dataExpiracaoEsperada, resultado.DataHoraExpiracao);
        }

        [Fact]
        public async Task Executar_Deve_Usar_Token_Do_Revalidacao_Dto()
        {
            var tokenDiferente = "token-diferente-teste";
            var revalidaDtoDiferente = new RevalidaTokenDto { Token = tokenDiferente };

            ConfigurarMocksParaRevalidacaoSucesso();

            VerificaERetornaInformacoesPorTokenAdmQuery queryCapturada = null;
            mediator
                .Setup(m => m.Send(It.IsAny<VerificaERetornaInformacoesPorTokenAdmQuery>(), It.IsAny<CancellationToken>()))
                .Callback<IRequest<InformacoesTokenAdmDto>, CancellationToken>((query, token) =>
                {
                    queryCapturada = query as VerificaERetornaInformacoesPorTokenAdmQuery;
                })
                .ReturnsAsync(informacoesTokenAdm);

            var useCase = new RevalidaTokenJwtAdmUseCase(mediator.Object);

            var resultado = await useCase.Executar(revalidaDtoDiferente);

            Assert.NotNull(resultado);
            Assert.NotNull(queryCapturada);
            Assert.Equal(tokenDiferente, queryCapturada.Token);
        }
    }
}

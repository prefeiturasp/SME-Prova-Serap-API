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
    public class RevalidaTokenJwtUseCaseTeste
    {
        private readonly Mock<IMediator> mediator;
        private readonly RevalidaTokenDto revalidaTokenDto;
        private readonly InformacoesTokenDto tokenInformacoes;
        private readonly string novoToken;
        private readonly DateTime novaDataExpiracao;

        public RevalidaTokenJwtUseCaseTeste()
        {
            mediator = new Mock<IMediator>();

            revalidaTokenDto = new RevalidaTokenDto
            {
                Token = "token-antigo-valido"
            };

            tokenInformacoes = new InformacoesTokenDto(12345678, "9", 1, (int)Modalidade.Fundamental, "dispositivo-teste");

            novoToken = "token-jwt-renovado";
            novaDataExpiracao = DateTime.Now.AddHours(1);
        }

        private void ConfigurarMocksParaRevalidacaoSucesso()
        {
            mediator
                .Setup(m => m.Send(It.IsAny<VerificaERetornaInformacoesPorTokenQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(tokenInformacoes);

            mediator
                .Setup(m => m.Send(It.IsAny<ObterTokenJwtQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((novoToken, novaDataExpiracao));
        }

        [Fact]
        public void Construtor_Deve_Lancar_Argument_Null_Exception_Quando_Mediator_Nulo()
        {
            Assert.Throws<ArgumentNullException>(() => new RevalidaTokenJwtUseCase(null));
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Novo_Token_Quando_Revalidacao_Sucesso()
        {
            ConfigurarMocksParaRevalidacaoSucesso();

            var useCase = new RevalidaTokenJwtUseCase(mediator.Object);

            var resultado = await useCase.Executar(revalidaTokenDto);

            Assert.NotNull(resultado);
            Assert.Equal(novoToken, resultado.Token);
            Assert.Equal(novaDataExpiracao, resultado.DataHoraExpiracao);

            mediator.Verify(m => m.Send(It.IsAny<VerificaERetornaInformacoesPorTokenQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(m => m.Send(It.IsAny<ObterTokenJwtQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Excecao_Quando_Token_Invalido()
        {
            mediator
                .Setup(m => m.Send(It.IsAny<VerificaERetornaInformacoesPorTokenQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new NaoAutorizadoException("Token inválido", 401));

            var useCase = new RevalidaTokenJwtUseCase(mediator.Object);

            var exception = await Assert.ThrowsAsync<NaoAutorizadoException>(() => useCase.Executar(revalidaTokenDto));

            Assert.Equal("Token inválido", exception.Message);
            Assert.Equal(401, exception.StatusCode);

            mediator.Verify(m => m.Send(It.IsAny<VerificaERetornaInformacoesPorTokenQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(m => m.Send(It.IsAny<ObterTokenJwtQuery>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Executar_Deve_Lancar_Excecao_Quando_Token_Expirado()
        {
            mediator
                .Setup(m => m.Send(It.IsAny<VerificaERetornaInformacoesPorTokenQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new NaoAutorizadoException("Token expirado", 401));

            var useCase = new RevalidaTokenJwtUseCase(mediator.Object);

            var exception = await Assert.ThrowsAsync<NaoAutorizadoException>(() => useCase.Executar(revalidaTokenDto));

            Assert.Equal("Token expirado", exception.Message);
            Assert.Equal(401, exception.StatusCode);

            mediator.Verify(m => m.Send(It.IsAny<VerificaERetornaInformacoesPorTokenQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            mediator.Verify(m => m.Send(It.IsAny<ObterTokenJwtQuery>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Executar_Deve_Enviar_Token_Correto_Para_Verificacao()
        {
            ConfigurarMocksParaRevalidacaoSucesso();

            VerificaERetornaInformacoesPorTokenQuery queryCapturada = null;
            mediator
                .Setup(m => m.Send(It.IsAny<VerificaERetornaInformacoesPorTokenQuery>(), It.IsAny<CancellationToken>()))
                .Callback<IRequest<InformacoesTokenDto>, CancellationToken>((query, token) =>
                {
                    queryCapturada = query as VerificaERetornaInformacoesPorTokenQuery;
                })
                .ReturnsAsync(tokenInformacoes);

            var useCase = new RevalidaTokenJwtUseCase(mediator.Object);

            var resultado = await useCase.Executar(revalidaTokenDto);

            Assert.NotNull(resultado);
            Assert.NotNull(queryCapturada);
            Assert.Equal(revalidaTokenDto.Token, queryCapturada.Token);

            mediator.Verify(m => m.Send(It.IsAny<VerificaERetornaInformacoesPorTokenQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Gerar_Novo_Token_Com_Informacoes_Do_Token_Antigo()
        {
            ConfigurarMocksParaRevalidacaoSucesso();

            ObterTokenJwtQuery tokenQueryCapturada = null;
            mediator
                .Setup(m => m.Send(It.IsAny<ObterTokenJwtQuery>(), It.IsAny<CancellationToken>()))
                .Callback<IRequest<(string, DateTime)>, CancellationToken>((query, token) =>
                {
                    tokenQueryCapturada = query as ObterTokenJwtQuery;
                })
                .ReturnsAsync((novoToken, novaDataExpiracao));

            var useCase = new RevalidaTokenJwtUseCase(mediator.Object);

            var resultado = await useCase.Executar(revalidaTokenDto);

            Assert.NotNull(resultado);
            Assert.NotNull(tokenQueryCapturada);
            Assert.Equal(tokenInformacoes.Ra, tokenQueryCapturada.AlunoRA);
            Assert.Equal(tokenInformacoes.Ano, tokenQueryCapturada.AlunoAno);
            Assert.Equal(tokenInformacoes.TipoTurno, tokenQueryCapturada.AlunoTurno);
            Assert.Equal(tokenInformacoes.Modalidade, tokenQueryCapturada.AlunoModalidade);
            Assert.Equal(tokenInformacoes.Dispositivo, tokenQueryCapturada.AlunoDispositivoId);
            mediator.Verify(m => m.Send(It.IsAny<ObterTokenJwtQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Token_Com_Nova_Data_Expiracao()
        {
            var dataExpiracaoEsperada = DateTime.Now.AddHours(2);
            var tokenEsperado = "novo-token-com-nova-expiracao";

            mediator
                .Setup(m => m.Send(It.IsAny<VerificaERetornaInformacoesPorTokenQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(tokenInformacoes);

            mediator
                .Setup(m => m.Send(It.IsAny<ObterTokenJwtQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((tokenEsperado, dataExpiracaoEsperada));

            var useCase = new RevalidaTokenJwtUseCase(mediator.Object);

            var resultado = await useCase.Executar(revalidaTokenDto);

            Assert.NotNull(resultado);
            Assert.Equal(tokenEsperado, resultado.Token);
            Assert.Equal(dataExpiracaoEsperada, resultado.DataHoraExpiracao);
            Assert.True(resultado.DataHoraExpiracao > DateTime.Now);
        }

        [Fact]
        public async Task Executar_Deve_Retornar_Null_Para_UltimoLogin()
        {
            ConfigurarMocksParaRevalidacaoSucesso();

            var useCase = new RevalidaTokenJwtUseCase(mediator.Object);

            var resultado = await useCase.Executar(revalidaTokenDto);

            Assert.NotNull(resultado);
            Assert.Null(resultado.UltimoLogin);
        }
    }
}

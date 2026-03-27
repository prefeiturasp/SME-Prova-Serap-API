using System;
using SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.DownloadProvaAluno
{
    public class DownloadProvaAlunoFilaDtoTest
    {
        private DownloadProvaAlunoDto CriarDownloadDto()
        {
            return new DownloadProvaAlunoDto
            {
                Codigo = Guid.NewGuid(),
                AlunoRa = 123456,
                ProvaId = 10,
                TipoDispositivo = TipoDispositivo.Tablet,
                DispositivoId = "TAB-001",
                ModeloDispositivo = "Galaxy Tab",
                Versao = "1.0.0",
                DataHora = DateTime.Today
            };
        }

        private DownloadProvaAlunoExcluirDto CriarExcluirDto()
        {
            return new DownloadProvaAlunoExcluirDto(new[] { Guid.NewGuid() }, DateTime.Today);
        }

        [Fact]
        public void Deve_Criar_DownloadProvaAlunoFilaDto_Com_Construtor_Parametros()
        {
            var downloadDto = CriarDownloadDto();
            var excluirDto = CriarExcluirDto();

            var dto = new DownloadProvaAlunoFilaDto(DownloadProvaAlunoSituacao.Incluir, downloadDto, excluirDto);

            Assert.Equal(DownloadProvaAlunoSituacao.Incluir, dto.Situacao);
            Assert.Equal(downloadDto, dto.DownloadProvaAlunoDto);
            Assert.Equal(excluirDto, dto.DownloadProvaAlunoExcluirDto);
        }

        [Fact]
        public void Deve_Atribuir_Situacao_Incluir()
        {
            var dto = new DownloadProvaAlunoFilaDto(DownloadProvaAlunoSituacao.Incluir, null, null);
            Assert.Equal(DownloadProvaAlunoSituacao.Incluir, dto.Situacao);
        }

        [Fact]
        public void Deve_Atribuir_Situacao_Excluir()
        {
            var dto = new DownloadProvaAlunoFilaDto(DownloadProvaAlunoSituacao.Excluir, null, null);
            Assert.Equal(DownloadProvaAlunoSituacao.Excluir, dto.Situacao);
        }

        [Fact]
        public void Deve_Aceitar_DownloadProvaAlunoDto_Nulo()
        {
            var dto = new DownloadProvaAlunoFilaDto(DownloadProvaAlunoSituacao.Excluir, null, CriarExcluirDto());
            Assert.Null(dto.DownloadProvaAlunoDto);
        }

        [Fact]
        public void Deve_Aceitar_DownloadProvaAlunoExcluirDto_Nulo()
        {
            var dto = new DownloadProvaAlunoFilaDto(DownloadProvaAlunoSituacao.Incluir, CriarDownloadDto(), null);
            Assert.Null(dto.DownloadProvaAlunoExcluirDto);
        }

        [Fact]
        public void Deve_Aceitar_Ambos_Dtos_Nulos()
        {
            var dto = new DownloadProvaAlunoFilaDto(DownloadProvaAlunoSituacao.Incluir, null, null);

            Assert.Null(dto.DownloadProvaAlunoDto);
            Assert.Null(dto.DownloadProvaAlunoExcluirDto);
        }

        [Fact]
        public void Deve_Preservar_Referencia_DownloadProvaAlunoDto()
        {
            var downloadDto = CriarDownloadDto();
            var dto = new DownloadProvaAlunoFilaDto(DownloadProvaAlunoSituacao.Incluir, downloadDto, null);

            Assert.Same(downloadDto, dto.DownloadProvaAlunoDto);
        }

        [Fact]
        public void Deve_Preservar_Referencia_DownloadProvaAlunoExcluirDto()
        {
            var excluirDto = CriarExcluirDto();
            var dto = new DownloadProvaAlunoFilaDto(DownloadProvaAlunoSituacao.Excluir, null, excluirDto);

            Assert.Same(excluirDto, dto.DownloadProvaAlunoExcluirDto);
        }

        [Fact]
        public void Deve_Permitir_Alterar_Situacao_Apos_Construcao()
        {
            var dto = new DownloadProvaAlunoFilaDto(DownloadProvaAlunoSituacao.Incluir, null, null);
            dto.Situacao = DownloadProvaAlunoSituacao.Excluir;

            Assert.Equal(DownloadProvaAlunoSituacao.Excluir, dto.Situacao);
        }

        [Fact]
        public void Deve_Permitir_Substituir_DownloadProvaAlunoDto_Apos_Construcao()
        {
            var dto = new DownloadProvaAlunoFilaDto(DownloadProvaAlunoSituacao.Incluir, null, null);
            var novoDownload = CriarDownloadDto();
            dto.DownloadProvaAlunoDto = novoDownload;

            Assert.Same(novoDownload, dto.DownloadProvaAlunoDto);
        }
    }
}
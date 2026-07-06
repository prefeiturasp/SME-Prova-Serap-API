using System;
using SME.SERAp.Prova.Infra;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.DownloadProvaAluno
{
    public class DownloadProvaAlunoExcluirDtoTest
    {
        [Fact]
        public void Deve_Criar_DownloadProvaAlunoExcluirDto_Com_Construtor_Parametros()
        {
            var codigos = new[] { Guid.NewGuid(), Guid.NewGuid() };
            var dataAlteracao = new DateTime(2024, 5, 10);

            var dto = new DownloadProvaAlunoExcluirDto(codigos, dataAlteracao);

            Assert.Equal(codigos, dto.Codigos);
            Assert.Equal(dataAlteracao, dto.DataAlteracao);
        }

        [Fact]
        public void Deve_Atribuir_Array_Codigos_Com_Um_Item()
        {
            var guid = Guid.NewGuid();
            var dto = new DownloadProvaAlunoExcluirDto(new[] { guid }, DateTime.Today);

            Assert.Single(dto.Codigos);
            Assert.Equal(guid, dto.Codigos[0]);
        }

        [Fact]
        public void Deve_Atribuir_Array_Codigos_Com_Multiplos_Itens()
        {
            var g1 = Guid.NewGuid();
            var g2 = Guid.NewGuid();
            var g3 = Guid.NewGuid();
            var dto = new DownloadProvaAlunoExcluirDto(new[] { g1, g2, g3 }, DateTime.Today);

            Assert.Equal(3, dto.Codigos.Length);
            Assert.Equal(g1, dto.Codigos[0]);
            Assert.Equal(g2, dto.Codigos[1]);
            Assert.Equal(g3, dto.Codigos[2]);
        }

        [Fact]
        public void Deve_Aceitar_Array_Codigos_Vazio()
        {
            var dto = new DownloadProvaAlunoExcluirDto(Array.Empty<Guid>(), DateTime.Today);

            Assert.Empty(dto.Codigos);
        }

        [Fact]
        public void Deve_Aceitar_Array_Codigos_Nulo()
        {
            var dto = new DownloadProvaAlunoExcluirDto(null, DateTime.Today);

            Assert.Null(dto.Codigos);
        }

        [Fact]
        public void Deve_Atribuir_DataAlteracao_Corretamente()
        {
            var data = new DateTime(2024, 12, 31, 23, 59, 59);
            var dto = new DownloadProvaAlunoExcluirDto(Array.Empty<Guid>(), data);

            Assert.Equal(data, dto.DataAlteracao);
        }

        [Fact]
        public void Deve_Aceitar_DataAlteracao_MinValue()
        {
            var dto = new DownloadProvaAlunoExcluirDto(Array.Empty<Guid>(), DateTime.MinValue);
            Assert.Equal(DateTime.MinValue, dto.DataAlteracao);
        }

        [Fact]
        public void Deve_Aceitar_DataAlteracao_MaxValue()
        {
            var dto = new DownloadProvaAlunoExcluirDto(Array.Empty<Guid>(), DateTime.MaxValue);
            Assert.Equal(DateTime.MaxValue, dto.DataAlteracao);
        }

        [Fact]
        public void Deve_Permitir_Substituir_Array_Codigos_Apos_Construcao()
        {
            var dto = new DownloadProvaAlunoExcluirDto(new[] { Guid.NewGuid() }, DateTime.Today);
            var novoArray = new[] { Guid.NewGuid(), Guid.NewGuid() };
            dto.Codigos = novoArray;

            Assert.Equal(2, dto.Codigos.Length);
        }

        [Fact]
        public void Deve_Permitir_Alterar_DataAlteracao_Apos_Construcao()
        {
            var dto = new DownloadProvaAlunoExcluirDto(Array.Empty<Guid>(), DateTime.Today);
            var novaData = new DateTime(2025, 1, 1);
            dto.DataAlteracao = novaData;

            Assert.Equal(novaData, dto.DataAlteracao);
        }
    }
}
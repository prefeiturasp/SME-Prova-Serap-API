using global::SME.SERAp.Prova.Dominio;
using SME.SERAp.Prova.Infra;
using System;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.DownloadProvaAluno
{
    public class DownloadProvaAlunoDtoTest
    {
        [Fact]
        public void Deve_Criar_DownloadProvaAlunoDto_Com_Propriedades_Padrao()
        {
            var dto = new DownloadProvaAlunoDto();

            Assert.Equal(Guid.Empty, dto.Codigo);
            Assert.Equal(0, dto.AlunoRa);
            Assert.Equal(0, dto.ProvaId);
            Assert.Equal(default(TipoDispositivo), dto.TipoDispositivo);
            Assert.Null(dto.DispositivoId);
            Assert.Null(dto.ModeloDispositivo);
            Assert.Null(dto.Versao);
            Assert.Equal(default(DateTime), dto.DataHora);
        }

        [Fact]
        public void Deve_Atribuir_Codigo_Corretamente()
        {
            var guid = Guid.NewGuid();
            var dto = new DownloadProvaAlunoDto { Codigo = guid };
            Assert.Equal(guid, dto.Codigo);
        }

        [Fact]
        public void Deve_Atribuir_AlunoRa_Corretamente()
        {
            var dto = new DownloadProvaAlunoDto { AlunoRa = 987654 };
            Assert.Equal(987654, dto.AlunoRa);
        }

        [Fact]
        public void Deve_Atribuir_ProvaId_Corretamente()
        {
            var dto = new DownloadProvaAlunoDto { ProvaId = 200 };
            Assert.Equal(200, dto.ProvaId);
        }

        [Fact]
        public void Deve_Atribuir_TipoDispositivo_Corretamente()
        {
            var dto = new DownloadProvaAlunoDto { TipoDispositivo = TipoDispositivo.Tablet };
            Assert.Equal(TipoDispositivo.Tablet, dto.TipoDispositivo);
        }

        [Fact]
        public void Deve_Atribuir_DispositivoId_Corretamente()
        {
            var dto = new DownloadProvaAlunoDto { DispositivoId = "DEVICE-001" };
            Assert.Equal("DEVICE-001", dto.DispositivoId);
        }

        [Fact]
        public void Deve_Atribuir_ModeloDispositivo_Corretamente()
        {
            var dto = new DownloadProvaAlunoDto { ModeloDispositivo = "Samsung Galaxy Tab" };
            Assert.Equal("Samsung Galaxy Tab", dto.ModeloDispositivo);
        }

        [Fact]
        public void Deve_Atribuir_Versao_Corretamente()
        {
            var dto = new DownloadProvaAlunoDto { Versao = "1.2.3" };
            Assert.Equal("1.2.3", dto.Versao);
        }

        [Fact]
        public void Deve_Atribuir_DataHora_Corretamente()
        {
            var data = new DateTime(2024, 6, 15, 10, 30, 0);
            var dto = new DownloadProvaAlunoDto { DataHora = data };
            Assert.Equal(data, dto.DataHora);
        }

        [Fact]
        public void Deve_Criar_DownloadProvaAlunoDto_Completo()
        {
            var guid = Guid.NewGuid();
            var data = new DateTime(2024, 3, 10, 8, 0, 0);

            var dto = new DownloadProvaAlunoDto
            {
                Codigo = guid,
                AlunoRa = 111222,
                ProvaId = 50,
                TipoDispositivo = TipoDispositivo.Tablet,
                DispositivoId = "CHR-XYZ",
                ModeloDispositivo = "Acer Chromebook",
                Versao = "2.0.0",
                DataHora = data
            };

            Assert.Equal(guid, dto.Codigo);
            Assert.Equal(111222, dto.AlunoRa);
            Assert.Equal(50, dto.ProvaId);
            Assert.Equal(TipoDispositivo.Tablet, dto.TipoDispositivo);
            Assert.Equal("CHR-XYZ", dto.DispositivoId);
            Assert.Equal("Acer Chromebook", dto.ModeloDispositivo);
            Assert.Equal("2.0.0", dto.Versao);
            Assert.Equal(data, dto.DataHora);
        }

        [Fact]
        public void Deve_Aceitar_DispositivoId_Nulo()
        {
            var dto = new DownloadProvaAlunoDto { DispositivoId = null };
            Assert.Null(dto.DispositivoId);
        }

        [Fact]
        public void Deve_Aceitar_Versao_Nula()
        {
            var dto = new DownloadProvaAlunoDto { Versao = null };
            Assert.Null(dto.Versao);
        }

        [Fact]
        public void Deve_Aceitar_AlunoRa_Valor_Maximo_Long()
        {
            var dto = new DownloadProvaAlunoDto { AlunoRa = long.MaxValue };
            Assert.Equal(long.MaxValue, dto.AlunoRa);
        }

        [Fact]
        public void Deve_Aceitar_Codigo_Empty()
        {
            var dto = new DownloadProvaAlunoDto { Codigo = Guid.Empty };
            Assert.Equal(Guid.Empty, dto.Codigo);
        }

        [Fact]
        public void Dois_Codigos_Novos_Devem_Ser_Distintos()
        {
            var dto1 = new DownloadProvaAlunoDto { Codigo = Guid.NewGuid() };
            var dto2 = new DownloadProvaAlunoDto { Codigo = Guid.NewGuid() };
            Assert.NotEqual(dto1.Codigo, dto2.Codigo);
        }
    }
}
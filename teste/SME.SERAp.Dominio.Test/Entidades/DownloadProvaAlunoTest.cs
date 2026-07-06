using System;
using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class DownloadProvaAlunoTest
    {
        private readonly DateTime _dataPadrao = new DateTime(2024, 6, 1, 10, 0, 0);

        [Fact]
        public void Deve_Criar_DownloadProvaAluno_Com_Construtor_Parametros()
        {
            var download = new DownloadProvaAluno(
                provaId: 1,
                alunoRa: 123456,
                dispositivoId: "device-001",
                tipoDispositivo: TipoDispositivo.Mobile,
                modeloDispositivo: "Samsung Galaxy",
                versao: "1.0.0",
                situacao: 1,
                criadoEm: _dataPadrao
            );

            Assert.Equal(1, download.ProvaId);
            Assert.Equal(123456, download.AlunoRA);
            Assert.Equal("device-001", download.DispositivoId);
            Assert.Equal(TipoDispositivo.Mobile, download.TipoDispositivo);
            Assert.Equal("Samsung Galaxy", download.ModeloDispositivo);
            Assert.Equal("1.0.0", download.Versao);
            Assert.Equal(1, download.Situacao);
            Assert.Equal(_dataPadrao, download.CriadoEm);
        }

        [Fact]
        public void Deve_Criar_DownloadProvaAluno_Com_TipoDispositivo_Tablet()
        {
            var download = new DownloadProvaAluno(2, 111, "dev-002", TipoDispositivo.Tablet, "iPad", "2.0", 1, _dataPadrao);

            Assert.Equal(TipoDispositivo.Tablet, download.TipoDispositivo);
        }

        [Fact]
        public void Deve_Criar_DownloadProvaAluno_Com_TipoDispositivo_Web()
        {
            var download = new DownloadProvaAluno(2, 111, "dev-003", TipoDispositivo.Web, "Chrome", "3.0", 1, _dataPadrao);

            Assert.Equal(TipoDispositivo.Web, download.TipoDispositivo);
        }

        [Fact]
        public void Deve_Criar_DownloadProvaAluno_Com_TipoDispositivo_NaoCadastrado()
        {
            var download = new DownloadProvaAluno(2, 111, "dev-004", TipoDispositivo.NaoCadastrado, "Desconhecido", "0.0", 0, _dataPadrao);

            Assert.Equal(TipoDispositivo.NaoCadastrado, download.TipoDispositivo);
        }

        [Fact]
        public void Deve_Criar_DownloadProvaAluno_Com_AlteradoEm_Nulo_Por_Padrao()
        {
            var download = new DownloadProvaAluno(1, 111, "dev", TipoDispositivo.Mobile, "Model", "1.0", 1, _dataPadrao);

            Assert.Null(download.AlteradoEm);
        }

        [Fact]
        public void Deve_Atribuir_AlteradoEm_Apos_Criacao()
        {
            var download = new DownloadProvaAluno(1, 111, "dev", TipoDispositivo.Mobile, "Model", "1.0", 1, _dataPadrao);
            var dataAlteracao = new DateTime(2024, 7, 1);
            download.AlteradoEm = dataAlteracao;

            Assert.Equal(dataAlteracao, download.AlteradoEm);
        }

        [Fact]
        public void Deve_Criar_DownloadProvaAluno_Com_DispositivoId_Nulo()
        {
            var download = new DownloadProvaAluno(1, 111, null, TipoDispositivo.Mobile, "Model", "1.0", 1, _dataPadrao);

            Assert.Null(download.DispositivoId);
        }

        [Fact]
        public void Deve_Criar_DownloadProvaAluno_Com_ModeloDispositivo_Nulo()
        {
            var download = new DownloadProvaAluno(1, 111, "dev", TipoDispositivo.Mobile, null, "1.0", 1, _dataPadrao);

            Assert.Null(download.ModeloDispositivo);
        }

        [Fact]
        public void Deve_Criar_DownloadProvaAluno_Com_Versao_Nula()
        {
            var download = new DownloadProvaAluno(1, 111, "dev", TipoDispositivo.Mobile, "Model", null, 1, _dataPadrao);

            Assert.Null(download.Versao);
        }

        [Fact]
        public void Deve_Criar_DownloadProvaAluno_Com_Situacao_Zero()
        {
            var download = new DownloadProvaAluno(1, 111, "dev", TipoDispositivo.Mobile, "Model", "1.0", 0, _dataPadrao);

            Assert.Equal(0, download.Situacao);
        }

        [Fact]
        public void Deve_Criar_DownloadProvaAluno_Com_AlunoRA_Maximo()
        {
            var download = new DownloadProvaAluno(1, long.MaxValue, "dev", TipoDispositivo.Mobile, "Model", "1.0", 1, _dataPadrao);

            Assert.Equal(long.MaxValue, download.AlunoRA);
        }

        [Fact]
        public void Deve_Criar_DownloadProvaAluno_Com_ProvaId_Maximo()
        {
            var download = new DownloadProvaAluno(long.MaxValue, 111, "dev", TipoDispositivo.Mobile, "Model", "1.0", 1, _dataPadrao);

            Assert.Equal(long.MaxValue, download.ProvaId);
        }

        [Fact]
        public void Deve_Verificar_Todos_Os_Valores_Do_Enum_TipoDispositivo()
        {
            var valores = System.Enum.GetValues(typeof(TipoDispositivo));

            Assert.Contains(TipoDispositivo.NaoCadastrado, (TipoDispositivo[])valores);
            Assert.Contains(TipoDispositivo.Mobile, (TipoDispositivo[])valores);
            Assert.Contains(TipoDispositivo.Tablet, (TipoDispositivo[])valores);
            Assert.Contains(TipoDispositivo.Web, (TipoDispositivo[])valores);
            Assert.Equal(4, valores.Length);
        }

        [Fact]
        public void Deve_Verificar_Valores_Numericos_Do_Enum_TipoDispositivo()
        {
            Assert.Equal(0, (int)TipoDispositivo.NaoCadastrado);
            Assert.Equal(1, (int)TipoDispositivo.Mobile);
            Assert.Equal(2, (int)TipoDispositivo.Tablet);
            Assert.Equal(3, (int)TipoDispositivo.Web);
        }

        [Fact]
        public void Deve_Herdar_De_EntidadeBase()
        {
            var download = new DownloadProvaAluno(1, 111, "dev", TipoDispositivo.Mobile, "Model", "1.0", 1, _dataPadrao);

            Assert.IsAssignableFrom<EntidadeBase>(download);
        }

        [Fact]
        public void Deve_Alterar_Situacao_Apos_Criacao()
        {
            var download = new DownloadProvaAluno(1, 111, "dev", TipoDispositivo.Mobile, "Model", "1.0", 1, _dataPadrao);
            download.Situacao = 2;

            Assert.Equal(2, download.Situacao);
        }
    }
}
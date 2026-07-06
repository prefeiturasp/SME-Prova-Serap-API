using System;
using System.Threading;
using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class ExportacaoResultadoTest
    {
        [Fact]
        public void Deve_Criar_ExportacaoResultado_Com_Construtor_Padrao()
        {
            var exportacao = new ExportacaoResultado
            {
                NomeArquivo = "resultado.csv",
                Status = ExportacaoResultadoStatus.NaoIniciado,
                ProvaSerapId = 10
            };

            Assert.Equal("resultado.csv", exportacao.NomeArquivo);
            Assert.Equal(ExportacaoResultadoStatus.NaoIniciado, exportacao.Status);
            Assert.Equal(10, exportacao.ProvaSerapId);
        }

        [Fact]
        public void Deve_Criar_ExportacaoResultado_Com_Construtor_Parametros()
        {
            var antes = DateTime.Now;
            var exportacao = new ExportacaoResultado("arquivo.csv", 5);
            var depois = DateTime.Now;

            Assert.Equal("arquivo.csv", exportacao.NomeArquivo);
            Assert.Equal(5, exportacao.ProvaSerapId);
            Assert.Equal(ExportacaoResultadoStatus.Processando, exportacao.Status);
            Assert.InRange(exportacao.CriadoEm, antes, depois);
            Assert.InRange(exportacao.AtualizadoEm, antes, depois);
        }

        [Fact]
        public void Deve_Criar_ExportacaoResultado_Com_Status_Processando_Via_Construtor()
        {
            var exportacao = new ExportacaoResultado("arq.csv", 1);

            Assert.Equal(ExportacaoResultadoStatus.Processando, exportacao.Status);
        }

        [Fact]
        public void AtualizarStatus_Deve_Alterar_Status_Para_Finalizado()
        {
            var exportacao = new ExportacaoResultado("arq.csv", 1);
            exportacao.AtualizarStatus(ExportacaoResultadoStatus.Finalizado);

            Assert.Equal(ExportacaoResultadoStatus.Finalizado, exportacao.Status);
        }

        [Fact]
        public void AtualizarStatus_Deve_Alterar_Status_Para_Erro()
        {
            var exportacao = new ExportacaoResultado("arq.csv", 1);
            exportacao.AtualizarStatus(ExportacaoResultadoStatus.Erro);

            Assert.Equal(ExportacaoResultadoStatus.Erro, exportacao.Status);
        }

        [Fact]
        public void AtualizarStatus_Deve_Alterar_Status_Para_Cancelado()
        {
            var exportacao = new ExportacaoResultado("arq.csv", 1);
            exportacao.AtualizarStatus(ExportacaoResultadoStatus.Cancelado);

            Assert.Equal(ExportacaoResultadoStatus.Cancelado, exportacao.Status);
        }

        [Fact]
        public void AtualizarStatus_Deve_Atualizar_AtualizadoEm()
        {
            var exportacao = new ExportacaoResultado("arq.csv", 1);
            var antes = DateTime.Now;
            Thread.Sleep(10);
            exportacao.AtualizarStatus(ExportacaoResultadoStatus.Finalizado);
            var depois = DateTime.Now;

            Assert.InRange(exportacao.AtualizadoEm, antes, depois);
        }

        [Fact]
        public void AtualizarStatus_Multiplas_Vezes_Deve_Manter_Ultimo_Status()
        {
            var exportacao = new ExportacaoResultado("arq.csv", 1);
            exportacao.AtualizarStatus(ExportacaoResultadoStatus.Iniciado);
            exportacao.AtualizarStatus(ExportacaoResultadoStatus.Processando);
            exportacao.AtualizarStatus(ExportacaoResultadoStatus.Finalizado);

            Assert.Equal(ExportacaoResultadoStatus.Finalizado, exportacao.Status);
        }

        [Fact]
        public void Deve_Criar_ExportacaoResultado_Via_Construtor_Padrao_Com_Valores_Default()
        {
            var exportacao = new ExportacaoResultado();

            Assert.Null(exportacao.NomeArquivo);
            Assert.Equal((ExportacaoResultadoStatus)0, exportacao.Status);
            Assert.NotEqual(ExportacaoResultadoStatus.NaoIniciado, exportacao.Status);
            Assert.Equal(0, exportacao.ProvaSerapId);
        }

        [Fact]
        public void Deve_Verificar_Todos_Os_Valores_Do_Enum_ExportacaoResultadoStatus()
        {
            var valores = Enum.GetValues(typeof(ExportacaoResultadoStatus));

            Assert.Contains(ExportacaoResultadoStatus.NaoIniciado, (ExportacaoResultadoStatus[])valores);
            Assert.Contains(ExportacaoResultadoStatus.Iniciado, (ExportacaoResultadoStatus[])valores);
            Assert.Contains(ExportacaoResultadoStatus.Processando, (ExportacaoResultadoStatus[])valores);
            Assert.Contains(ExportacaoResultadoStatus.Finalizado, (ExportacaoResultadoStatus[])valores);
            Assert.Contains(ExportacaoResultadoStatus.Erro, (ExportacaoResultadoStatus[])valores);
            Assert.Contains(ExportacaoResultadoStatus.Cancelado, (ExportacaoResultadoStatus[])valores);
            Assert.Equal(6, valores.Length);
        }

        [Fact]
        public void Deve_Verificar_Valores_Numericos_Do_Enum_ExportacaoResultadoStatus()
        {
            Assert.Equal(1, (int)ExportacaoResultadoStatus.NaoIniciado);
            Assert.Equal(2, (int)ExportacaoResultadoStatus.Iniciado);
            Assert.Equal(3, (int)ExportacaoResultadoStatus.Processando);
            Assert.Equal(4, (int)ExportacaoResultadoStatus.Finalizado);
            Assert.Equal(5, (int)ExportacaoResultadoStatus.Erro);
            Assert.Equal(6, (int)ExportacaoResultadoStatus.Cancelado);
        }

        [Fact]
        public void Deve_Herdar_De_EntidadeBase()
        {
            var exportacao = new ExportacaoResultado();

            Assert.IsAssignableFrom<EntidadeBase>(exportacao);
        }

        [Fact]
        public void Deve_Criar_ExportacaoResultado_Com_NomeArquivo_Nulo_Via_Construtor_Padrao()
        {
            var exportacao = new ExportacaoResultado { NomeArquivo = null };

            Assert.Null(exportacao.NomeArquivo);
        }

        [Fact]
        public void Deve_Criar_ExportacaoResultado_Com_ProvaSerapId_Maximo()
        {
            var exportacao = new ExportacaoResultado("arq.csv", long.MaxValue);

            Assert.Equal(long.MaxValue, exportacao.ProvaSerapId);
        }
    }
}
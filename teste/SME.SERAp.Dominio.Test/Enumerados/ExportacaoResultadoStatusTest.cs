using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Enumerados
{
    public class ExportacaoResultadoStatusTest
    {
        [Fact]
        public void Deve_Conter_Membro_NaoIniciado_Com_Valor_1()
        {
            Assert.Equal(1, (int)ExportacaoResultadoStatus.NaoIniciado);
        }

        [Fact]
        public void Deve_Conter_Membro_Iniciado_Com_Valor_2()
        {
            Assert.Equal(2, (int)ExportacaoResultadoStatus.Iniciado);
        }

        [Fact]
        public void Deve_Conter_Membro_Processando_Com_Valor_3()
        {
            Assert.Equal(3, (int)ExportacaoResultadoStatus.Processando);
        }

        [Fact]
        public void Deve_Conter_Membro_Finalizado_Com_Valor_4()
        {
            Assert.Equal(4, (int)ExportacaoResultadoStatus.Finalizado);
        }

        [Fact]
        public void Deve_Conter_Membro_Erro_Com_Valor_5()
        {
            Assert.Equal(5, (int)ExportacaoResultadoStatus.Erro);
        }

        [Fact]
        public void Deve_Conter_Membro_Cancelado_Com_Valor_6()
        {
            Assert.Equal(6, (int)ExportacaoResultadoStatus.Cancelado);
        }

        [Fact]
        public void Deve_Conter_Exatamente_Seis_Membros()
        {
            var valores = Enum.GetValues(typeof(ExportacaoResultadoStatus));
            Assert.Equal(6, valores.Length);
        }

        [Fact]
        public void Nao_Deve_Conter_Valor_Zero_Como_Membro_Nomeado()
        {
            Assert.False(Enum.IsDefined(typeof(ExportacaoResultadoStatus), 0));
        }

        [Fact]
        public void Deve_Conter_Todos_Os_Membros_Esperados()
        {
            var valores = (ExportacaoResultadoStatus[])Enum.GetValues(typeof(ExportacaoResultadoStatus));
            Assert.Contains(ExportacaoResultadoStatus.NaoIniciado, valores);
            Assert.Contains(ExportacaoResultadoStatus.Iniciado, valores);
            Assert.Contains(ExportacaoResultadoStatus.Processando, valores);
            Assert.Contains(ExportacaoResultadoStatus.Finalizado, valores);
            Assert.Contains(ExportacaoResultadoStatus.Erro, valores);
            Assert.Contains(ExportacaoResultadoStatus.Cancelado, valores);
        }

        [Fact]
        public void Deve_Converter_Inteiro_Para_Membro_Corretamente()
        {
            Assert.Equal(ExportacaoResultadoStatus.NaoIniciado, (ExportacaoResultadoStatus)1);
            Assert.Equal(ExportacaoResultadoStatus.Cancelado, (ExportacaoResultadoStatus)6);
        }
    }
}
using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Enumerados
{
    public class ProvaStatusTest
    {
        [Fact]
        public void Deve_Conter_Membro_NaoIniciado_Com_Valor_0()
        {
            Assert.Equal(0, (int)ProvaStatus.NaoIniciado);
        }

        [Fact]
        public void Deve_Conter_Membro_Iniciado_Com_Valor_1()
        {
            Assert.Equal(1, (int)ProvaStatus.Iniciado);
        }

        [Fact]
        public void Deve_Conter_Membro_Finalizado_Com_Valor_2()
        {
            Assert.Equal(2, (int)ProvaStatus.Finalizado);
        }

        [Fact]
        public void Deve_Conter_Membro_Pendente_Com_Valor_3()
        {
            Assert.Equal(3, (int)ProvaStatus.Pendente);
        }

        [Fact]
        public void Deve_Conter_Membro_EmRevisao_Com_Valor_4()
        {
            Assert.Equal(4, (int)ProvaStatus.EmRevisao);
        }

        [Fact]
        public void Deve_Conter_Membro_FinalizadaAutomaticamenteJob_Com_Valor_5()
        {
            Assert.Equal(5, (int)ProvaStatus.FINALIZADA_AUTOMATICAMENTE_JOB);
        }

        [Fact]
        public void Deve_Conter_Membro_FinalizadaAutomaticamenteTempo_Com_Valor_6()
        {
            Assert.Equal(6, (int)ProvaStatus.FINALIZADA_AUTOMATICAMENTE_TEMPO);
        }

        [Fact]
        public void Deve_Conter_Membro_FinalizadaOffline_Com_Valor_7()
        {
            Assert.Equal(7, (int)ProvaStatus.FINALIZADA_OFFLINE);
        }

        [Fact]
        public void Deve_Ter_NaoIniciado_Como_Valor_Default()
        {
            var valor = default(ProvaStatus);
            Assert.Equal(ProvaStatus.NaoIniciado, valor);
        }

        [Fact]
        public void Deve_Conter_Exatamente_Oito_Membros()
        {
            var valores = Enum.GetValues(typeof(ProvaStatus));
            Assert.Equal(8, valores.Length);
        }

        [Fact]
        public void Deve_Conter_Todos_Os_Membros_Esperados()
        {
            var valores = (ProvaStatus[])Enum.GetValues(typeof(ProvaStatus));
            Assert.Contains(ProvaStatus.NaoIniciado, valores);
            Assert.Contains(ProvaStatus.Iniciado, valores);
            Assert.Contains(ProvaStatus.Finalizado, valores);
            Assert.Contains(ProvaStatus.Pendente, valores);
            Assert.Contains(ProvaStatus.EmRevisao, valores);
            Assert.Contains(ProvaStatus.FINALIZADA_AUTOMATICAMENTE_JOB, valores);
            Assert.Contains(ProvaStatus.FINALIZADA_AUTOMATICAMENTE_TEMPO, valores);
            Assert.Contains(ProvaStatus.FINALIZADA_OFFLINE, valores);
        }

        [Fact]
        public void Deve_Converter_Inteiro_Para_Membro_Corretamente()
        {
            Assert.Equal(ProvaStatus.NaoIniciado, (ProvaStatus)0);
            Assert.Equal(ProvaStatus.Iniciado, (ProvaStatus)1);
            Assert.Equal(ProvaStatus.Finalizado, (ProvaStatus)2);
            Assert.Equal(ProvaStatus.FINALIZADA_OFFLINE, (ProvaStatus)7);
        }
    }
}
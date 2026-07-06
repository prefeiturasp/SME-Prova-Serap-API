using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Enumerados
{
    public class TipoResultadoPspTest
    {
        [Fact]
        public void Deve_Conter_Membro_ResultadoAluno_Com_Valor_1()
        {
            Assert.Equal(1, (int)TipoResultadoPsp.ResultadoAluno);
        }

        [Fact]
        public void Deve_Conter_Membro_ResultadoTurma_Com_Valor_2()
        {
            Assert.Equal(2, (int)TipoResultadoPsp.ResultadoTurma);
        }

        [Fact]
        public void Deve_Conter_Membro_ResultadoEscola_Com_Valor_3()
        {
            Assert.Equal(3, (int)TipoResultadoPsp.ResultadoEscola);
        }

        [Fact]
        public void Deve_Conter_Membro_ResultadoDre_Com_Valor_4()
        {
            Assert.Equal(4, (int)TipoResultadoPsp.ResultadoDre);
        }

        [Fact]
        public void Deve_Conter_Membro_ResultadoSme_Com_Valor_5()
        {
            Assert.Equal(5, (int)TipoResultadoPsp.ResultadoSme);
        }

        [Fact]
        public void Deve_Conter_Membro_ResultadoCicloEscola_Com_Valor_9()
        {
            Assert.Equal(9, (int)TipoResultadoPsp.ResultadoCicloEscola);
        }

        [Fact]
        public void Deve_Conter_Membro_ResultadoCicloDre_Com_Valor_10()
        {
            Assert.Equal(10, (int)TipoResultadoPsp.ResultadoCicloDre);
        }

        [Fact]
        public void Deve_Conter_Membro_ResultadoCicloSme_Com_Valor_11()
        {
            Assert.Equal(11, (int)TipoResultadoPsp.ResultadoCicloSme);
        }

        [Fact]
        public void Deve_Conter_Membro_ResultadoCicloTurma_Com_Valor_12()
        {
            Assert.Equal(12, (int)TipoResultadoPsp.ResultadoCicloTurma);
        }

        [Fact]
        public void Deve_Conter_Membro_ResultadoParticipacaoTurma_Com_Valor_13()
        {
            Assert.Equal(13, (int)TipoResultadoPsp.ResultadoParticipacaoTurma);
        }

        [Fact]
        public void Deve_Conter_Membro_ParticipacaoTurmaAreaConhecimento_Com_Valor_14()
        {
            Assert.Equal(14, (int)TipoResultadoPsp.ParticipacaoTurmaAreaConhecimento);
        }

        [Fact]
        public void Deve_Conter_Membro_ResultadoParticipacaoUe_Com_Valor_15()
        {
            Assert.Equal(15, (int)TipoResultadoPsp.ResultadoParticipacaoUe);
        }

        [Fact]
        public void Deve_Conter_Membro_ParticipacaoUeAreaConhecimento_Com_Valor_16()
        {
            Assert.Equal(16, (int)TipoResultadoPsp.ParticipacaoUeAreaConhecimento);
        }

        [Fact]
        public void Deve_Conter_Membro_ParticipacaoDre_Com_Valor_17()
        {
            Assert.Equal(17, (int)TipoResultadoPsp.ParticipacaoDre);
        }

        [Fact]
        public void Deve_Conter_Membro_ParticipacaoDreAreaConhecimento_Com_Valor_18()
        {
            Assert.Equal(18, (int)TipoResultadoPsp.ParticipacaoDreAreaConhecimento);
        }

        [Fact]
        public void Deve_Conter_Membro_ParticipacaoSme_Com_Valor_19()
        {
            Assert.Equal(19, (int)TipoResultadoPsp.ParticipacaoSme);
        }

        [Fact]
        public void Deve_Conter_Membro_ParticipacaoSmeAreaConhecimento_Com_Valor_20()
        {
            Assert.Equal(20, (int)TipoResultadoPsp.ParticipacaoSmeAreaConhecimento);
        }

        [Fact]
        public void Deve_Conter_Exatamente_Dezessete_Membros()
        {
            var valores = Enum.GetValues(typeof(TipoResultadoPsp));
            Assert.Equal(17, valores.Length);
        }

        [Fact]
        public void Deve_Conter_Todos_Os_Membros_Esperados()
        {
            var valores = (TipoResultadoPsp[])Enum.GetValues(typeof(TipoResultadoPsp));
            Assert.Contains(TipoResultadoPsp.ResultadoAluno, valores);
            Assert.Contains(TipoResultadoPsp.ResultadoTurma, valores);
            Assert.Contains(TipoResultadoPsp.ResultadoEscola, valores);
            Assert.Contains(TipoResultadoPsp.ResultadoDre, valores);
            Assert.Contains(TipoResultadoPsp.ResultadoSme, valores);
            Assert.Contains(TipoResultadoPsp.ResultadoCicloEscola, valores);
            Assert.Contains(TipoResultadoPsp.ResultadoCicloDre, valores);
            Assert.Contains(TipoResultadoPsp.ResultadoCicloSme, valores);
            Assert.Contains(TipoResultadoPsp.ResultadoCicloTurma, valores);
            Assert.Contains(TipoResultadoPsp.ResultadoParticipacaoTurma, valores);
            Assert.Contains(TipoResultadoPsp.ParticipacaoTurmaAreaConhecimento, valores);
            Assert.Contains(TipoResultadoPsp.ResultadoParticipacaoUe, valores);
            Assert.Contains(TipoResultadoPsp.ParticipacaoUeAreaConhecimento, valores);
            Assert.Contains(TipoResultadoPsp.ParticipacaoDre, valores);
            Assert.Contains(TipoResultadoPsp.ParticipacaoDreAreaConhecimento, valores);
            Assert.Contains(TipoResultadoPsp.ParticipacaoSme, valores);
            Assert.Contains(TipoResultadoPsp.ParticipacaoSmeAreaConhecimento, valores);
        }

        [Fact]
        public void Deve_Converter_Inteiro_Para_Membro_Corretamente()
        {
            Assert.Equal(TipoResultadoPsp.ResultadoAluno, (TipoResultadoPsp)1);
            Assert.Equal(TipoResultadoPsp.ResultadoCicloEscola, (TipoResultadoPsp)9);
            Assert.Equal(TipoResultadoPsp.ParticipacaoSmeAreaConhecimento, (TipoResultadoPsp)20);
        }
    }
}
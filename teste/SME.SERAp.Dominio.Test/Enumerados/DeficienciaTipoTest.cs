using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Enumerados
{
    public class DeficienciaTipoTest
    {
        [Fact]
        public void Deve_Conter_Membro_SurdezLeveModerada_Com_Valor_5()
        {
            Assert.Equal(5, (int)DeficienciaTipo.SURDEZ_LEVE_MODERADA);
        }

        [Fact]
        public void Deve_Conter_Membro_SurdezSeveraProfunda_Com_Valor_6()
        {
            Assert.Equal(6, (int)DeficienciaTipo.SURDEZ_SEVERA_PROFUNDA);
        }

        [Fact]
        public void Deve_Conter_Membro_Cegueira_Com_Valor_11()
        {
            Assert.Equal(11, (int)DeficienciaTipo.CEGUEIRA);
        }

        [Fact]
        public void Deve_Conter_Membro_BaixaVisao_Com_Valor_12()
        {
            Assert.Equal(12, (int)DeficienciaTipo.BAIXA_VISAO_OU_SUBNORMAL);
        }

        [Fact]
        public void Deve_Conter_Membro_SurdoCegueira_Com_Valor_14()
        {
            Assert.Equal(14, (int)DeficienciaTipo.SURDO_CEGUEIRA);
        }

        [Fact]
        public void Deve_Conter_Exatamente_Cinco_Membros()
        {
            var valores = Enum.GetValues(typeof(DeficienciaTipo));
            Assert.Equal(5, valores.Length);
        }

        [Fact]
        public void Deve_Conter_Todos_Os_Membros_Esperados()
        {
            var valores = (DeficienciaTipo[])Enum.GetValues(typeof(DeficienciaTipo));
            Assert.Contains(DeficienciaTipo.CEGUEIRA, valores);
            Assert.Contains(DeficienciaTipo.BAIXA_VISAO_OU_SUBNORMAL, valores);
            Assert.Contains(DeficienciaTipo.SURDEZ_LEVE_MODERADA, valores);
            Assert.Contains(DeficienciaTipo.SURDEZ_SEVERA_PROFUNDA, valores);
            Assert.Contains(DeficienciaTipo.SURDO_CEGUEIRA, valores);
        }

        [Fact]
        public void Deve_Converter_Inteiro_Para_Membro_Corretamente()
        {
            Assert.Equal(DeficienciaTipo.SURDEZ_LEVE_MODERADA, (DeficienciaTipo)5);
            Assert.Equal(DeficienciaTipo.CEGUEIRA, (DeficienciaTipo)11);
            Assert.Equal(DeficienciaTipo.SURDO_CEGUEIRA, (DeficienciaTipo)14);
        }
    }
}
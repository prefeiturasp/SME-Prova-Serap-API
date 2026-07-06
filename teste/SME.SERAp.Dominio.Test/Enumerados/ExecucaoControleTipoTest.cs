using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Enumerados
{
    public class ExecucaoControleTipoTest
    {
        [Fact]
        public void Deve_Conter_Membro_ProvaLegadoSincronizacao_Com_Valor_1()
        {
            Assert.Equal(1, (int)ExecucaoControleTipo.ProvaLegadoSincronizacao);
        }

        [Fact]
        public void Deve_Conter_Exatamente_Um_Membro()
        {
            var valores = Enum.GetValues(typeof(ExecucaoControleTipo));
            Assert.Single(valores);
        }

        [Fact]
        public void Deve_Converter_Inteiro_Para_Membro_Corretamente()
        {
            Assert.Equal(ExecucaoControleTipo.ProvaLegadoSincronizacao, (ExecucaoControleTipo)1);
        }
    }
}
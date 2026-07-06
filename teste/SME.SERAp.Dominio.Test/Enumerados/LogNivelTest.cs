using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Enumerados
{
    public class LogNivelTest
    {
        [Fact]
        public void Deve_Conter_Membro_Informacao_Com_Valor_1()
        {
            Assert.Equal(1, (int)LogNivel.Informacao);
        }

        [Fact]
        public void Deve_Conter_Membro_Critico_Com_Valor_2()
        {
            Assert.Equal(2, (int)LogNivel.Critico);
        }

        [Fact]
        public void Deve_Conter_Membro_Negocio_Com_Valor_3()
        {
            Assert.Equal(3, (int)LogNivel.Negocio);
        }

        [Fact]
        public void Deve_Conter_Exatamente_Tres_Membros()
        {
            var valores = Enum.GetValues(typeof(LogNivel));
            Assert.Equal(3, valores.Length);
        }

        [Fact]
        public void Deve_Conter_Todos_Os_Membros_Esperados()
        {
            var valores = (LogNivel[])Enum.GetValues(typeof(LogNivel));
            Assert.Contains(LogNivel.Informacao, valores);
            Assert.Contains(LogNivel.Critico, valores);
            Assert.Contains(LogNivel.Negocio, valores);
        }

        [Fact]
        public void Deve_Converter_Inteiro_Para_Membro_Corretamente()
        {
            Assert.Equal(LogNivel.Informacao, (LogNivel)1);
            Assert.Equal(LogNivel.Critico, (LogNivel)2);
            Assert.Equal(LogNivel.Negocio, (LogNivel)3);
        }

        [Fact]
        public void Nao_Deve_Conter_Valor_Zero_Como_Membro_Nomeado()
        {
            Assert.False(Enum.IsDefined(typeof(LogNivel), 0));
        }
    }
}
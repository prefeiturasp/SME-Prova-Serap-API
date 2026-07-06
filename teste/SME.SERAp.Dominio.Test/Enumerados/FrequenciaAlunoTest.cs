using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Enumerados
{
    public class FrequenciaAlunoTest
    {
        [Fact]
        public void Deve_Conter_Membro_Presente_Com_Valor_1()
        {
            Assert.Equal(1, (int)FrequenciaAluno.Presente);
        }

        [Fact]
        public void Deve_Conter_Membro_Ausente_Com_Valor_2()
        {
            Assert.Equal(2, (int)FrequenciaAluno.Ausente);
        }

        [Fact]
        public void Deve_Conter_Membro_Remoto_Com_Valor_3()
        {
            Assert.Equal(3, (int)FrequenciaAluno.Remoto);
        }

        [Fact]
        public void Deve_Conter_Exatamente_Tres_Membros()
        {
            var valores = Enum.GetValues(typeof(FrequenciaAluno));
            Assert.Equal(3, valores.Length);
        }

        [Fact]
        public void Deve_Conter_Todos_Os_Membros_Esperados()
        {
            var valores = (FrequenciaAluno[])Enum.GetValues(typeof(FrequenciaAluno));
            Assert.Contains(FrequenciaAluno.Presente, valores);
            Assert.Contains(FrequenciaAluno.Ausente, valores);
            Assert.Contains(FrequenciaAluno.Remoto, valores);
        }

        [Fact]
        public void Deve_Converter_Inteiro_Para_Membro_Corretamente()
        {
            Assert.Equal(FrequenciaAluno.Presente, (FrequenciaAluno)1);
            Assert.Equal(FrequenciaAluno.Ausente, (FrequenciaAluno)2);
            Assert.Equal(FrequenciaAluno.Remoto, (FrequenciaAluno)3);
        }

        [Fact]
        public void Deve_Comparar_Membros_Corretamente()
        {
            Assert.True(FrequenciaAluno.Presente < FrequenciaAluno.Ausente);
            Assert.True(FrequenciaAluno.Ausente < FrequenciaAluno.Remoto);
        }
    }
}
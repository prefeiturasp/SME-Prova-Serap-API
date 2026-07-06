using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Enumerados
{
    public class AlunoProvaProficienciaTipoTest
    {
        [Fact]
        public void Deve_Conter_Membro_Inicial()
        {
            Assert.Equal(0, (int)AlunoProvaProficienciaTipo.Inicial);
        }

        [Fact]
        public void Deve_Conter_Membro_Parcial()
        {
            Assert.Equal(1, (int)AlunoProvaProficienciaTipo.Parcial);
        }

        [Fact]
        public void Deve_Conter_Membro_Final()
        {
            Assert.Equal(2, (int)AlunoProvaProficienciaTipo.Final);
        }

        [Fact]
        public void Deve_Conter_Exatamente_Tres_Membros()
        {
            var valores = Enum.GetValues(typeof(AlunoProvaProficienciaTipo));
            Assert.Equal(3, valores.Length);
        }

        [Fact]
        public void Deve_Ter_Inicial_Como_Valor_Default()
        {
            var valor = default(AlunoProvaProficienciaTipo);
            Assert.Equal(AlunoProvaProficienciaTipo.Inicial, valor);
        }

        [Fact]
        public void Deve_Conter_Todos_Os_Membros_Esperados()
        {
            var valores = (AlunoProvaProficienciaTipo[])Enum.GetValues(typeof(AlunoProvaProficienciaTipo));
            Assert.Contains(AlunoProvaProficienciaTipo.Inicial, valores);
            Assert.Contains(AlunoProvaProficienciaTipo.Parcial, valores);
            Assert.Contains(AlunoProvaProficienciaTipo.Final, valores);
        }

        [Fact]
        public void Deve_Converter_Inteiro_Para_Membro_Corretamente()
        {
            Assert.Equal(AlunoProvaProficienciaTipo.Inicial, (AlunoProvaProficienciaTipo)0);
            Assert.Equal(AlunoProvaProficienciaTipo.Parcial, (AlunoProvaProficienciaTipo)1);
            Assert.Equal(AlunoProvaProficienciaTipo.Final, (AlunoProvaProficienciaTipo)2);
        }

        [Fact]
        public void Deve_Comparar_Membros_Corretamente()
        {
            Assert.True(AlunoProvaProficienciaTipo.Inicial < AlunoProvaProficienciaTipo.Parcial);
            Assert.True(AlunoProvaProficienciaTipo.Parcial < AlunoProvaProficienciaTipo.Final);
        }
    }
}
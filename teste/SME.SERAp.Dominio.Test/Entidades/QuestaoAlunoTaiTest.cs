using System;
using Xunit;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class QuestaoAlunoTaiTest
    {
        [Fact]
        public void Deve_Definir_CriadoEm_No_Construtor_Padrao()
        {
            var antes = DateTime.Now;
            var tai = new QuestaoAlunoTai();
            var depois = DateTime.Now;

            Assert.InRange(tai.CriadoEm, antes, depois);
        }

        [Fact]
        public void Deve_Criar_QuestaoAlunoTai_Com_Construtor_Parametros()
        {
            var antes = DateTime.Now;
            var tai = new QuestaoAlunoTai(10, 20, 3);
            var depois = DateTime.Now;

            Assert.Equal(10, tai.QuestaoId);
            Assert.Equal(20, tai.AlunoId);
            Assert.Equal(3, tai.Ordem);
            Assert.InRange(tai.CriadoEm, antes, depois);
        }
    }
}
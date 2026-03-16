using System;
using Xunit;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class QuestaoTest
    {
        [Fact]
        public void Deve_Criar_Questao_Com_Construtor_Padrao()
        {
            var questao = new Questao
            {
                Ordem = 1,
                TextoBase = "Texto base",
                Enunciado = "Enunciado",
                QuestaoLegadoId = 100,
                ProvaId = 200,
                Tipo = QuestaoTipo.MultiplaEscolha,
                Caderno = "A",
                QuantidadeAlternativas = 4
            };

            Assert.Equal(1, questao.Ordem);
            Assert.Equal("Texto base", questao.TextoBase);
            Assert.Equal("Enunciado", questao.Enunciado);
            Assert.Equal(100, questao.QuestaoLegadoId);
            Assert.Equal(200, questao.ProvaId);
            Assert.Equal(QuestaoTipo.MultiplaEscolha, questao.Tipo);
            Assert.Equal("A", questao.Caderno);
            Assert.Equal(4, questao.QuantidadeAlternativas);
        }

        [Fact]
        public void Deve_Criar_Questao_Com_Construtor_Parametros()
        {
            var questao = new Questao("Texto base", 101, "Enunciado 2", 2, 201, QuestaoTipo.RespostaConstruida, "B", 5);

            Assert.Equal(2, questao.Ordem);
            Assert.Equal("Texto base", questao.TextoBase);
            Assert.Equal("Enunciado 2", questao.Enunciado);
            Assert.Equal(101, questao.QuestaoLegadoId);
            Assert.Equal(201, questao.ProvaId);
            Assert.Equal(QuestaoTipo.RespostaConstruida, questao.Tipo);
            Assert.Equal("B", questao.Caderno);
            Assert.Equal(5, questao.QuantidadeAlternativas);
        }
    }
}
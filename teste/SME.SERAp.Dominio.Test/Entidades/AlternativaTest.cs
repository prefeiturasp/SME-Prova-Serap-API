using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class AlternativaTest
    {
        [Fact]
        public void Deve_Criar_Alternativa_Com_Construtor_Padrao()
        {
            var alternativa = new Alternativa
            {
                Ordem = 1,
                Numeracao = "A",
                Descricao = "Descrição da alternativa",
                QuestaoId = 10,
                Correta = true,
                AlternativaLegadoId = 99
            };

            Assert.Equal(1, alternativa.Ordem);
            Assert.Equal("A", alternativa.Numeracao);
            Assert.Equal("Descrição da alternativa", alternativa.Descricao);
            Assert.Equal(10, alternativa.QuestaoId);
            Assert.True(alternativa.Correta);
            Assert.Equal(99, alternativa.AlternativaLegadoId);
        }

        [Fact]
        public void Deve_Criar_Alternativa_Com_Construtor_Parametros()
        {
            var alternativa = new Alternativa(2, "B", "Outra descrição", 20, false, 88);

            Assert.Equal(2, alternativa.Ordem);
            Assert.Equal("B", alternativa.Numeracao);
            Assert.Equal("Outra descrição", alternativa.Descricao);
            Assert.Equal(20, alternativa.QuestaoId);
            Assert.False(alternativa.Correta);
            Assert.Equal(88, alternativa.AlternativaLegadoId);
        }

        [Fact]
        public void Deve_Criar_Alternativa_Correta_Via_Construtor()
        {
            var alternativa = new Alternativa(1, "A", "Resposta correta", 5, true, 50);

            Assert.True(alternativa.Correta);
        }

        [Fact]
        public void Deve_Criar_Alternativa_Incorreta_Via_Construtor()
        {
            var alternativa = new Alternativa(3, "C", "Resposta errada", 5, false, 51);

            Assert.False(alternativa.Correta);
        }

        [Fact]
        public void Deve_Criar_Alternativa_Com_Descricao_Nula()
        {
            var alternativa = new Alternativa(1, "A", null, 1, false, 1);

            Assert.Null(alternativa.Descricao);
        }

        [Fact]
        public void Deve_Criar_Alternativa_Com_Numeracao_Nula()
        {
            var alternativa = new Alternativa(1, null, "Descrição", 1, false, 1);

            Assert.Null(alternativa.Numeracao);
        }

        [Fact]
        public void Deve_Criar_Alternativa_Com_Ordem_Zero()
        {
            var alternativa = new Alternativa(0, "A", "Descrição", 1, false, 1);

            Assert.Equal(0, alternativa.Ordem);
        }

        [Fact]
        public void Deve_Criar_Alternativa_Com_QuestaoId_Maximo()
        {
            var alternativa = new Alternativa(1, "A", "Desc", long.MaxValue, false, 1);

            Assert.Equal(long.MaxValue, alternativa.QuestaoId);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var alternativa = new Alternativa();
            alternativa.Ordem = 5;
            alternativa.Numeracao = "E";
            alternativa.Descricao = "Modificada";
            alternativa.QuestaoId = 99;
            alternativa.Correta = true;
            alternativa.AlternativaLegadoId = 123;

            Assert.Equal(5, alternativa.Ordem);
            Assert.Equal("E", alternativa.Numeracao);
            Assert.Equal("Modificada", alternativa.Descricao);
            Assert.Equal(99, alternativa.QuestaoId);
            Assert.True(alternativa.Correta);
            Assert.Equal(123, alternativa.AlternativaLegadoId);
        }

        [Fact]
        public void Deve_Criar_Multiplas_Alternativas_Com_Mesma_QuestaoId()
        {
            var alt1 = new Alternativa(1, "A", "Desc A", 10, true, 1);
            var alt2 = new Alternativa(2, "B", "Desc B", 10, false, 2);
            var alt3 = new Alternativa(3, "C", "Desc C", 10, false, 3);

            Assert.Equal(alt1.QuestaoId, alt2.QuestaoId);
            Assert.Equal(alt2.QuestaoId, alt3.QuestaoId);
            Assert.True(alt1.Correta);
            Assert.False(alt2.Correta);
            Assert.False(alt3.Correta);
        }
    }
}
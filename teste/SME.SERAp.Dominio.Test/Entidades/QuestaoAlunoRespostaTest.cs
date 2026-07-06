using System;
using Xunit;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class QuestaoAlunoRespostaTest
    {
        [Fact]
        public void Deve_Criar_QuestaoAlunoResposta_Com_Construtor_Padrao()
        {
            var antes = DateTime.Now;
            var resposta = new QuestaoAlunoResposta
            {
                QuestaoId = 1,
                AlunoRa = 123,
                AlternativaId = 5,
                Resposta = "Resposta do aluno",
                TempoRespostaAluno = 30,
                Visualizacoes = 2
            };
            var depois = DateTime.Now;

            Assert.Equal(1, resposta.QuestaoId);
            Assert.Equal(123, resposta.AlunoRa);
            Assert.Equal(5, resposta.AlternativaId);
            Assert.Equal("Resposta do aluno", resposta.Resposta);
            Assert.Equal(30, resposta.TempoRespostaAluno);
            Assert.Equal(2, resposta.Visualizacoes);
            Assert.InRange(resposta.CriadoEm, antes, depois);
        }

        [Fact]
        public void Deve_Criar_QuestaoAlunoResposta_Com_Construtor_Parametros()
        {
            var criado = new DateTime(2021, 4, 1, 10, 0, 0);
            var resposta = new QuestaoAlunoResposta(2, 456, 7, "Outra resposta", criado, 45, 1);

            Assert.Equal(2, resposta.QuestaoId);
            Assert.Equal(456, resposta.AlunoRa);
            Assert.Equal(7, resposta.AlternativaId);
            Assert.Equal("Outra resposta", resposta.Resposta);
            Assert.Equal(45, resposta.TempoRespostaAluno);
            Assert.Equal(1, resposta.Visualizacoes);
            Assert.Equal(criado, resposta.CriadoEm);
        }

        [Fact]
        public void Deve_Aceitar_Alternativa_Nula()
        {
            var criado = DateTime.UtcNow;
            var resposta = new QuestaoAlunoResposta(3, 789, null, "Resposta sem alternativa", criado, 10, 0);

            Assert.Equal(3, resposta.QuestaoId);
            Assert.Equal(789, resposta.AlunoRa);
            Assert.Null(resposta.AlternativaId);
            Assert.Equal("Resposta sem alternativa", resposta.Resposta);
            Assert.Equal(10, resposta.TempoRespostaAluno);
            Assert.Equal(0, resposta.Visualizacoes);
        }
    }
}
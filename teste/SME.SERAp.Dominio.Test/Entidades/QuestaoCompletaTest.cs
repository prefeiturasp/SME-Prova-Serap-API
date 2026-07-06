using System;
using Xunit;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class QuestaoCompletaTest
    {
        [Fact]
        public void Deve_Atribuir_Propriedades_QuestaoCompleta()
        {
            var ultimaAtualizacao = new DateTime(2022, 7, 1);
            var qc = new QuestaoCompleta
            {
                Json = "{\"campo\":\"valor\"}",
                UltimaAtualizacao = ultimaAtualizacao
            };

            Assert.Equal("{\"campo\":\"valor\"}", qc.Json);
            Assert.Equal(ultimaAtualizacao, qc.UltimaAtualizacao);
        }
    }
}
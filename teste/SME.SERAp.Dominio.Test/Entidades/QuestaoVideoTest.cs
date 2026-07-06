using System;
using Xunit;
using SME.SERAp.Prova.Dominio;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class QuestaoVideoTest
    {
        [Fact]
        public void Construtor_Padrao_Deixa_Propriedades_Default()
        {
            var qv = new QuestaoVideo();

            Assert.Equal(0, qv.QuestaoId);
            Assert.Equal(0, qv.ArquivoVideoId);
            Assert.Null(qv.ArquivoThumbnailId);
            Assert.Null(qv.ArquivoVideoConvertidoId);
            Assert.Equal(default, qv.CriadoEm);
            Assert.Equal(default, qv.AtualizadoEm);
        }

        [Fact]
        public void Deve_Criar_QuestaoVideo_Com_Construtor_Parametros()
        {
            var antes = DateTime.Now;
            var qv = new QuestaoVideo(10, 20, null, 40);
            var depois = DateTime.Now;

            Assert.Equal(10, qv.QuestaoId);
            Assert.Equal(20, qv.ArquivoVideoId);
            Assert.Null(qv.ArquivoThumbnailId);
            Assert.Equal(40, qv.ArquivoVideoConvertidoId);
            Assert.InRange(qv.CriadoEm, antes, depois);
            Assert.InRange(qv.AtualizadoEm, antes, depois);
        }
    }
}
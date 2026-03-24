using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Enumerados
{
    public class SituacaoAlunoTest
    {
        [Fact]
        public void Deve_Conter_Membro_Ativo_Com_Valor_1()
        {
            Assert.Equal(1, (int)SituacaoAluno.Ativo);
        }

        [Fact]
        public void Deve_Conter_Membro_Desistente_Com_Valor_2()
        {
            Assert.Equal(2, (int)SituacaoAluno.Desistente);
        }

        [Fact]
        public void Deve_Conter_Membro_Transferido_Com_Valor_3()
        {
            Assert.Equal(3, (int)SituacaoAluno.Transferido);
        }

        [Fact]
        public void Deve_Conter_Membro_VinculoIndevido_Com_Valor_4()
        {
            Assert.Equal(4, (int)SituacaoAluno.VinculoIndevido);
        }

        [Fact]
        public void Deve_Conter_Membro_Concluido_Com_Valor_5()
        {
            Assert.Equal(5, (int)SituacaoAluno.Concluido);
        }

        [Fact]
        public void Deve_Conter_Membro_PendenteRematricula_Com_Valor_6()
        {
            Assert.Equal(6, (int)SituacaoAluno.PendenteRematricula);
        }

        [Fact]
        public void Deve_Conter_Membro_Falecido_Com_Valor_7()
        {
            Assert.Equal(7, (int)SituacaoAluno.Falecido);
        }

        [Fact]
        public void Deve_Conter_Membro_NaoCompareceu_Com_Valor_8()
        {
            Assert.Equal(8, (int)SituacaoAluno.NaoCompareceu);
        }

        [Fact]
        public void Deve_Conter_Membro_Rematriculado_Com_Valor_10()
        {
            Assert.Equal(10, (int)SituacaoAluno.Rematriculado);
        }

        [Fact]
        public void Deve_Conter_Membro_Deslocamento_Com_Valor_11()
        {
            Assert.Equal(11, (int)SituacaoAluno.Deslocamento);
        }

        [Fact]
        public void Deve_Conter_Membro_Cessado_Com_Valor_12()
        {
            Assert.Equal(12, (int)SituacaoAluno.Cessado);
        }

        [Fact]
        public void Deve_Conter_Membro_SemContinuidade_Com_Valor_13()
        {
            Assert.Equal(13, (int)SituacaoAluno.SemContinuidade);
        }

        [Fact]
        public void Deve_Conter_Membro_RemanejadoSaida_Com_Valor_14()
        {
            Assert.Equal(14, (int)SituacaoAluno.RemanejadoSaida);
        }

        [Fact]
        public void Deve_Conter_Membro_ReclassificadoSaida_Com_Valor_15()
        {
            Assert.Equal(15, (int)SituacaoAluno.ReclassificadoSaida);
        }

        [Fact]
        public void Deve_Conter_Membro_TransferidoSED_Com_Valor_16()
        {
            Assert.Equal(16, (int)SituacaoAluno.TransferidoSED);
        }

        [Fact]
        public void Deve_Conter_Membro_DispensadoEdFisica_Com_Valor_17()
        {
            Assert.Equal(17, (int)SituacaoAluno.DispensadoEdFisica);
        }

        [Fact]
        public void Deve_Conter_Exatamente_Dezesseis_Membros()
        {
            var valores = Enum.GetValues(typeof(SituacaoAluno));
            Assert.Equal(16, valores.Length);
        }

        [Fact]
        public void Deve_Conter_Todos_Os_Membros_Esperados()
        {
            var valores = (SituacaoAluno[])Enum.GetValues(typeof(SituacaoAluno));
            Assert.Contains(SituacaoAluno.Ativo, valores);
            Assert.Contains(SituacaoAluno.Desistente, valores);
            Assert.Contains(SituacaoAluno.Transferido, valores);
            Assert.Contains(SituacaoAluno.VinculoIndevido, valores);
            Assert.Contains(SituacaoAluno.Concluido, valores);
            Assert.Contains(SituacaoAluno.PendenteRematricula, valores);
            Assert.Contains(SituacaoAluno.Falecido, valores);
            Assert.Contains(SituacaoAluno.NaoCompareceu, valores);
            Assert.Contains(SituacaoAluno.Rematriculado, valores);
            Assert.Contains(SituacaoAluno.Deslocamento, valores);
            Assert.Contains(SituacaoAluno.Cessado, valores);
            Assert.Contains(SituacaoAluno.SemContinuidade, valores);
            Assert.Contains(SituacaoAluno.RemanejadoSaida, valores);
            Assert.Contains(SituacaoAluno.ReclassificadoSaida, valores);
            Assert.Contains(SituacaoAluno.TransferidoSED, valores);
            Assert.Contains(SituacaoAluno.DispensadoEdFisica, valores);
        }

        [Fact]
        public void Deve_Converter_Inteiro_Para_Membro_Corretamente()
        {
            Assert.Equal(SituacaoAluno.Ativo, (SituacaoAluno)1);
            Assert.Equal(SituacaoAluno.Desistente, (SituacaoAluno)2);
            Assert.Equal(SituacaoAluno.Transferido, (SituacaoAluno)3);
            Assert.Equal(SituacaoAluno.Falecido, (SituacaoAluno)7);
            Assert.Equal(SituacaoAluno.DispensadoEdFisica, (SituacaoAluno)17);
        }
    }
}
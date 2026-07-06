using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Enumerados
{
    public class DownloadProvaAlunoSituacaoTest
    {
        [Fact]
        public void Deve_Conter_Membro_Incluir_Com_Valor_1()
        {
            Assert.Equal(1, (int)DownloadProvaAlunoSituacao.Incluir);
        }

        [Fact]
        public void Deve_Conter_Membro_Excluir_Com_Valor_3()
        {
            Assert.Equal(3, (int)DownloadProvaAlunoSituacao.Excluir);
        }

        [Fact]
        public void Deve_Conter_Exatamente_Dois_Membros()
        {
            var valores = Enum.GetValues(typeof(DownloadProvaAlunoSituacao));
            Assert.Equal(2, valores.Length);
        }

        [Fact]
        public void Deve_Conter_Todos_Os_Membros_Esperados()
        {
            var valores = (DownloadProvaAlunoSituacao[])Enum.GetValues(typeof(DownloadProvaAlunoSituacao));
            Assert.Contains(DownloadProvaAlunoSituacao.Incluir, valores);
            Assert.Contains(DownloadProvaAlunoSituacao.Excluir, valores);
        }

        [Fact]
        public void Deve_Converter_Inteiro_Para_Membro_Corretamente()
        {
            Assert.Equal(DownloadProvaAlunoSituacao.Incluir, (DownloadProvaAlunoSituacao)1);
            Assert.Equal(DownloadProvaAlunoSituacao.Excluir, (DownloadProvaAlunoSituacao)3);
        }

        [Fact]
        public void Incluir_Deve_Ser_Menor_Que_Excluir()
        {
            Assert.True(DownloadProvaAlunoSituacao.Incluir < DownloadProvaAlunoSituacao.Excluir);
        }
    }
}
using SME.SERAp.Prova.Dominio;
using System;
using Xunit;

namespace SME.SERAp.Dominio.Test.Enumerados
{
    public class TipoSituacaoTest
    {
        [Fact]
        public void Deve_Conter_Membro_Ativo_Com_Valor_1()
        {
            Assert.Equal(1, (int)TipoSituacao.Ativo);
        }

        [Fact]
        public void Deve_Conter_Membro_Excluido_Com_Valor_3()
        {
            Assert.Equal(3, (int)TipoSituacao.Excluído);
        }

        [Fact]
        public void Deve_Conter_Exatamente_Dois_Membros()
        {
            var valores = Enum.GetValues(typeof(TipoSituacao));
            Assert.Equal(2, valores.Length);
        }

        [Fact]
        public void Deve_Conter_Todos_Os_Membros_Esperados()
        {
            var valores = (TipoSituacao[])Enum.GetValues(typeof(TipoSituacao));
            Assert.Contains(TipoSituacao.Ativo, valores);
            Assert.Contains(TipoSituacao.Excluído, valores);
        }

        [Fact]
        public void Deve_Converter_Inteiro_Para_Membro_Corretamente()
        {
            Assert.Equal(TipoSituacao.Ativo, (TipoSituacao)1);
            Assert.Equal(TipoSituacao.Excluído, (TipoSituacao)3);
        }

        [Fact]
        public void Ativo_Deve_Ser_Menor_Que_Excluido()
        {
            Assert.True(TipoSituacao.Ativo < TipoSituacao.Excluído);
        }
    }
}
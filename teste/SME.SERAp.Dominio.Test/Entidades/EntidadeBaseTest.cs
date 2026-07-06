using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    internal class EntidadeBaseConcreta : EntidadeBase { }

    public class EntidadeBaseTest
    {
        [Fact]
        public void Deve_Criar_EntidadeBase_Com_Id_Padrao_Zero()
        {
            var entidade = new EntidadeBaseConcreta();

            Assert.Equal(0, entidade.Id);
        }

        [Fact]
        public void Deve_Atribuir_Id_A_EntidadeBase()
        {
            var entidade = new EntidadeBaseConcreta { Id = 10 };

            Assert.Equal(10, entidade.Id);
        }

        [Fact]
        public void Deve_Atribuir_Id_Maximo_A_EntidadeBase()
        {
            var entidade = new EntidadeBaseConcreta { Id = long.MaxValue };

            Assert.Equal(long.MaxValue, entidade.Id);
        }

        [Fact]
        public void Deve_Alterar_Id_Apos_Criacao()
        {
            var entidade = new EntidadeBaseConcreta { Id = 1 };
            entidade.Id = 99;

            Assert.Equal(99, entidade.Id);
        }

        [Fact]
        public void Deve_Criar_Duas_Entidades_Com_Ids_Distintos()
        {
            var e1 = new EntidadeBaseConcreta { Id = 1 };
            var e2 = new EntidadeBaseConcreta { Id = 2 };

            Assert.NotEqual(e1.Id, e2.Id);
        }
    }
}
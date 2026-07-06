using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class CadernoAlunoTest
    {
        [Fact]
        public void Deve_Criar_CadernoAluno_Com_Construtor_Padrao()
        {
            var caderno = new CadernoAluno
            {
                AlunoId = 1,
                ProvaId = 2,
                Caderno = "Caderno A"
            };

            Assert.Equal(1, caderno.AlunoId);
            Assert.Equal(2, caderno.ProvaId);
            Assert.Equal("Caderno A", caderno.Caderno);
        }

        [Fact]
        public void Deve_Criar_CadernoAluno_Com_Construtor_Parametros()
        {
            var caderno = new CadernoAluno(10, 20, "Caderno B");

            Assert.Equal(10, caderno.AlunoId);
            Assert.Equal(20, caderno.ProvaId);
            Assert.Equal("Caderno B", caderno.Caderno);
        }

        [Fact]
        public void Deve_Criar_CadernoAluno_Com_Caderno_Nulo()
        {
            var caderno = new CadernoAluno(1, 1, null);

            Assert.Null(caderno.Caderno);
        }

        [Fact]
        public void Deve_Criar_CadernoAluno_Com_Caderno_Vazio()
        {
            var caderno = new CadernoAluno(1, 1, "");

            Assert.Equal("", caderno.Caderno);
        }

        [Fact]
        public void Deve_Criar_CadernoAluno_Com_Ids_Maximos()
        {
            var caderno = new CadernoAluno(long.MaxValue, long.MaxValue, "Caderno");

            Assert.Equal(long.MaxValue, caderno.AlunoId);
            Assert.Equal(long.MaxValue, caderno.ProvaId);
        }

        [Fact]
        public void Deve_Criar_CadernoAluno_Via_Construtor_Padrao_Com_Valores_Default()
        {
            var caderno = new CadernoAluno();

            Assert.Equal(0, caderno.AlunoId);
            Assert.Equal(0, caderno.ProvaId);
            Assert.Null(caderno.Caderno);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var caderno = new CadernoAluno();
            caderno.AlunoId = 99;
            caderno.ProvaId = 88;
            caderno.Caderno = "Alterado";

            Assert.Equal(99, caderno.AlunoId);
            Assert.Equal(88, caderno.ProvaId);
            Assert.Equal("Alterado", caderno.Caderno);
        }

        [Fact]
        public void Deve_Criar_CadernoAluno_Com_AlunoId_E_ProvaId_Diferentes()
        {
            var caderno = new CadernoAluno(5, 10, "C");

            Assert.NotEqual(caderno.AlunoId, caderno.ProvaId);
        }

        [Fact]
        public void Deve_Criar_CadernoAluno_Com_AlunoId_E_ProvaId_Iguais()
        {
            var caderno = new CadernoAluno(7, 7, "C");

            Assert.Equal(caderno.AlunoId, caderno.ProvaId);
        }

        [Fact]
        public void Deve_Herdar_De_EntidadeBase()
        {
            var caderno = new CadernoAluno();

            Assert.IsAssignableFrom<EntidadeBase>(caderno);
        }

        [Fact]
        public void Deve_Criar_CadernoAluno_Com_Id_EntidadeBase()
        {
            var caderno = new CadernoAluno { Id = 42, AlunoId = 1, ProvaId = 2, Caderno = "X" };

            Assert.Equal(42, caderno.Id);
        }
    }
}
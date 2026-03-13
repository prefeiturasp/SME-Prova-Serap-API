using SME.SERAp.Prova.Dominio;
using Xunit;

namespace SME.SERAp.Dominio.Test.Entidades
{
    public class AlunoEolTest
    {
        [Fact]
        public void Deve_Criar_AlunoEol_Com_Construtor_Padrao()
        {
            var alunoEol = new AlunoEol
            {
                Nome = "João",
                NomeSocial = "Joãozinho"
            };

            Assert.Equal("João", alunoEol.Nome);
            Assert.Equal("Joãozinho", alunoEol.NomeSocial);
        }

        [Fact]
        public void NomeFinal_Deve_Retornar_Nome_Quando_Preenchido()
        {
            var alunoEol = new AlunoEol { Nome = "Maria", NomeSocial = "Mariazinha" };

            var nomeFinal = alunoEol.NomeFinal();

            Assert.Equal("Maria", nomeFinal);
        }

        [Fact]
        public void NomeFinal_Deve_Retornar_Nome_Quando_NomeSocial_Nulo()
        {
            var alunoEol = new AlunoEol { Nome = "Carlos", NomeSocial = null };

            var nomeFinal = alunoEol.NomeFinal();

            Assert.Equal("Carlos", nomeFinal);
        }

        [Fact]
        public void NomeFinal_Deve_Retornar_Nome_Quando_NomeSocial_Vazio()
        {
            var alunoEol = new AlunoEol { Nome = "Ana", NomeSocial = "" };

            var nomeFinal = alunoEol.NomeFinal();

            Assert.Equal("Ana", nomeFinal);
        }

        [Fact]
        public void NomeFinal_Deve_Retornar_Nulo_Quando_Nome_Nulo()
        {
            var alunoEol = new AlunoEol { Nome = null, NomeSocial = "Social" };

            var nomeFinal = alunoEol.NomeFinal();

            Assert.Null(nomeFinal);
        }

        [Fact]
        public void NomeFinal_Deve_Retornar_Nome_Vazio_Quando_Nome_Vazio()
        {
            var alunoEol = new AlunoEol { Nome = "", NomeSocial = "Social" };

            var nomeFinal = alunoEol.NomeFinal();

            Assert.Equal("", nomeFinal);
        }

        [Fact]
        public void Deve_Criar_AlunoEol_Com_NomeSocial_Nulo()
        {
            var alunoEol = new AlunoEol { Nome = "Pedro", NomeSocial = null };

            Assert.Equal("Pedro", alunoEol.Nome);
            Assert.Null(alunoEol.NomeSocial);
        }

        [Fact]
        public void Deve_Criar_AlunoEol_Com_Valores_Default()
        {
            var alunoEol = new AlunoEol();

            Assert.Null(alunoEol.Nome);
            Assert.Null(alunoEol.NomeSocial);
        }

        [Fact]
        public void NomeFinal_Deve_Ser_Consistente_Em_Multiplas_Chamadas()
        {
            var alunoEol = new AlunoEol { Nome = "Lucia", NomeSocial = "Lu" };

            var resultado1 = alunoEol.NomeFinal();
            var resultado2 = alunoEol.NomeFinal();

            Assert.Equal(resultado1, resultado2);
        }

        [Fact]
        public void NomeFinal_Nao_Deve_Retornar_NomeSocial()
        {
            var alunoEol = new AlunoEol { Nome = "Bruno", NomeSocial = "Bruninho" };

            var nomeFinal = alunoEol.NomeFinal();

            Assert.NotEqual(alunoEol.NomeSocial, nomeFinal);
        }

        [Fact]
        public void Deve_Alterar_Nome_Apos_Criacao()
        {
            var alunoEol = new AlunoEol { Nome = "Original" };
            alunoEol.Nome = "Alterado";

            Assert.Equal("Alterado", alunoEol.NomeFinal());
        }
    }
}
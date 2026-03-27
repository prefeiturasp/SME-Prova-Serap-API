namespace SME.SERAp.Prova.Infra.Test.Dtos.Aluno
{
    public class AlunoDetalheDtoTest
    {
        [Fact]
        public void Deve_Criar_AlunoDetalheDto_Com_Construtor_Padrao()
        {
            var dto = new AlunoDetalheDto
            {
                AlunoId = 1,
                DreAbreviacao = "DRE-01",
                Escola = "Escola Teste",
                Turma = "5A",
                Nome = "João Silva",
                NomeSocial = "Joãozinho"
            };

            Assert.Equal(1, dto.AlunoId);
            Assert.Equal("DRE-01", dto.DreAbreviacao);
            Assert.Equal("Escola Teste", dto.Escola);
            Assert.Equal("5A", dto.Turma);
            Assert.Equal("João Silva", dto.Nome);
            Assert.Equal("Joãozinho", dto.NomeSocial);
        }

        [Fact]
        public void Deve_Criar_AlunoDetalheDto_Com_Valores_Default()
        {
            var dto = new AlunoDetalheDto();

            Assert.Equal(0, dto.AlunoId);
            Assert.Null(dto.DreAbreviacao);
            Assert.Null(dto.Escola);
            Assert.Null(dto.Turma);
            Assert.Null(dto.Nome);
            Assert.Null(dto.NomeSocial);
        }

        [Fact]
        public void NomeFinal_Deve_Retornar_NomeSocial_Quando_Preenchido()
        {
            var dto = new AlunoDetalheDto { Nome = "Maria", NomeSocial = "Mariazinha" };

            Assert.Equal("Mariazinha", dto.NomeFinal());
        }

        [Fact]
        public void NomeFinal_Deve_Retornar_Nome_Quando_NomeSocial_Nulo()
        {
            var dto = new AlunoDetalheDto { Nome = "Carlos", NomeSocial = null };

            Assert.Equal("Carlos", dto.NomeFinal());
        }

        [Fact]
        public void NomeFinal_Deve_Retornar_Nome_Quando_NomeSocial_Vazio()
        {
            var dto = new AlunoDetalheDto { Nome = "Ana", NomeSocial = "" };

            Assert.Equal("Ana", dto.NomeFinal());
        }

        [Fact]
        public void NomeFinal_Deve_Retornar_Nulo_Quando_Nome_Nulo_E_NomeSocial_Nulo()
        {
            var dto = new AlunoDetalheDto { Nome = null, NomeSocial = null };

            Assert.Null(dto.NomeFinal());
        }

        [Fact]
        public void NomeFinal_Deve_Retornar_Nulo_Quando_Nome_Nulo_E_NomeSocial_Vazio()
        {
            var dto = new AlunoDetalheDto { Nome = null, NomeSocial = "" };

            Assert.Null(dto.NomeFinal());
        }

        [Fact]
        public void NomeFinal_Deve_Ser_Consistente_Em_Multiplas_Chamadas()
        {
            var dto = new AlunoDetalheDto { Nome = "Pedro", NomeSocial = "Pedrinho" };

            Assert.Equal(dto.NomeFinal(), dto.NomeFinal());
        }

        [Fact]
        public void NomeFinal_Deve_Refletir_NomeSocial_Apos_Alteracao()
        {
            var dto = new AlunoDetalheDto { Nome = "Lucas", NomeSocial = null };

            Assert.Equal("Lucas", dto.NomeFinal());

            dto.NomeSocial = "Lucão";

            Assert.Equal("Lucão", dto.NomeFinal());
        }

        [Fact]
        public void Deve_Criar_AlunoDetalheDto_Com_AlunoId_Maximo()
        {
            var dto = new AlunoDetalheDto { AlunoId = long.MaxValue };

            Assert.Equal(long.MaxValue, dto.AlunoId);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var dto = new AlunoDetalheDto { Nome = "Original", Escola = "Escola A" };
            dto.Nome = "Alterado";
            dto.Escola = "Escola B";

            Assert.Equal("Alterado", dto.Nome);
            Assert.Equal("Escola B", dto.Escola);
        }
    }
}
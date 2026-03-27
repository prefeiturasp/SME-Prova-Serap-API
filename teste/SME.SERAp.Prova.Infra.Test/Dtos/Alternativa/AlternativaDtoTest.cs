namespace SME.SERAp.Prova.Infra.Test.Dtos.Alternativa
{
    public class AlternativaDtoTest
    {
        [Fact]
        public void Deve_Criar_AlternativaDto_Com_Construtor_Padrao()
        {
            var dto = new AlternativaDto
            {
                QuestaoId = 10,
                Id = 1,
                AlternativaLegadoId = 99,
                Descricao = "Alternativa A",
                Ordem = 1,
                Numeracao = "A"
            };

            Assert.Equal(10, dto.QuestaoId);
            Assert.Equal(1, dto.Id);
            Assert.Equal(99, dto.AlternativaLegadoId);
            Assert.Equal("Alternativa A", dto.Descricao);
            Assert.Equal(1, dto.Ordem);
            Assert.Equal("A", dto.Numeracao);
        }

        [Fact]
        public void Deve_Criar_AlternativaDto_Com_Valores_Default()
        {
            var dto = new AlternativaDto();

            Assert.Equal(0, dto.QuestaoId);
            Assert.Equal(0, dto.Id);
            Assert.Equal(0, dto.AlternativaLegadoId);
            Assert.Null(dto.Descricao);
            Assert.Equal(0, dto.Ordem);
            Assert.Null(dto.Numeracao);
        }

        [Fact]
        public void Deve_Criar_AlternativaDto_Com_Descricao_Nula()
        {
            var dto = new AlternativaDto { Descricao = null };

            Assert.Null(dto.Descricao);
        }

        [Fact]
        public void Deve_Criar_AlternativaDto_Com_Numeracao_Nula()
        {
            var dto = new AlternativaDto { Numeracao = null };

            Assert.Null(dto.Numeracao);
        }

        [Fact]
        public void Deve_Criar_AlternativaDto_Com_Ids_Maximos()
        {
            var dto = new AlternativaDto
            {
                QuestaoId = long.MaxValue,
                Id = long.MaxValue,
                AlternativaLegadoId = long.MaxValue
            };

            Assert.Equal(long.MaxValue, dto.QuestaoId);
            Assert.Equal(long.MaxValue, dto.Id);
            Assert.Equal(long.MaxValue, dto.AlternativaLegadoId);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var dto = new AlternativaDto { Descricao = "Original", Ordem = 1 };
            dto.Descricao = "Alterada";
            dto.Ordem = 3;

            Assert.Equal("Alterada", dto.Descricao);
            Assert.Equal(3, dto.Ordem);
        }

        [Fact]
        public void Deve_Criar_AlternativaDto_Com_Ordem_Zero()
        {
            var dto = new AlternativaDto { Ordem = 0 };

            Assert.Equal(0, dto.Ordem);
        }
    }
}
namespace SME.SERAp.Prova.Infra.Test.Dtos.Alternativa
{
    public class AlternativaDetalheRetornoDtoTest
    {
        [Fact]
        public void Deve_Criar_AlternativaDetalheRetornoDto_Com_Construtor_Parametros()
        {
            var dto = new AlternativaDetalheRetornoDto(1, "Descrição A", 1, "A", 10, 99);

            Assert.Equal(1, dto.Id);
            Assert.Equal("Descrição A", dto.Descricao);
            Assert.Equal(1, dto.Ordem);
            Assert.Equal("A", dto.Numeracao);
            Assert.Equal(10, dto.QuestaoId);
            Assert.Equal(99, dto.AlternativaLegadoId);
        }

        [Fact]
        public void Deve_Criar_AlternativaDetalheRetornoDto_Com_Descricao_Nula()
        {
            var dto = new AlternativaDetalheRetornoDto(1, null, 1, "A", 10, 99);

            Assert.Null(dto.Descricao);
        }

        [Fact]
        public void Deve_Criar_AlternativaDetalheRetornoDto_Com_Numeracao_Nula()
        {
            var dto = new AlternativaDetalheRetornoDto(1, "Desc", 1, null, 10, 99);

            Assert.Null(dto.Numeracao);
        }

        [Fact]
        public void Deve_Criar_AlternativaDetalheRetornoDto_Com_Ordem_Zero()
        {
            var dto = new AlternativaDetalheRetornoDto(1, "Desc", 0, "A", 10, 99);

            Assert.Equal(0, dto.Ordem);
        }

        [Fact]
        public void Deve_Criar_AlternativaDetalheRetornoDto_Com_Ids_Maximos()
        {
            var dto = new AlternativaDetalheRetornoDto(long.MaxValue, "Desc", 1, "A", long.MaxValue, long.MaxValue);

            Assert.Equal(long.MaxValue, dto.Id);
            Assert.Equal(long.MaxValue, dto.QuestaoId);
            Assert.Equal(long.MaxValue, dto.AlternativaLegadoId);
        }

        [Fact]
        public void Deve_Alterar_Propriedades_Apos_Criacao()
        {
            var dto = new AlternativaDetalheRetornoDto(1, "Original", 1, "A", 10, 99);
            dto.Descricao = "Alterada";
            dto.Ordem = 5;
            dto.Numeracao = "E";

            Assert.Equal("Alterada", dto.Descricao);
            Assert.Equal(5, dto.Ordem);
            Assert.Equal("E", dto.Numeracao);
        }

        [Fact]
        public void Deve_Criar_Multiplas_Alternativas_Com_Mesma_QuestaoId()
        {
            var dto1 = new AlternativaDetalheRetornoDto(1, "Desc A", 1, "A", 10, 100);
            var dto2 = new AlternativaDetalheRetornoDto(2, "Desc B", 2, "B", 10, 101);

            Assert.Equal(dto1.QuestaoId, dto2.QuestaoId);
            Assert.NotEqual(dto1.Id, dto2.Id);
        }
    }
}
namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova
{
    public class QuestaoOrdemDtoTest
    {
        private AlternativaOrdemDto[] CriarAlternativas()
        {
            return new[]
            {
                new AlternativaOrdemDto(1, 1, 1),
                new AlternativaOrdemDto(2, 2, 2)
            };
        }

        [Fact]
        public void Deve_Criar_QuestaoOrdemDto_Com_Construtor_Parametros()
        {
            var alternativas = CriarAlternativas();
            var dto = new QuestaoOrdemDto(10, 20, alternativas, 3);

            Assert.Equal(10, dto.QuestaoId);
            Assert.Equal(20, dto.QuestaoLegadoId);
            Assert.Equal(alternativas, dto.Alternativas);
            Assert.Equal(3, dto.Ordem);
        }

        [Fact]
        public void Deve_Atribuir_QuestaoId_Corretamente()
        {
            var dto = new QuestaoOrdemDto(55, 1, null, 1);
            Assert.Equal(55, dto.QuestaoId);
        }

        [Fact]
        public void Deve_Atribuir_QuestaoLegadoId_Corretamente()
        {
            var dto = new QuestaoOrdemDto(1, 77, null, 1);
            Assert.Equal(77, dto.QuestaoLegadoId);
        }

        [Fact]
        public void Deve_Atribuir_Ordem_Corretamente()
        {
            var dto = new QuestaoOrdemDto(1, 1, null, 8);
            Assert.Equal(8, dto.Ordem);
        }

        [Fact]
        public void Deve_Aceitar_Alternativas_Nulas()
        {
            var dto = new QuestaoOrdemDto(1, 1, null, 1);
            Assert.Null(dto.Alternativas);
        }

        [Fact]
        public void Deve_Aceitar_Alternativas_Array_Vazio()
        {
            var dto = new QuestaoOrdemDto(1, 1, System.Array.Empty<AlternativaOrdemDto>(), 1);
            Assert.Empty(dto.Alternativas);
        }

        [Fact]
        public void Deve_Preservar_Referencia_Alternativas()
        {
            var alternativas = CriarAlternativas();
            var dto = new QuestaoOrdemDto(1, 1, alternativas, 1);
            Assert.Same(alternativas, dto.Alternativas);
        }

        [Fact]
        public void Deve_Aceitar_Ordem_Zero()
        {
            var dto = new QuestaoOrdemDto(1, 1, null, 0);
            Assert.Equal(0, dto.Ordem);
        }

        [Fact]
        public void Deve_Aceitar_Valores_Maximos_Long()
        {
            var dto = new QuestaoOrdemDto(long.MaxValue, long.MaxValue, null, int.MaxValue);

            Assert.Equal(long.MaxValue, dto.QuestaoId);
            Assert.Equal(long.MaxValue, dto.QuestaoLegadoId);
            Assert.Equal(int.MaxValue, dto.Ordem);
        }

        [Fact]
        public void Deve_Permitir_Alterar_Propriedades_Apos_Construcao()
        {
            var dto = new QuestaoOrdemDto(1, 1, null, 1);
            dto.QuestaoId = 99;
            dto.QuestaoLegadoId = 88;
            dto.Ordem = 5;

            Assert.Equal(99, dto.QuestaoId);
            Assert.Equal(88, dto.QuestaoLegadoId);
            Assert.Equal(5, dto.Ordem);
        }
    }
}
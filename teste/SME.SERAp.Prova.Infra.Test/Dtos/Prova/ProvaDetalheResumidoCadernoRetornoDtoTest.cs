namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova
{
    public class ProvaDetalheResumidoCadernoRetornoDtoTest
    {
        [Fact]
        public void Deve_Criar_ProvaDetalheResumidoCadernoRetornoDto_Com_Construtor_Parametros()
        {
            var alternativas = new[] { new AlternativaOrdemDto(1, 1, 1) };
            var questoes = new[] { new QuestaoOrdemDto(10, 10, alternativas, 1) };
            var contextos = new long[] { 100, 200 };

            var dto = new ProvaDetalheResumidoCadernoRetornoDto(5, questoes, contextos);

            Assert.Equal(5, dto.ProvaId);
            Assert.Equal(questoes, dto.Questoes);
            Assert.Equal(contextos, dto.ContextosProvaIds);
        }

        [Fact]
        public void Deve_Aceitar_Questoes_Nulas()
        {
            var dto = new ProvaDetalheResumidoCadernoRetornoDto(1, null, new long[] { 1 });
            Assert.Null(dto.Questoes);
        }

        [Fact]
        public void Deve_Aceitar_ContextosProvaIds_Nulos()
        {
            var dto = new ProvaDetalheResumidoCadernoRetornoDto(1, System.Array.Empty<QuestaoOrdemDto>(), null);
            Assert.Null(dto.ContextosProvaIds);
        }

        [Fact]
        public void Deve_Aceitar_Arrays_Vazios()
        {
            var dto = new ProvaDetalheResumidoCadernoRetornoDto(1, System.Array.Empty<QuestaoOrdemDto>(), System.Array.Empty<long>());

            Assert.Empty(dto.Questoes);
            Assert.Empty(dto.ContextosProvaIds);
        }

        [Fact]
        public void Deve_Preservar_Referencia_Questoes()
        {
            var questoes = new[] { new QuestaoOrdemDto(1, 1, null, 1) };
            var dto = new ProvaDetalheResumidoCadernoRetornoDto(1, questoes, null);

            Assert.Same(questoes, dto.Questoes);
        }

        [Fact]
        public void Deve_Preservar_Referencia_ContextosProvaIds()
        {
            var contextos = new long[] { 10, 20, 30 };
            var dto = new ProvaDetalheResumidoCadernoRetornoDto(1, null, contextos);

            Assert.Same(contextos, dto.ContextosProvaIds);
        }

        [Fact]
        public void Deve_Aceitar_ProvaId_Valor_Maximo_Long()
        {
            var dto = new ProvaDetalheResumidoCadernoRetornoDto(long.MaxValue, null, null);
            Assert.Equal(long.MaxValue, dto.ProvaId);
        }
    }
}
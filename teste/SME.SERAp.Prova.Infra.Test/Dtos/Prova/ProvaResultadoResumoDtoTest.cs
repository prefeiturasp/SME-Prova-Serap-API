namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova
{
    public class ProvaResultadoResumoDtoTest
    {
        [Fact]
        public void Deve_Criar_ProvaResultadoResumoDto_Com_Construtor_Padrao()
        {
            var dto = new ProvaResultadoResumoDto();

            Assert.Equal(0, dto.IdQuestaoLegado);
            Assert.Null(dto.DescricaoQuestao);
            Assert.Equal(0, dto.OrdemQuestao);
            Assert.Equal(0, dto.TipoQuestao);
            Assert.Null(dto.AlternativaAluno);
            Assert.Null(dto.AlternativaCorreta);
            Assert.False(dto.Correta);
            Assert.False(dto.RespostaConstruidaRespondida);
        }

        [Fact]
        public void Deve_Criar_ProvaResultadoResumoDto_Completo()
        {
            var dto = new ProvaResultadoResumoDto
            {
                IdQuestaoLegado = 10,
                DescricaoQuestao = "Questão de Matemática",
                OrdemQuestao = 3,
                TipoQuestao = 1,
                AlternativaAluno = "C",
                AlternativaCorreta = "C",
                Correta = true,
                RespostaConstruidaRespondida = false
            };

            Assert.Equal(10, dto.IdQuestaoLegado);
            Assert.Equal("Questão de Matemática", dto.DescricaoQuestao);
            Assert.Equal(3, dto.OrdemQuestao);
            Assert.Equal(1, dto.TipoQuestao);
            Assert.Equal("C", dto.AlternativaAluno);
            Assert.Equal("C", dto.AlternativaCorreta);
            Assert.True(dto.Correta);
            Assert.False(dto.RespostaConstruidaRespondida);
        }

        [Fact]
        public void Deve_Aceitar_Correta_Falso()
        {
            var dto = new ProvaResultadoResumoDto { Correta = false };
            Assert.False(dto.Correta);
        }

        [Fact]
        public void Deve_Aceitar_RespostaConstruidaRespondida_Verdadeiro()
        {
            var dto = new ProvaResultadoResumoDto { RespostaConstruidaRespondida = true };
            Assert.True(dto.RespostaConstruidaRespondida);
        }

        [Fact]
        public void Deve_Aceitar_AlternativaAluno_Nula()
        {
            var dto = new ProvaResultadoResumoDto { AlternativaAluno = null };
            Assert.Null(dto.AlternativaAluno);
        }

        [Fact]
        public void Deve_Aceitar_AlternativaCorreta_Nula()
        {
            var dto = new ProvaResultadoResumoDto { AlternativaCorreta = null };
            Assert.Null(dto.AlternativaCorreta);
        }

        [Fact]
        public void Deve_Aceitar_IdQuestaoLegado_Valor_Maximo_Long()
        {
            var dto = new ProvaResultadoResumoDto { IdQuestaoLegado = long.MaxValue };
            Assert.Equal(long.MaxValue, dto.IdQuestaoLegado);
        }
    }
}
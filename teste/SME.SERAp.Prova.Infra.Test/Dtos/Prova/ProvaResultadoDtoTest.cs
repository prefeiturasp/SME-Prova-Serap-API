namespace SME.SERAp.Prova.Infra.Test.Dtos.Prova
{
    public class ProvaResultadoDtoTest
    {
        [Fact]
        public void Deve_Criar_ProvaResultadoDto_Com_Propriedades_Padrao()
        {
            var dto = new ProvaResultadoDto();

            Assert.Null(dto.Proficiencia);
            Assert.Null(dto.Resumos);
        }

        [Fact]
        public void Deve_Atribuir_Proficiencia_Corretamente()
        {
            var dto = new ProvaResultadoDto { Proficiencia = 275.5m };
            Assert.Equal(275.5m, dto.Proficiencia);
        }

        [Fact]
        public void Deve_Aceitar_Proficiencia_Nula()
        {
            var dto = new ProvaResultadoDto { Proficiencia = null };
            Assert.Null(dto.Proficiencia);
        }

        [Fact]
        public void Deve_Atribuir_Resumos_Corretamente()
        {
            var resumos = new List<ProvaResultadoResumoDto>
            {
                new ProvaResultadoResumoDto { IdQuestaoLegado = 1, AlternativaAluno = "A", Correta = true },
                new ProvaResultadoResumoDto { IdQuestaoLegado = 2, AlternativaAluno = "B", Correta = false }
            };

            var dto = new ProvaResultadoDto { Resumos = resumos };

            Assert.NotNull(dto.Resumos);
            Assert.Equal(2, dto.Resumos.Count());
        }

        [Fact]
        public void Deve_Aceitar_Resumos_Lista_Vazia()
        {
            var dto = new ProvaResultadoDto { Resumos = new List<ProvaResultadoResumoDto>() };
            Assert.Empty(dto.Resumos);
        }

        [Fact]
        public void Deve_Aceitar_Proficiencia_Zero()
        {
            var dto = new ProvaResultadoDto { Proficiencia = 0m };
            Assert.Equal(0m, dto.Proficiencia);
        }

        [Fact]
        public void Deve_Aceitar_Proficiencia_Negativa()
        {
            var dto = new ProvaResultadoDto { Proficiencia = -50m };
            Assert.Equal(-50m, dto.Proficiencia);
        }
    }
}
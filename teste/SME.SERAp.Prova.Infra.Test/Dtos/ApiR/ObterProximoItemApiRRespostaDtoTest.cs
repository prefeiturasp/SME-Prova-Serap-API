using SME.SERAp.Prova.Infra.Dtos.ApiR;
using Xunit;

namespace SME.SERAp.Prova.Infra.Test.Dtos.ApiR
{
    public class ObterProximoItemApiRRespostaDtoTest
    {
        [Fact]
        public void Deve_Criar_ObterProximoItemApiRRespostaDto_Com_Propriedades_Padrao()
        {
            var dto = new ObterProximoItemApiRRespostaDto();

            Assert.Equal(0, dto.ProximaQuestao);
            Assert.Equal(0, dto.Ordem);
            Assert.Equal(0, dto.PosicaoProximoItem);
            Assert.Equal(0, dto.ParA);
            Assert.Equal(0, dto.ParB);
            Assert.Equal(0, dto.ParC);
            Assert.Equal(0, dto.Proficiencia);
            Assert.Equal(0, dto.ErroMedida);
        }

        [Fact]
        public void Deve_Atribuir_ProximaQuestao_Corretamente()
        {
            var dto = new ObterProximoItemApiRRespostaDto { ProximaQuestao = 77 };
            Assert.Equal(77, dto.ProximaQuestao);
        }

        [Fact]
        public void Deve_Atribuir_Ordem_Corretamente()
        {
            var dto = new ObterProximoItemApiRRespostaDto { Ordem = 3 };
            Assert.Equal(3, dto.Ordem);
        }

        [Fact]
        public void Deve_Atribuir_PosicaoProximoItem_Corretamente()
        {
            var dto = new ObterProximoItemApiRRespostaDto { PosicaoProximoItem = 5 };
            Assert.Equal(5, dto.PosicaoProximoItem);
        }

        [Fact]
        public void Deve_Atribuir_ParA_Corretamente()
        {
            var dto = new ObterProximoItemApiRRespostaDto { ParA = 1.25m };
            Assert.Equal(1.25m, dto.ParA);
        }

        [Fact]
        public void Deve_Atribuir_ParB_Corretamente()
        {
            var dto = new ObterProximoItemApiRRespostaDto { ParB = -0.5m };
            Assert.Equal(-0.5m, dto.ParB);
        }

        [Fact]
        public void Deve_Atribuir_ParC_Corretamente()
        {
            var dto = new ObterProximoItemApiRRespostaDto { ParC = 0.2m };
            Assert.Equal(0.2m, dto.ParC);
        }

        [Fact]
        public void Deve_Atribuir_Proficiencia_Corretamente()
        {
            var dto = new ObterProximoItemApiRRespostaDto { Proficiencia = 250.75m };
            Assert.Equal(250.75m, dto.Proficiencia);
        }

        [Fact]
        public void Deve_Atribuir_ErroMedida_Corretamente()
        {
            var dto = new ObterProximoItemApiRRespostaDto { ErroMedida = 0.03m };
            Assert.Equal(0.03m, dto.ErroMedida);
        }

        [Fact]
        public void Deve_Criar_ObterProximoItemApiRRespostaDto_Completo()
        {
            var dto = new ObterProximoItemApiRRespostaDto
            {
                ProximaQuestao = 101,
                Ordem = 4,
                PosicaoProximoItem = 2,
                ParA = 1.10m,
                ParB = -1.50m,
                ParC = 0.25m,
                Proficiencia = 300.00m,
                ErroMedida = 0.05m
            };

            Assert.Equal(101, dto.ProximaQuestao);
            Assert.Equal(4, dto.Ordem);
            Assert.Equal(2, dto.PosicaoProximoItem);
            Assert.Equal(1.10m, dto.ParA);
            Assert.Equal(-1.50m, dto.ParB);
            Assert.Equal(0.25m, dto.ParC);
            Assert.Equal(300.00m, dto.Proficiencia);
            Assert.Equal(0.05m, dto.ErroMedida);
        }

        [Fact]
        public void Deve_Aceitar_Valores_Negativos_Em_Proficiencia()
        {
            var dto = new ObterProximoItemApiRRespostaDto { Proficiencia = -100m };
            Assert.Equal(-100m, dto.Proficiencia);
        }

        [Fact]
        public void Deve_Aceitar_Valor_Maximo_Decimal_Em_ParA()
        {
            var dto = new ObterProximoItemApiRRespostaDto { ParA = decimal.MaxValue };
            Assert.Equal(decimal.MaxValue, dto.ParA);
        }

        [Fact]
        public void Deve_Aceitar_ErroMedida_Zero()
        {
            var dto = new ObterProximoItemApiRRespostaDto { ErroMedida = 0m };
            Assert.Equal(0m, dto.ErroMedida);
        }

        [Fact]
        public void Deve_Aceitar_ProximaQuestao_Com_Valor_Maximo_Long()
        {
            var dto = new ObterProximoItemApiRRespostaDto { ProximaQuestao = long.MaxValue };
            Assert.Equal(long.MaxValue, dto.ProximaQuestao);
        }
    }
}